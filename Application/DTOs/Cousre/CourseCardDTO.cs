using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Cousre
{
	public class CourseCardDTO
	{
		public long CourseId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string TutorName { get; set; }
	}

}
