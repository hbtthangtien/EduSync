using Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Tutor : BaseEntityNoId
	{
		public BioTutor? BioTutor { get; set; }
		public User User { get; set; }
		[Key, ForeignKey("User")]
		public long UserId { get; set; }
		public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
		public ICollection<Course> Courses { get; set; } = new List<Course>();
		public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
		public ICollection<Student> Students { get; set; } = new List<Student>();
		public ICollection<Slot> Slots { get; set; } = new List<Slot>();
		public ICollection<ActivationRequest> ActivationRequests { get; set; } = new List<ActivationRequest>();
	}
}
