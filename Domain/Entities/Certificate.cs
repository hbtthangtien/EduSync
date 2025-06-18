using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Certificate : BaseEntity
	{
		public long TutorId { get; set; }
		public long CourseId { get; set; }
		public string CertificateUrl { get; set; }
		public bool IsVerified { get; set; }
		public DateTime? VerifiedDate { get; set; }
		public Tutor? Tutor { get; set; }
		public Course? Course { get; set; }
	}
}
