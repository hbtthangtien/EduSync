using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Token
{
	public class TokenCreateDTO
	{
		public long UserId { get; set; }
		public string Token { get; set; } = string.Empty;
		public DateTime ExpiryDate { get; set; }
		public string RefreshToken { get; set; } = string.Empty;
		public DateTime RefreshTokenExpiry { get; set; }
	}

}
