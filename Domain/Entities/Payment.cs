using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Payment : BaseEntity
	{
		public long Id { get; set; }
		public long UserId { get; set; }
		public decimal Amount { get; set; }
		public DateTime TransactionDate { get; set; }
		public string Status { get; set; } // Pending, Completed, Refunded
		public string QRCodeUrl { get; set; }

		public User User { get; set; }
	}
}
