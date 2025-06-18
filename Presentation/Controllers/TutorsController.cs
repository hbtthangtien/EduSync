using Application.Interfaces.IService;
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

	}
}
