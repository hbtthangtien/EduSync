using Domain.Commons;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Payment : BaseEntity
	{
		public long UserId { get; set; }
		public long? CourseId { get; set; }
		public long? CourseCancellationId { get; set; }
		public decimal Amount { get; set; }
		public DateTime TransactionDate { get; set; }
		public PaymentStatus Status { get; set; } 
		public User? User { get; set; }
		public Course? Course { get; set; }
		public CourseCancellation? CourseCancellation { get; set;}
	}
}
