using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Tutors.Courses
{
	public class CreateCourse
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public double PricePerSession { get; set; }

		public IFormFile FrontImage { get; set; }

		public IFormFile BackImage { get; set; }
	}
}
