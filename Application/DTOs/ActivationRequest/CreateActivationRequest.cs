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

		
	}
}
