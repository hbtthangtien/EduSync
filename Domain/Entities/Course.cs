using Domain.Commons;
using Domain.Enums;
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
		public string Title { get; set; }
		public string Description { get; set; }
		public long CreatedByTutorId { get; set; }
		public bool IsTrialAvailable { get; set; }
		public long TrialSessions { get; set; }
		public double PricePerSession { get; set; }
		public decimal ServiceFeePercentage { get; set; }
		public int NumberOfSession {  get; set; }
		public TimeSpan DurationSession { get; set; }
		public CourseStatus Status { get; set; }
		public Tutor? CreatedByTutor { get; set; }
		public ICollection<Content> Contents { get; set; } = new List<Content>();
		public ICollection<Slot> Slots { get; set; } = new List<Slot>();
		public ICollection<WeeklySchedule> WeeklySchedules { get; set; } = new List<WeeklySchedule>();
		public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
		public ICollection<CourseCancellation> CourseCancellations { get; set; } = new List<CourseCancellation>();


	}
}
