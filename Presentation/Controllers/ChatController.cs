using Application.DTOs.ChatMesseage;
using Application.Interfaces.IService;
using Application.Services.Helpers;
using Infrastructure.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ChatController : ControllerBase
	{
		private readonly IChatService _chatService;
		private readonly IHubContext<ChatHub> _hubContext;

		public ChatController(IChatService chatService, IHubContext<ChatHub> hubContext)
		{
			_chatService = chatService ?? throw new ArgumentNullException(nameof(chatService));
			_hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
		}

		[HttpPost("send")]
		public async Task<IActionResult> Send([FromBody] SendMessageRequest request)
		{
			await _chatService.SendMessageAsync(request);

			var conversationId = ConversationHelper.GenerateConversationId(request.SenderId, request.ReceiverId);
			await _hubContext.Clients.Group(conversationId).SendAsync("ReceiveMessage", new
			{
				senderId = request.SenderId,
				receiverId = request.ReceiverId,
				message = request.Content,
				sentAt = DateTime.UtcNow
			});

			return Ok(new { message = "Sent successfully" });
		}

		[HttpGet("conversation/{partnerId:long}")]
		public async Task<IActionResult> GetConversation(long partnerId, [FromQuery] long currentUserId )
		{
			var messages = await _chatService.GetConversationAsync(currentUserId, partnerId);
			return Ok(messages);
		}

		[HttpPost("mark-as-read")]
		public async Task<IActionResult> MarkAsRead([FromBody] MarkAsReadRequest request, [FromQuery] long currentUserId)
		{
			//var currentUserId = long.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

			bool result = await _chatService.MarkMessagesAsReadAsync(currentUserId, request.MessageIds);

			if (!result)
			{
				return NotFound(new { error = "No unread messages found for the provided IDs." });
			}

			return Ok(new { status = "marked as read" });
		}

		[HttpGet("contacts/{userId:long}")]
		public async Task<IActionResult> GetChatContacts(long userId)
		{
			var contacts = await _chatService.GetChatContactsAsync(userId);
			return Ok(contacts);
		}
	}
}
