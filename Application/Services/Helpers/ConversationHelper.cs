using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Helpers
{
	public static class ConversationHelper
	{
		public static string GenerateConversationId(long userId1, long userId2)
		{
			return userId1 < userId2
				? $"{userId1}_{userId2}"
				: $"{userId2}_{userId1}";
		}
	}
}
