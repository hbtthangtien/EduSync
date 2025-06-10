using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class CourseCancellation : BaseEntity
	{
		public long Id { get; set; }
		public long StudentId { get; set; }
		public long PaymentId { get; set; }
		public string Reason { get; set; }
		public string BankAccountName { get; set; }
		public string BankName { get; set; }
		public DateTime CancellationDate { get; set; }
		public bool IsRefunded { get; set; }

		public Student Student { get; set; }
		public Payment Payment { get; set; }
	}
}
