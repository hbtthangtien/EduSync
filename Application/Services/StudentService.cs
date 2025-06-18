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

			if (await _unitOfWorks.Students.GetSingle(x => x.UserId == userId) is null)
				return BaseResponse<string>.Failure("Tài khoản không hợp lệ hoặc chưa phải là học sinh.");

			var certUrl = await _fileStorage.UploadFileAsync(registerTutor.CertificateFile);

			var tutor = registerTutor.Adapt<Tutor>();
			tutor.UserId = userId;

			var bioTutor = registerTutor.Adapt<BioTutor>();
			bioTutor.Tutor = tutor;

			var certificate = new Certificate
			{
				CertificateUrl = certUrl,
				IsVerified = true, 
				CreatedAt = DateTime.UtcNow,
				CourseId = 0 
			};

			tutor.Certificates = new List<Certificate> { certificate };
			tutor.BioTutor = bioTutor;

			await _unitOfWorks.TuTors.AddAsync(tutor);
			await _unitOfWorks.SaveChangesAsync();

			return BaseResponse<string>.SuccessResponse("Bạn đã đăng ký làm gia sư thành công.");
		}


	}
}
