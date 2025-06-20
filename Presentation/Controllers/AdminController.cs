using Application.DTOs.Cousre;
using Application.DTOs.RegisterTutor;
using Application.Interfaces.IService;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/admin/users")]
	[Authorize(Roles = "Admin")]
	public class AdminUsersController : ControllerBase
	{
		private readonly IAdminUserService _adminUserService;

		public AdminUsersController(IAdminUserService adminUserService)
		{
			_adminUserService = adminUserService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllUsers()
		{
			var users = await _adminUserService.GetAllUsersAsync();
			return Ok(users);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetUserById(long id)
		{
			var user = await _adminUserService.GetUserByIdAsync(id);
			if (user == null) return NotFound();

			return Ok(user);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(long id)
		{
			var result = await _adminUserService.DeleteUserAsync(id);
			if (!result) return NotFound();

			return Ok(new { message = "User deleted successfully" });
		}

		[HttpGet("course")]
		public async Task<IActionResult> GetAllCourses()
		{
			var courses = await _adminUserService.GetAllCourseAdminAsync();
			return Ok(courses);
		}
		[HttpGet("course/{id}")]
		[ProducesResponseType(typeof(CourseDetailDTO), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetCourseDetail(long id)
		{
			var result = await _adminUserService.GetCourseDetailByIdForAdminAsync(id);

			if (result == null)
				return NotFound("Không tìm thấy khóa học.");

			return Ok(result);
		}
		[HttpGet("dashboard")]
		public async Task<IActionResult> GetDashboard()
		{
			var report = await _adminUserService.GetAdminDashboardReportAsync();
			return Ok(report);
		}

		[HttpPost("activation/approve")]
		public async Task<IActionResult> ApproveTutorActivation([FromBody] ApproveRequestDTO request)
		{
			var success = await _adminUserService.ApproveActivationRequestAsync(request.RequestId);

			if (!success)
				return NotFound(new { error = "Đơn duyệt không tồn tại hoặc đã được xử lý." });

			return Ok(new { message = "Đơn đã được duyệt thành công." });
		}
		[HttpGet("coursedetail/{courseId:long}")]
		public async Task<IActionResult> GetCourseDetailMore(long courseId)
		{
			var result = await _adminUserService.GetCourseDetailMoreForAdminAsync(courseId);
			if (result == null)
				return NotFound(new { Message = "Không tìm thấy khóa học" });

			return Ok(result);
		}
	}

}
