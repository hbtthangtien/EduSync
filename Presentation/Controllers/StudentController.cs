using Application.DTOs.Commons;
using Application.DTOs.RegisterTutor;
using Application.Interfaces.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
		[ApiController]
		[Route("api/student")]
		public class StudentController : ControllerBase
		{
			private readonly IStudentService _studentService;

			public StudentController(IStudentService studentService)
			{
				_studentService = studentService;
			}
		[HttpPost("register-tutor")]
		[Authorize(Roles = "Student")]
		[ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> RegisterAsTutor([FromForm] RegisterTutorDTO dto)
		{
			var result = await _studentService.RegisterTutorAsync(dto);

			if (!result.Success)
				return BadRequest(result);

			return Ok(result);
		}

	}
}
