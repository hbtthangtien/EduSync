using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ChatMesseage
{
	public class SendMessageRequest
	{
		public long SenderId { get; set; }
		public long ReceiverId { get; set; }
		public string Content { get; set; }
	}
}
