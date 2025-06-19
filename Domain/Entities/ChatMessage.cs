using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class ChatMessage
	{
		public long Id { get; set; }
		public string ConversationId { get; set; } 
		public long SenderId { get; set; }
		public long ReceiverId { get; set; }
		public string Content { get; set; }
		public DateTime SentAt { get; set; }

		public User Sender { get; set; }
		public User Receiver { get; set; }
	}
}
