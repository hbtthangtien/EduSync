using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class ActivationRequest : BaseEntity
	{
		public long TutorUserId { get; set; }
		public long? CourseId { get; set; }
		public DateTime RequestDate { get; set; }
		public DateTime? ActivationDate { get; set; }
		public bool IsActivated { get; set; }
		public string Fullname { get; set; } 
		public string Specializations { get; set; } 
		public string Introduces { get; set; }
		public Course? Course { get; set; }
	}
}
