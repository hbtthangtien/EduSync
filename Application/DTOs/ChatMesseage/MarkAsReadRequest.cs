using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ChatMesseage
{
	public class MarkAsReadRequest
	{
		public List<long> MessageIds { get; set; }
	}
}
