using Application.DTOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Tutors.Slots
{
	public class SlotTutorDTO : IdRequest
	{
		public string CourseTitle { get; set; }

		public DateTime Date {  get; set; }

		public List<string> Shifts { get; set; } = new List<string>();	
	}
}
