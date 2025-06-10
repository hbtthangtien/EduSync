using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Slot : BaseEntity
	{
		public long Id { get; set; }
		public long CourseId { get; set; }
		public long TutorId { get; set; }
		public long? StudentId { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		public bool IsBooked { get; set; }
		public bool IsTrial { get; set; }

		public Course Course { get; set; }
		public Tutor Tutor { get; set; }
		public Student Student { get; set; }
	}
}
