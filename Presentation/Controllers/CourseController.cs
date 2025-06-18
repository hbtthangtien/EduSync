using Application.DTOs.Cousre;
using Application.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/courses")]
	public class CourseController : ControllerBase
	{
		private readonly ICousreService _courseService;

		public CourseController(ICousreService courseService)
		{
			_courseService = courseService;
		}

		[HttpGet("{id:long}")]
		[ProducesResponseType(typeof(CourseDetailDTO), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetCourseDetail(long id)
		{
			var result = await _courseService.GetCourseDetailByIdAsync(id);

			if (result == null)
				return NotFound("Không tìm thấy khóa học.");

			return Ok(result);
		}
	}
}
