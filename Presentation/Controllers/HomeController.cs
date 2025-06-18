using Application.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/home")]
	public class HomeController : ControllerBase
	{
		private readonly IHomePageService _homePageService;

		public HomeController(IHomePageService homePageService)
		{
			_homePageService = homePageService;
		}

		[HttpGet]
		public async Task<IActionResult> GetHomePage()
		{
			var data = await _homePageService.GetHomePageDataAsync();
			return Ok(data);
		}
	}
}
