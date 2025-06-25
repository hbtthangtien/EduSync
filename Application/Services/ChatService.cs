using Application.DTOs.ChatMesseage;
using Application.Interfaces.IService;
using Application.IUnitOfWorks;
using Application.Services.Helpers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;

namespace Application.Services
{
	public class ChatService :BaseService, IChatService
	{
		public ChatService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
		public async Task SendMessageAsync(SendMessageRequest request)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request), "Request is null");

			if (string.IsNullOrWhiteSpace(request.Content))
				throw new ArgumentException("Message content cannot be empty", nameof(request.Content));

			if (_unitOfWork.ChatMessages == null)
				throw new NullReferenceException("_unitOfWork.ChatMessages is not initialized.");

			var conversationId = ConversationHelper.GenerateConversationId(request.SenderId, request.ReceiverId);

			var message = new ChatMessage
			{
				SenderId = request.SenderId,
				ReceiverId = request.ReceiverId,
				ConversationId = conversationId,
				Content = request.Content,
				CreatedAt = DateTime.Now,
				SentAt = DateTime.Now
			};

			await _unitOfWork.ChatMessages.AddAsync(message);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task<List<ChatContactResponse>> GetChatContactsAsync(long userId)
		{
			var messages = await _unitOfWork.ChatMessages.GetMessagesByUserAsync(userId);

			if (messages == null || !messages.Any())
				return new List<ChatContactResponse>();

			var contactIds = messages
				.Select(m => m.SenderId == userId ? m.ReceiverId : m.SenderId)
				.Distinct()
				.ToList();

			var users = await _unitOfWork.Users.GetUsersByIdsAsync(contactIds);

			return users.Select(u => new ChatContactResponse
			{
				UserId = u.Id,
				FullName = u.Username,
				//AvatarUrl = u.AvatarUrl
			}).ToList();
		}


		public async Task<List<ChatMessageResponse>> GetConversationAsync(long userId1, long userId2)
		{
			var conversationId = ConversationHelper.GenerateConversationId(userId1, userId2);
			var messages = await _unitOfWork.ChatMessages
				.GetMessagesByConversationIdAsync(conversationId);

			return messages.Adapt<List<ChatMessageResponse>>();
		}
		public async Task<bool> MarkMessagesAsReadAsync(long currentUserId, List<long> messageIds)
		{
			if (messageIds == null || !messageIds.Any())
				return false;

			var messages = await _unitOfWork.ChatMessages.GetUnreadMessagesByIdsAsync(messageIds, currentUserId);

			if (messages == null || !messages.Any())
			{
				return false; // Không có tin nhắn cần cập nhật
			}

			foreach (var msg in messages)
			{
				msg.IsRead = true;
				msg.ReadAt = DateTime.Now;
			}

			await _unitOfWork.SaveChangesAsync();
			return true;
		}



	}
}
