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
		public long Id { get; set; }
		public long CourseId { get; set; }
		public string DayOfWeek { get; set; }
		public TimeSpan StartTime { get; set; }
		public TimeSpan EndTime { get; set; }

		public Course Course { get; set; }
	}
}
