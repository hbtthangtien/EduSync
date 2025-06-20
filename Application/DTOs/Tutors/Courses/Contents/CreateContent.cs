using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Tutors.Courses.Contents
{
	public class CreateContent
	{
		public long CourseId { get; set; }

		public string Descriptions { get; set; }

		public string ContentType { get; set; }
	}
}
