using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Home
{
	public class HomeStatsDTO
	{
		public int TotalStudents { get; set; }
		public int TotalTutors { get; set; }
		public int TotalCourses { get; set; }
		public double AverageRating { get; set; }
	}

}
