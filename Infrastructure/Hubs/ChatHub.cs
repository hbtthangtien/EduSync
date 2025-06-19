using Application.Services.Helpers;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Hubs
{
	public class ChatHub : Hub
	{
		public async Task SendMessage(long senderId, long receiverId, string message)
		{
			var conversationId = ConversationHelper.GenerateConversationId(senderId, receiverId);

			await Clients.Group(conversationId).SendAsync("ReceiveMessage", new
			{
				senderId,
				receiverId,
				message,
				sentAt = DateTime.UtcNow
			});
		}

		public override async Task OnConnectedAsync()
		{
			var httpContext = Context.GetHttpContext();
			if (httpContext.Request.Query.TryGetValue("userId", out var userIdStr) &&
				long.TryParse(userIdStr, out long userId))
			{
				await Groups.AddToGroupAsync(Context.ConnectionId, userId.ToString());
			}
			await base.OnConnectedAsync();
		}
	}
}
