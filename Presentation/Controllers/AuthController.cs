using Application.DTOs.Login;
using Application.DTOs.Register;
using Application.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : Controller
	{
		private readonly IAuthService _authService;
		public AuthController(IAuthService authService) => _authService = authService;

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDTO dto) =>
		Ok(await _authService.LoginAsync(dto));

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterDTO dto) =>
			Ok(await _authService.RegisterAsync(dto));
	}

}
