

using Application.DTOs.ActivationRequest;
using Application.DTOs.Commons;
using Application.DTOs.Cousre;
using Application.DTOs.Tutors.Bio;
using Application.DTOs.Tutors.Courses;
using Application.DTOs.Tutors.Courses.Contents;
using Application.Extentions;
using Application.Interfaces.IService;
using Application.IUnitOfWorks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
	public class CourseService : ICourseService
	{
		private readonly IUnitOfWork _unitOfWorks;
		private readonly IUserContextService _userContextService;
		private readonly IFileStorageService _fileService;
		private readonly IActivationRequestService _activationRequestService;
		public CourseService(IUnitOfWork unitOfWorks,
			IUserContextService userContextService,
			IFileStorageService fileStorage,
			IActivationRequestService activationRequestService)
		{
			_unitOfWorks = unitOfWorks;
			_userContextService = userContextService;
			_fileService = fileStorage;
			_activationRequestService = activationRequestService;
		}

		public async Task<CourseDetailDTO?> GetCourseDetailByIdAsync(long courseId)
		{
			var course = await _unitOfWorks.Courses
			.GetInstance()
			.Include(c => c.CreatedByTutor)
			.ThenInclude(t => t.BioTutor)
			.Include(c => c.Contents)
			.FirstOrDefaultAsync(c => c.Id == courseId);

			if (course == null)
				return null;

			var dto = new CourseDetailDTO
			{
				Title = course.Title,
				Description = course.Description,
				TutorBio = new BioTutorDTO
				{
					FullName = course.CreatedByTutor?.BioTutor?.Fullname ?? "Chưa cập nhật",
					Introduces = course.CreatedByTutor?.BioTutor?.Introduces ?? "Chưa có mô tả"
				},
				IsTrialAvailable = course.IsTrialAvailable,
				TrialSessions = course.TrialSessions,
				PricePerSession = course.PricePerSession,

				CourseContents = course.Contents?
					.Select(c => c.Descriptions)
					.ToList() ?? new List<string>()

			};

			return dto;
		}

		public async Task<List<CourseDTO>> GetAllCoursesAsync()
		{
			var courses = await _unitOfWorks.Courses
				.GetInstance()
				.Include(c => c.CreatedByTutor)
					.ThenInclude(t => t.BioTutor)
				.Include(c => c.Slots)
				.ToListAsync();

			var result = courses.Select(course =>
			{
				var studentCount = course.Slots?
					.Where(slot => slot.StudentId.HasValue)
					.Select(slot => slot.StudentId.Value)
					.Distinct()
					.Count() ?? 0;

				return new CourseDTO
				{
					Id = course.Id,
					Title = course.Title,
					Description = course.Description,
					TutorName = course.CreatedByTutor?.BioTutor?.Fullname ?? "Chưa cập nhật",
					StudentCount = studentCount
				};
			}).ToList();

			return result;
		}

		public async Task<BaseResponse<ResponseCreateCourse>> CreateCourseAsync(long tutorId, CreateCourse create)
		{
			// create certificates from request
			var certificates = await CreateCertificates(tutorId, create);

			// create content from file
			var contents = create.listContent.Select(e => new Content
			{
				ContentType = e.ContentType,
				Descriptions = e.Descriptions,
			}).ToList();

			// create course
			var course = new Course
			{
				Title = create.Title,
				Description = create.Description,
				CreatedByTutorId = tutorId,
				TrialSessions = 2,
				ServiceFeePercentage = 20,
				IsTrialAvailable = true,
				PricePerSession = create.PricePerSession,
				Status = Domain.Enums.CourseStatus.Pending,
				NumberOfSession = create.NumberOfSession,
				DurationSession = create.DurationSession,
				Certificate = certificates,
				Contents = contents
			};

			await _unitOfWorks.Courses.AddAsync(course);
			await _unitOfWorks.SaveChangesAsync();

			// Lấy BioTutor để đẩy vào ActivationRequest
			var bio = await _unitOfWorks.BioTuTors.GetSingle(x => x.TutorId == tutorId);

			var activation = new CreateActivationRequest
			{
				CourseId = course.Id,
				TutorId = tutorId,
				Fullname = bio?.Fullname ?? "",
				Introduces = bio?.Introduces ?? "",
				Specializations = bio?.Specializations ?? ""
			};

			await _activationRequestService.CreateActivationRequest(activation);

			var response = new ResponseCreateCourse
			{
				Id = course.Id,
				NumberOfSessions = create.NumberOfSession
			};

			return BaseResponse<ResponseCreateCourse>.SuccessResponse(response);
		}

		private async Task<List<Certificate>> CreateCertificates(long tutorId, CreateCourse create)
		{
			var imageFrontUrl = await _fileService.UploadFileAsync(create.FrontImage);
			var imageBackUrl = await _fileService.UploadFileAsync(create.BackImage);
			var certificates = new List<Certificate>
			{
				new Certificate
				{
					CertificateUrl = imageFrontUrl,
					TutorId = tutorId,
					IsVerified = true,
					VerifiedDate = DateTime.Now,
				},
				new Certificate
				{
					CertificateUrl = imageBackUrl,
					TutorId = tutorId,
					IsVerified = true,
					VerifiedDate = DateTime.Now,
				}
			};
			return certificates;
		}

		public async Task CreateContentForCourse(long courseId, List<CreateContent> listContent)
		{
			var course = await _unitOfWorks.Courses
				.GetInstance()
				.Where(e => e.Id == courseId)
				.Include(e => e.Contents)
				.SingleOrDefaultAsync()
				?? throw ExceptionFactory.NotFound("Course", courseId);
			var contents = listContent.Select(e => new Content
			{
				ContentType = e.ContentType,
				CourseId = courseId,
				Descriptions = e.Descriptions,

			}).ToList();
			foreach (var item in contents)
			{
				course.Contents.Add(item);
				
			}
			await _unitOfWorks.SaveChangesAsync();
			
		}
	}
}
