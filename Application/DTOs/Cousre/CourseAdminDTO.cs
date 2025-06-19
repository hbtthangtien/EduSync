using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Cousre
{
	public class CourseAdminDTO
	{
		public long Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string TutorName { get; set; } = "Chưa cập nhật";
		public int StudentCount { get; set; }
	}

}
