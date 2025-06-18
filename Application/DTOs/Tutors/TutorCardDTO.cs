using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Tutors
{
	public class TutorCardDTO
	{
		public long TutorId { get; set; }
		public string FullName { get; set; }
		public string AvatarUrl { get; set; }
		public string Specializations { get; set; }
		public string Bio { get; set; }
		public double AverageRating { get; set; }
	}
}
