using Application.DTOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Tutors.Students
{
	public class StudentInCourse : IdRequest
	{
		public string StudentName { get; set; }

		public string TitleCourse { get; set; }
	}
}
