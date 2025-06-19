using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepository
{
	public interface IChatMessageRepository :IBaseRepository<ChatMessage>
	{
		Task AddAsync(ChatMessage message);
		Task<List<ChatMessage>> GetMessagesByConversationIdAsync(string conversationId);
	}
}
