using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Tutors
{
	public class TutorDTO
	{
		public long Id { get; set; }
		public string FullName { get; set; }
		public string Introduces { get; set; } = "Chưa có mô tả";
		public List<string> Specializations { get; set; } = new();
		public double Rating { get; set; }
	}
}
