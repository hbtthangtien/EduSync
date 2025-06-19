using Application.Interfaces.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class ChatMessageRepository : BaseRepository<ChatMessage>, IChatMessageRepository
	{
		public ChatMessageRepository(EduSyncContext context) : base(context)
		{
		}
		public async Task AddAsync(ChatMessage message)
		{
			await _context.ChatMessages.AddAsync(message);
		}

		public async Task<List<ChatMessage>> GetMessagesByConversationIdAsync(string conversationId)
		{
			return await _context.ChatMessages
				.Where(m => m.ConversationId == conversationId)
				.OrderBy(m => m.SentAt)
				.ToListAsync();
		}
	}
}
