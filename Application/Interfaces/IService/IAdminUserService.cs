using Application.DTOs.Cousre;
using Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IService
{
	public interface IAdminUserService
	{
		Task<UserDetailDTO?> GetUserByIdAsync(long userId);
		Task<bool> DeleteUserAsync(long userId);
		Task<List<UserSumaryDTO>> GetAllUsersAsync();
		Task<List<CourseAdminDTO>> GetAllCourseAdminAsync();
		Task<CourseDetailDTO?> GetCourseDetailByIdForAdminAsync(long courseId);
		Task<AdminDashboardReportDTO> GetAdminDashboardReportAsync();
		Task<bool> ApproveActivationRequestAsync(long requestId);
		Task<CourseDetailAdminDTO?> GetCourseDetailMoreForAdminAsync(long courseId);
		Task<bool> ApproveCourseAsync(long courseId);
	}
}
