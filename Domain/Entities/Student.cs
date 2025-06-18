using Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
	public class Student : BaseEntityNoId
	{
		public DateTime RegistrationDate { get; set; }
		[Key, ForeignKey("User")]
		public long UserId { get; set; }
		public User? User { get; set; }
		public ICollection<CourseCancellation> CourseCancellations { get; set; } = new List<CourseCancellation>();
		public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
		public ICollection<Slot> Slots { get; set; } = new List<Slot>();
	}
}
