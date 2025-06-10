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
		public long Id { get; set; }
		public long? RoleId { get; set; } 
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public DateTime CreatedDate { get; set; }

		public Role Role { get; set; }
	}
}
