using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.RegisterTutor
{
	public class RegisterTutorDTO
	{
		public string Fullname { get; set; }
		public string Specializations { get; set; }
		public string Introduces { get; set; }
		public IFormFile CertificateFile { get; set; }
		
	}
}
