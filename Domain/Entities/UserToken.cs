using Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
		public class UserToken : BaseEntity
		{
			public long UserId { get; set; }
			public User? User { get; set; }

			[Required]
			[MaxLength(500)]
			public string Token { get; set; } = null!;

			public DateTime ExpiryDate { get; set; }
		}
}
