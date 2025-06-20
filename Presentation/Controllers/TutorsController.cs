using Application.DTOs.Tutors.Bio;
using Application.DTOs.Tutors.Courses;
using Application.Interfaces.IService;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/tutors")]
	[ApiController]
	public class TutorsController : ControllerBase
	{
		private readonly ITutorService _tutorService;
		private readonly ICourseService _courseService;
		public TutorsController(ITutorService tutorService,
			ICourseService courseService)
		{
			_tutorService = tutorService;
			_courseService = courseService;
		}

		[HttpPut("{id}/bio")]
		public async Task<IActionResult> UpdateBioTutors(BioUpdate request)
		{
			var data = await _tutorService.UpdateBioTutors(request);
			return Ok(data);
		}

		[HttpGet("{id}/slots")]
		public async Task<IActionResult> GetSlotByTutorId(int id)
		{
			var data = await _tutorService.GetSlotsBytutorAsync(id);
			return Ok(data);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllTutors()
		{
			var tutors = await _tutorService.GetAllTutorsAsync();
			return Ok(tutors);
		}

		[HttpGet("{id}/courses/{courseId}/students")]
		public async Task<IActionResult> GetStudentByCourseId(long id, long courseId)
		{
			var data = await _tutorService.GetStudentsByCourseId(id,courseId);
			return Ok(data);
		}

		[HttpGet("{id}/courses/students")]
		public async Task<IActionResult> GetAllStudentInAllCourse(long id)
		{
			var data = await _tutorService.GetAllStudentInAllCourse(id);
			return Ok(data);
		}

		[HttpGet("{id}/courses")]
		public async Task<IActionResult> GetAllCourseOfTutor(long id)
		{
			var data = await _tutorService.GetAllCourseOfTutors(id);
			return Ok(data);
		}

		[HttpGet("{id}/dashboard")]
		public async Task<IActionResult> DashBoardForTutors(long id)
		{
			var data = await _tutorService.ReportOftutors(id);
			return Ok(data);
		}

		[HttpGet("{id}/bio")]
		public async Task<IActionResult> GetBioByTutor(long id)
		{
			var data = await _tutorService.GetBioViewDetails(id);
			return Ok(data);
		}

		[HttpPost("{id}/courses")]
		public async Task<IActionResult> CreateCourseByTutor(long id,[FromForm] CreateCourse request)
		{
			var data = await _courseService.CreateCourseAsync(id,request);
			return Ok(data);
		}
	}
	
}
