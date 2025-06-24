using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Tutors.Slots
{
	public class CreateSlot
	{
		public List<DayOfWeek> DayOfWeeks { get; set; } = new List<DayOfWeek>();

		public DateTime StartTime { get; set; }

		public string MeetUrl { get; set; }

		public string StudentEmail { get; set; }

		public long CourseId { get; set; }

		public short NumberOfSession {  get; set; }
	}
}
