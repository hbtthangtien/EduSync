using Domain.Commons;

namespace Domain.Entities
{
	public class Slot : BaseEntity
	{
		public long CourseId { get; set; }
		public long TutorId { get; set; }
		public long? StudentId { get; set; }
		public short NumberOfSlot {  get; set; }
		public TimeSpan DurationSession {  get; set; }
		public bool IsBooked { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime =>  StartTime.AddMinutes(DurationSession.TotalMinutes);
		public bool IsTrial { get; set; }
		public string MeetUrl { get; set; }
		public Course? Course { get; set; }
		public Tutor? Tutor { get; set; }
		public Student? Student { get; set; }
		public ICollection<WeeklySchedule> WeeklySchedules { get; set; } = new List<WeeklySchedule>();
	}
}
