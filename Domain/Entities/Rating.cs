using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Rating : BaseEntity
	{
		public long Id { get; set; }
		public long TutorId { get; set; }
		public double Score { get; set; }
		public string Comment { get; set; }
		public DateTime CreatedDate { get; set; }

		public Tutor Tutor { get; set; }
	}
}
