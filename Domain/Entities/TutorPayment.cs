using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class TutorPayment : BaseEntity
	{
		public long Id { get; set; }
		public long TutorId { get; set; }
		public long PaymentId { get; set; }
		public decimal Amount { get; set; }
		public DateTime PaymentDate { get; set; }
		public string Status { get; set; } 

		public Tutor Tutor { get; set; }
		public Payment Payment { get; set; }
	}
}
