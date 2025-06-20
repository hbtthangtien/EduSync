using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ActivationRequest
{
	public class CreateActivationRequest
	{
		public long CourseId { get; set; }
		
		public long TutorId { get; set; }
		public string Fullname { get; set; } = null!;
		public string Introduces { get; set; } = null!;
		public string Specializations { get; set; } = null!;

	}
}
