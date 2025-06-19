using Application.DTOs.Commons;
using Application.Interfaces.IRepository;
using Application.Interfaces.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SlotController : ControllerBase
	{
		private readonly ISlotService _slotService;
		private readonly IUserRepository _userRepository;

		public SlotController(ISlotService slotService, IUserRepository userRepository)
		{
			_slotService = slotService;
			_userRepository = userRepository;
		}
		[HttpPost("register/{slotId}")]
		[Authorize(Roles = "Student")]
		public async Task<ActionResult<BaseResponse<string>>> RegisterSlot([FromRoute] long slotId)
		{
			if (slotId <= 0)
			{
				return BadRequest(BaseResponse<string>.ErrorResponse("Giá trị slotId không hợp lệ", new Dictionary<string, string>
		{
			{ "slotId", "slotId phải lớn hơn 0" }
		}));
			}

			try
			{
				var userId = _userRepository.GetUserId();

				await _slotService.RegisterSlotAsync(slotId, userId);

				return Ok(BaseResponse<string>.SuccessResponse(
					data: "Đăng ký slot thành công",
					message: "Thành công",
					paging: null
				));
			}
			catch (UnauthorizedAccessException ex)
			{
				return StatusCode(403, BaseResponse<string>.ErrorResponse("Không được phép", new Dictionary<string, string>
		{
			{ "auth", ex.Message }
		}));
			}
			catch (InvalidOperationException ex)
			{
				return BadRequest(BaseResponse<string>.ErrorResponse("Không thể đăng ký slot", new Dictionary<string, string>
		{
			{ "logic", ex.Message }
		}));
			}
			catch (Exception ex)
			{
				return StatusCode(500, BaseResponse<string>.ErrorResponse("Lỗi hệ thống", new Dictionary<string, string>
		{
			{ "exception", ex.Message }
		}));
			}
		}

	}

}
