using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class WeeklySchedule : BaseEntity
	{
		public long CourseId { get; set; }
		public long SlotId { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public Course? Course { get; set; }
		public Slot? Slot { get; set; }
	}
}
