using Application.DTOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Tutors.Courses
{
	public class CourseTutors : IdRequest
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public int NumberOfStudent {  get; set; }
	}
}
