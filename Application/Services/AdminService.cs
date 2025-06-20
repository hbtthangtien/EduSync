using Application.Certificates;
using Application.DTOs.Cousre;
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
				.Where(u => u.DeletedAt == null)
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
				.CountAsync();

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

			// Nếu đã là gia sư thì không cần tạo nữa
			if (await _unitOfWork.TuTors.GetSingle(x => x.UserId == user.Id) != null)
				return false;

			// Tạo mới tutor
			var tutor = new Tutor
			{
				UserId = user.Id,
				CreatedAt = DateTime.UtcNow
			};
			await _unitOfWork.TuTors.AddAsync(tutor);
			await _unitOfWork.SaveChangesAsync(); // để đảm bảo TutorId có trước khi gán vào Bio

			// Gán dữ liệu từ ActivationRequest sang BioTutor
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

			// Gán role "Tutor" cho user
			var role = await _unitOfWork.Roles.GetSingle(r => r.Name == "Tutor");
			if (role != null)
			{
				user.RoleId = role.Id;
				await _unitOfWork.Users.UpdateAsync(user);
			}

			// Đánh dấu đơn đã duyệt
			request.IsActivated = true;
			request.ActivationDate = DateTime.UtcNow;

			await _unitOfWork.SaveChangesAsync();
			return true;
		}

		public async Task<CourseDetailAdminDTO?> GetCourseDetailMoreForAdminAsync(long courseId)
		{
			var course = await _unitOfWork.Courses
				.GetInstance()
				.Include(c => c.CreatedByTutor)
					.ThenInclude(t => t.BioTutor)
				.Include(c => c.Slots)
				.Include(c => c.Contents)
				.Include(c => c.Certificate) 
				.FirstOrDefaultAsync(c => c.Id == courseId);

			if (course == null)
				return null;

			var studentCount = course.Slots?
				.Where(s => s.StudentId.HasValue)
				.Select(s => s.StudentId!.Value)
				.Distinct()
				.Count() ?? 0;

			var dto = new CourseDetailAdminDTO
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
				CreatedAt = course.CreatedAt,
				CourseContents = course.Contents?.Select(c => c.Descriptions).ToList() ?? new List<string>(),

				Certificate = course.Certificate?.Select(cert => new CertificateDTO
				{
					CertificateUrl = cert.CertificateUrl,
					IsVerified = cert.IsVerified,
					VerifiedDate = cert.VerifiedDate
				}).ToList() ?? new List<CertificateDTO>()
			};

			return dto;
		}


	}
}
