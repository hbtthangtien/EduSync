using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User
{
	public class AdminDashboardReportDTO
	{
		public int TotalUsers { get; set; }
		public int TotalStudents { get; set; }
		public int TotalCourses { get; set; }
		public decimal MonthlyRevenue { get; set; }

		public string MostPopularCourseName { get; set; } = "";
		public int MostPopularCourseStudentCount { get; set; }

		public List<DashboardCourseSummaryDTO> RecentCourses { get; set; } = new();
	}

	public class DashboardCourseSummaryDTO
	{
		public string Title { get; set; } = "";
		public string TutorName { get; set; } = "";
		public int StudentCount { get; set; }
	}
}
