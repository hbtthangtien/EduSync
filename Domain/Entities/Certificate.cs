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
		public long Id { get; set; }
		public long TutorId { get; set; }
		public string CertificateUrl { get; set; }
		public bool IsVerified { get; set; }
		public long? VerifiedByAdminId { get; set; }
		public DateTime? VerifiedDate { get; set; }

		public Tutor Tutor { get; set; }
		public User VerifiedByAdmin { get; set; }
	}
}
