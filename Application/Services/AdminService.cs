using Application.DTOs.Certifiace;
using Application.DTOs.Cousre;
using Application.DTOs.RegisterTutor;
using Application.DTOs.Tutors.Bio;
using Application.DTOs.User;
using Application.Interfaces.IService;
using Application.IUnitOfWorks;
using Domain.Entities;
using Domain.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class AdminService :  BaseService, IAdminUserService
	{
		public AdminService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
		public async Task<List<UserSumaryDTO>> GetAllUsersAsync()
		{
			var users = await _unitOfWork.Users
				.GetInstance()
				.Include(u => u.Role)
				.Where(u => u.RoleId != 1&& u.DeletedAt == null)
				.ToListAsync();

			return users.Select(u => new UserSumaryDTO
			{
				Id = u.Id,
				Email = u.Email,
				Username = u.Username,
				RoleName = u.Role?.Name ?? "Không rõ",
			}).ToList();
		}
		public async Task<UserDetailDTO?> GetUserByIdAsync(long userId)
		{
			var user = await _unitOfWork.Users
				.GetInstance()
				.Include(u => u.Role)
				.FirstOrDefaultAsync(u => u.Id == userId);

			if (user == null) return null;

			return new UserDetailDTO
			{
				Id = user.Id,
				Email = user.Email,
				Username = user.Username,
				RoleName = user.Role?.Name ?? "Không rõ",
				IsActive = true 
			};
		}

		public async Task<bool> DeleteUserAsync(long userId)
		{
			var user = await _unitOfWork.Users.FindByIdAsync(userId);
			if (user == null) return false;

			user.DeletedAt = DateTime.Now; 
			await _unitOfWork.SaveChangesAsync();
			return true;
		}
		public async Task<List<CourseAdminDTO>> GetAllCourseAdminAsync()
		{
			var courses = await _unitOfWork.Courses
				.GetInstance()
				.Include(c => c.CreatedByTutor)
					.ThenInclude(t => t.BioTutor)
				.Include(c => c.Slots)
				.ToListAsync();

			var result = courses.Select(course =>
			{
				var studentCount = course.Slots?
					.Where(s => s.StudentId.HasValue)
					.Select(s => s.StudentId.Value)
					.Distinct()
					.Count() ?? 0;

				return new CourseAdminDTO
				{
					Id = course.Id,
					Title = course.Title,
					TutorName = course.CreatedByTutor?.BioTutor?.Fullname ?? "Chưa cập nhật",
					StudentCount = studentCount
				};
			}).ToList();

			return result;
		}
		public async Task<CourseDetailDTO?> GetCourseDetailByIdForAdminAsync(long courseId)
		{
			var course = await _unitOfWork.Courses
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

		public async Task<AdminDashboardReportDTO> GetAdminDashboardReportAsync()
		{
			var now = DateTime.UtcNow;
			var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);

			// Tổng số người dùng (chưa xóa)
			var totalUsers = await _unitOfWork.Users
				.GetInstance()
				.CountAsync(u => u.DeletedAt == null);

			// Tổng số học viên (chưa xóa)
			var totalStudents = await _unitOfWork.Students
				.GetInstance()
				.CountAsync(s => s.DeletedAt == null);

			// Tổng số khóa học
			var totalCourses = await _unitOfWork.Courses
				.GetInstance()
				.CountAsync(c => c.Status == CourseStatus.Published || c.Status == CourseStatus.Approved);
	

			// Doanh thu tháng này
			var monthlyRevenue = await _unitOfWork.Payments
				.GetInstance()
				.Where(p => p.TransactionDate >= firstDayOfMonth &&
							p.TransactionDate <= now &&
							p.Status == PaymentStatus.Success)
				.SumAsync(p => (decimal?)p.Amount) ?? 0;

			// Lớp học phổ biến nhất
			var courses = await _unitOfWork.Courses
				.GetInstance()
				.Include(c => c.Slots)
				.ToListAsync();

			var mostPopularCourse = courses
				.Select(c => new {
					Course = c,
					StudentCount = c.Slots
						.Where(s => s.StudentId.HasValue)
						.Select(s => s.StudentId!.Value)
						.Distinct()
						.Count()
				})
				.OrderByDescending(x => x.StudentCount)
				.FirstOrDefault();

			// Lớp học mới đăng ký
			var recentCourses = await _unitOfWork.Courses
				.GetInstance()
				.Include(c => c.CreatedByTutor)
					.ThenInclude(t => t.BioTutor)
				.Include(c => c.Slots)
				.OrderByDescending(c => c.CreatedAt)
				.Take(5)
				.ToListAsync();

			var recentCourseList = recentCourses.Select(c => new DashboardCourseSummaryDTO
			{
				Title = c.Title,
				TutorName = c.CreatedByTutor?.BioTutor?.Fullname ?? "Chưa cập nhật",
				StudentCount = c.Slots
					.Where(s => s.StudentId.HasValue)
					.Select(s => s.StudentId!.Value)
					.Distinct()
					.Count()
			}).ToList();

			return new AdminDashboardReportDTO
			{
				TotalUsers = totalUsers,
				TotalStudents = totalStudents,
				TotalCourses = totalCourses,
				MonthlyRevenue = monthlyRevenue,
				MostPopularCourseName = mostPopularCourse?.Course.Title ?? "Không có dữ liệu",
				MostPopularCourseStudentCount = mostPopularCourse?.StudentCount ?? 0,
				RecentCourses = recentCourseList
			};
		}

		public async Task<bool> ApproveActivationRequestAsync(long requestId)
		{
			var request = await _unitOfWork.ActivationRequests
				.GetInstance()
				.FirstOrDefaultAsync(x => x.Id == requestId);

			if (request == null || request.IsActivated)
				return false;

			var user = await _unitOfWork.Users.GetSingle(x => x.Id == request.TutorUserId);
			if (user == null)
				return false;

			if (await _unitOfWork.TuTors.GetSingle(x => x.UserId == user.Id) != null)
				return false;

			var tutor = new Tutor
			{
				UserId = user.Id,
				CreatedAt = DateTime.UtcNow
			};
			await _unitOfWork.TuTors.AddAsync(tutor);
			await _unitOfWork.SaveChangesAsync(); 

			var bioTutor = new BioTutor
			{
				TutorId = tutor.UserId,
				Fullname = request.Fullname ?? "Chưa cập nhật",
				Specializations = request.Specializations ?? "Chưa cập nhật",
				Introduces = request.Introduces ?? "Chưa cập nhật",
				CreatedAt = DateTime.UtcNow
			};
			await _unitOfWork.BioTuTors.AddAsync(bioTutor);
			await _unitOfWork.SaveChangesAsync();

			var role = await _unitOfWork.Roles.GetSingle(r => r.Name == "Tutor");
			if (role != null)
			{
				user.RoleId = role.Id;
				await _unitOfWork.Users.UpdateAsync(user);
			}

			request.IsActivated = true;
			request.ActivationDate = DateTime.UtcNow;

			await _unitOfWork.SaveChangesAsync();
			return true;
		}
		public async Task<List<ActivationRequestDTO>> GetAllActivationRequestsAsync()
		{
			var requests = await _unitOfWork.ActivationRequests
				.GetInstance()
				.Where(r => r.TutorUserId != null && r.TutorUserId != 0)
				.OrderByDescending(r => r.CreatedAt)
				.Select(r => new ActivationRequestDTO
				{
					RequestId = r.Id,
					TutorUserId = r.TutorUserId,
					Fullname = r.Fullname,
					Specializations = r.Specializations,
					Introduces = r.Introduces,
					IsActivated = r.IsActivated,
					ActivationDate = r.ActivationDate,
					CreatedAt = r.CreatedAt,

					// Lấy danh sách CertificateUrl liên quan đến ActivationRequest
					CertificateUrls = _unitOfWork.Certificates
						.GetInstance()
						.Where(c => c.ActivationRequestId == r.Id)
						.Select(c => c.CertificateUrl)
						.ToList()
				})
				.ToListAsync();

			return requests;
		}


		public async Task<List<ActivationRequestDTO>> GetCourseDetailApproveAsync()
		{
			var requests = await _unitOfWork.ActivationRequests
				.GetInstance()
				.Include(r => r.Course)
				.Where(r =>
					(r.TutorUserId == null || r.TutorUserId == 0) &&
					r.CourseId != null && r.CourseId != 0)
				.OrderByDescending(r => r.CreatedAt)
				.ToListAsync();

			var courseIds = requests
				.Where(r => r.CourseId.HasValue)
				.Select(r => r.CourseId.Value)
				.Distinct()
				.ToList();

			var certificates = await _unitOfWork.Certificates
				.GetInstance()
				.Where(c => c.CourseId.HasValue && courseIds.Contains(c.CourseId.Value))
				.ToListAsync();

			var result = requests.Select(r => new ActivationRequestDTO
			{
				RequestId = r.Id,
				TutorUserId = r.TutorUserId,
				CourseId = r.CourseId,
				Fullname = r.Fullname,
				Specializations = r.Specializations,
				Introduces = r.Introduces,
				ActivationDate = r.ActivationDate,
				CreatedAt = r.CreatedAt,
				CourseStatus = r.Course?.Status ?? 0,
				CertificateUrls = certificates
					.Where(c => c.CourseId == r.CourseId)
					.Select(c => c.CertificateUrl)
					.ToList()
			}).ToList();

			return result;
		}

		public async Task<bool> ApproveCourseAsync(long courseId)
		{
			var course = await _unitOfWork.Courses
				.GetInstance()
				.FirstOrDefaultAsync(c => c.Id == courseId);

			if (course == null || course.Status != CourseStatus.Pending)
				return false;

			course.Status = CourseStatus.Approved;
			await _unitOfWork.SaveChangesAsync();

			return true;
		}


	}
}
