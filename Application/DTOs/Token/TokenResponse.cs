using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Token
{
	public class TokenResponse
	{
		public string AccessToken { get; set; } = string.Empty;
		public DateTime AccessTokenExpiry { get; set; }
		public string RefreshToken { get; set; } = string.Empty;
		public DateTime RefreshTokenExpiry { get; set; }
	}
}
