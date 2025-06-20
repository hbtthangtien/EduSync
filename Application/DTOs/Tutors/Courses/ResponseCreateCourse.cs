using Application.DTOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Tutors.Courses
{
	public class ResponseCreateCourse : IdRequest
	{
		public int NumberOfSessions {  get; set; }
	}
}
