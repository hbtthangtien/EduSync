using Application.DTOs.Cousre;
using Application.DTOs.Tutors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Home
{
	public class HomePageDTO
	{
		public List<TutorCardDTO> Tutors { get; set; }
		public HomeStatsDTO Stats { get; set; }
		public List<CourseCardDTO> FeaturedCourses { get; set; }
	}
}
