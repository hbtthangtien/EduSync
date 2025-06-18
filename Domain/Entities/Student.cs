using Domain.Commons;

namespace Domain.Entities
{
	public class Student : BaseEntity
	{
		public DateTime RegistrationDate { get; set; }	
		public long UserId { get; set; }
		public User? User { get; set; }
		public ICollection<CourseCancellation> CourseCancellations { get; set; } = new List<CourseCancellation>();
		public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
		public ICollection<Slot> Slots { get; set; } = new List<Slot>();
	}
}
