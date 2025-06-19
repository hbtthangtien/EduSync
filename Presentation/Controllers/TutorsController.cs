using Application.DTOs.Tutors.Bio;
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

		public TutorsController(ITutorService tutorService)
		{
			_tutorService = tutorService;
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

	}
	
}
