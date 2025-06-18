using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class User : BaseEntity
	{
		public long RoleId { get; set; } 
		public string Email { get; set; }
		public string Username { get; set; }
		public string PasswordHash { get; set; }
		public Role? Role { get; set; }
		public Tutor? Tutor { get; set; }
		public Student? Student { get; set; }
		public ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
		public ICollection<Payment> Payments { get; set; } = new List<Payment>();
	}
}
