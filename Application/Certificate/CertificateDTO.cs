using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Certificate
{
	public class CertificateDTO
	{
		public string CertificateUrl { get; set; }
		public bool IsVerified { get; set; }
		public DateTime? VerifiedDate { get; set; }
	}

}
