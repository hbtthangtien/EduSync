using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Course : BaseEntity
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public long CreatedByTutorId { get; set; }
		public bool IsTrialAvailable { get; set; }
		public long TrialSessions { get; set; }
		public decimal ServiceFeePercentage { get; set; }

		public Tutor CreatedByTutor { get; set; }
		public ICollection<Content> Contents { get; set; }
		public ICollection<Slot> Slots { get; set; }
		public ICollection<WeeklySchedule> WeeklySchedules { get; set; }
	}
}
