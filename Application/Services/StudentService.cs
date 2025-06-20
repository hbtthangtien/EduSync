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

			// Kiểm tra xem đã là gia sư chưa
			if (await _unitOfWorks.TuTors.GetSingle(x => x.UserId == userId) is not null)
				return BaseResponse<string>.Failure("Tài khoản của bạn đã là gia sư.");

			// Kiểm tra xem đã có đơn đăng ký chưa
			var existingRequest = await _unitOfWorks.ActivationRequests
				.GetSingle(x => x.TutorUserId == userId && !x.IsActivated);
			if (existingRequest != null)
				return BaseResponse<string>.Failure("Bạn đã gửi đơn và đang chờ duyệt.");

			// Tạo mới đơn đăng ký
			var request = new ActivationRequest
			{
				TutorUserId = userId,
				RequestDate = DateTime.UtcNow,
				IsActivated = false,
				Fullname = registerTutor.Fullname,
				Specializations = registerTutor.Specializations,
				Introduces = registerTutor.Introduces
			};

			await _unitOfWorks.ActivationRequests.AddAsync(request);
			await _unitOfWorks.SaveChangesAsync();

			return BaseResponse<string>.SuccessResponse("Đơn đăng ký làm gia sư của bạn đã được gửi.");
		}


	}
}
