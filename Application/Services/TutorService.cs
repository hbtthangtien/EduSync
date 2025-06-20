using Application.DTOs.Commons;
using Application.DTOs.Tutors;
using Application.DTOs.Tutors.Bio;
using Application.DTOs.Tutors.Courses;
using Application.DTOs.Tutors.Dashboard;
using Application.DTOs.Tutors.Slots;
using Application.DTOs.Tutors.Students;
using Application.Extentions;
using Application.Interfaces.IService;
using Application.IUnitOfWorks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
	public class TutorService : BaseService, ITutorService
	{
		public TutorService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public async Task<List<TutorDTO>> GetAllTutorsAsync()
		{
			var tutors = await _unitOfWork.TuTors
				.GetInstance()
				.Include(t => t.BioTutor)
				.Include(t => t.Ratings)
				.ToListAsync();

			var result = tutors.Select(tutor =>
			{
				double avgRating = tutor.Ratings.Any()
					? tutor.Ratings.Average(r => r.Score)
					: 0;

				return new TutorDTO
				{
					Id = tutor.UserId, 
					FullName = tutor.BioTutor?.Fullname ?? "Chưa cập nhật",
					Introduces = tutor.BioTutor?.Introduces ?? "Chưa có mô tả",
					Specializations = tutor.BioTutor?.Specializations?
						.Split(',', StringSplitOptions.RemoveEmptyEntries)
						.Select(s => s.Trim())
						.ToList() ?? new List<string>(),
					Rating = Math.Round(avgRating, 1)
				};
			}).ToList();

			return result;
		}

		public async Task<IdResponse> UpdateBioTutors(BioUpdate request)
		{
			var tutor = await _unitOfWork.TuTors
				.GetInstance()
				.Where(e => e.UserId == request.UserId)
				.Include(e => e.BioTutor)
				.FirstOrDefaultAsync() ??
				throw ExceptionFactory.NotFound("Tutor", request.UserId);
			if(request.Introduces != null)
			{
				tutor!.BioTutor!.Introduces = request.Introduces;
			}
			if(request.Specializations != null)
			{
				tutor!.BioTutor!.Specializations = request.Specializations;
			}
			if(request.FullName != null)
			{
				tutor!.BioTutor!.Fullname = request.FullName;
			}
			
			await _unitOfWork.SaveChangesAsync();
			return IdResponse.SuccessResponse(tutor.UserId, "Update success");
		}

		public async Task<BaseResponse<List<SlotTutorDTO>>> GetSlotsBytutorAsync(long tutorId)
		{
			var tutor = await _unitOfWork.TuTors.GetInstance()
				.Where(e => e.UserId == tutorId)
				.Include(e => e.Slots)
				.ThenInclude(s => s.Course)
				.AsNoTracking()
				.FirstOrDefaultAsync();

			var result = tutor.Slots
				.GroupBy(s => new { s.StartTime.Date, s.Course.Title })
				.Select(g => new SlotTutorDTO
				{
					Id = tutor.UserId,
					Date = g.Key.Date,
					CourseTitle = g.Key.Title,
					Shifts = g.Select(s => $"{s.StartTime:HH\\:mm} - {s.EndTime:HH\\:mm}").ToList()
				})
				.ToList();
			return BaseResponse<List<SlotTutorDTO>>.SuccessResponse(result);
		}

		public async Task<BaseResponse<List<StudentInCourse>>> GetStudentsByCourseId(long tutorId, long courseId)
		{
			var data = await _unitOfWork.Slots
				.GetInstance()
				.Where(e => e.TutorId == tutorId && e.CourseId == courseId)
				.Include(e => e.Course)
				.Include(e => e.Student)
					.ThenInclude(e => e.User)
				.Distinct()
				.Select(e => new StudentInCourse
				{
					Id = (long)e!.StudentId,
					StudentName = e.Student!.User!.Username,
					TitleCourse = e.Course!.Title
				})
				.ToListAsync();

			return BaseResponse<List<StudentInCourse>>.SuccessResponse(data);
		}

		public async Task<BaseResponse<List<StudentInCourse>>> GetAllStudentInAllCourse(long tutorId)
		{
			var data = await _unitOfWork.Slots
				.GetInstance()
				.Where(e => e.TutorId == tutorId)
				.Include(e => e.Course)
				.Include(e => e.Student)
					.ThenInclude(e => e.User)
				.Distinct()
				.Select(e => new StudentInCourse
				{
					Id = (long)e!.StudentId,
					StudentName = e.Student!.User!.Username,
					TitleCourse = e.Course!.Title
				})
				.ToListAsync();
			return BaseResponse<List<StudentInCourse>>.SuccessResponse(data);
		}

		public async Task<BaseResponse<List<CourseTutors>>> GetAllCourseOfTutors(long tutorId)
		{
			var data =  await _unitOfWork.Courses
				.GetInstance()
				.Where(c => c.CreatedByTutorId == tutorId)
				.Select(c => new CourseTutors
				{
					Id = c.Id,
					Title = c.Title,
					Description = c.Description,
					NumberOfStudent = c.Slots.Count(s => s.StudentId != null)
				})
				.ToListAsync();
			return BaseResponse<List<CourseTutors>>.SuccessResponse(data);
		}

		public async Task<BaseResponse<DashboardOfTutors>> ReportOftutors(long tutorId)
		{
			var dashboard = await _unitOfWork.TuTors.GetInstance()
					.Where(t => t.UserId == tutorId)
					.Select(t => new DashboardOfTutors
					{
						Slots = t.Slots.Count(), // Tổng số lớp học
						TotalStudents = t.Slots.Count(s => s.StudentId != null), // Số học viên
						IncomePerMonth = t.Courses
							.SelectMany(c => c.Slots)
							.Where(s => s.CreatedAt.Month == DateTime.Now.Month && s.StudentId != null)
							.Sum(s => (double?)s.Course!.PricePerSession) ?? 0,
						Overalls = t.Ratings.Any() ? Math.Round(t.Ratings.Average(r => r.Score), 1) : 0,
						UpcomingSchedules = t.Slots
							.Where(s => s.StartTime > DateTime.Now)
							.OrderBy(s => s.StartTime)
							.Take(5)
							.Select(s => $"{s.StartTime:dd/MM/yyyy} - {s.StartTime:HH:mm} - {s.EndTime:HH:mm} | {s.Course.Title}")
							.ToList()
					})
					.FirstOrDefaultAsync()??
					throw ExceptionFactory.NotFound("Tutor",tutorId);
			return BaseResponse<DashboardOfTutors>.SuccessResponse(dashboard);
		}

		public async Task<BaseResponse<BioViewDetails>> GetBioViewDetails(long tutorId)
		{
			var bio = await _unitOfWork.TuTors.GetInstance()
					.Where(e => e.UserId == tutorId)
					.Include(e => e.BioTutor)
					.Select(e => new BioViewDetails
					{
						UserId = e.UserId,
						FullName = e.BioTutor.Fullname,
						Introduces = e.BioTutor.Introduces,
						Specializations = e.BioTutor.Specializations
					})
					.FirstOrDefaultAsync()
					?? throw ExceptionFactory.NotFound("Tutor", tutorId);
			return BaseResponse<BioViewDetails>.SuccessResponse(bio);
		}
	}
}
