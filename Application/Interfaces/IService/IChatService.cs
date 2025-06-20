using Application.DTOs.ChatMesseage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IService
{
	public interface IChatService
	{
		Task SendMessageAsync(SendMessageRequest request);
		Task<List<ChatMessageResponse>> GetConversationAsync(long userId1, long userId2);

		Task<bool> MarkMessagesAsReadAsync(long currentUserId, List<long> messageIds);
	}
}

