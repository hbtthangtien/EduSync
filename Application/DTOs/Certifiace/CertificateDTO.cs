using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Certifiace
{
	public class CertificateDTO
	{
		public long Id { get; set; }
		public long TutorId { get; set; }
		public long CourseId { get; set; }
		public string CertificateUrl { get; set; } = string.Empty;
		public bool IsVerified { get; set; }
		public DateTime? VerifiedDate { get; set; }
	}
}
