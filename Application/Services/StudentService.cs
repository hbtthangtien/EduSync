using Application.DTOs.Commons;
using Application.DTOs.RegisterTutor;
using Application.Interfaces.IRepository;
using Application.Interfaces.IService;
using Application.IUnitOfWorks;
using Domain.Entities;
using System;
using Mapster;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Tutors.Courses;

namespace Application.Services
{
	public  class StudentService : IStudentService
	{
		public readonly IUnitOfWork _unitOfWorks;
		public IUserRepository _userRepo;

		private readonly IFileStorageService _fileStorage;

		public StudentService(
			IUnitOfWork unitOfWork,
			IUserRepository userRepo,
			IFileStorageService fileStorage)
		{
			_unitOfWorks = unitOfWork;
			_userRepo = userRepo;
			_fileStorage = fileStorage;
		}

		public async Task<BaseResponse<string>> RegisterTutorAsync(RegisterTutorDTO registerTutor)
		{
			var userId = _userRepo.GetUserId();

			if (await _unitOfWorks.TuTors.GetSingle(x => x.UserId == userId) is not null)
				return BaseResponse<string>.Failure("Tài khoản của bạn đã là gia sư.");

			var existingRequest = await _unitOfWorks.ActivationRequests
				.GetSingle(x => x.TutorUserId == userId && !x.IsActivated);
			if (existingRequest != null)
				return BaseResponse<string>.Failure("Bạn đã gửi đơn và đang chờ duyệt.");

			// Upload certificate images
			var certificates = await CreateCertificates(userId, registerTutor);

			// Tạo mới đơn đăng ký kèm chứng chỉ
			var request = new ActivationRequest
			{
				TutorUserId = userId,
				RequestDate = DateTime.UtcNow,
				IsActivated = false,
				Fullname = registerTutor.Fullname,
				Specializations = registerTutor.Specializations,
				Introduces = registerTutor.Introduces,
				Certificates = certificates 
			};

			await _unitOfWorks.ActivationRequests.AddAsync(request);
			await _unitOfWorks.SaveChangesAsync();

			return BaseResponse<string>.SuccessResponse("Đơn đăng ký làm gia sư của bạn đã được gửi.");
		}

		public async Task<List<Certificate>> CreateCertificates(long tutorId, RegisterTutorDTO dto)
		{
			var imageFrontUrl = await _fileStorage.UploadFileAsync(dto.FrontImage);
			var imageBackUrl = await _fileStorage.UploadFileAsync(dto.BackImage);

			var certificates = new List<Certificate>
		{
		new Certificate
		{
			CertificateUrl = imageFrontUrl,
			//TutorId = tutorId,
			IsVerified = false,
			VerifiedDate = null
		},
		new Certificate
		{
			CertificateUrl = imageBackUrl,
			//TutorId = null,
			IsVerified = false,
			VerifiedDate = null
		}
		};
			return certificates;
		}


	}
}
