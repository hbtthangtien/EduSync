using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Tutors.Dashboard
{
	public class DashboardOfTutors
	{
		public int Slots {  get; set; }

		public int TotalStudents { get; set; }

		public int TotalNewMessage { get; set; }

		public double IncomePerMonth { get; set; }

		public double Overalls { get; set; }

		public List<string> UpcomingSchedules { get; set; } = new List<string>();

		
	}
}
