using Application.DTOs.Tutors.Bio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Cousre
{
    public class CourseDetailDTO
	{
		public string Title { get; set; }
		public string Description { get; set; }

		public BioTutorDTO TutorBio { get; set; }

		public List<string> Contents { get; set; }

		public bool IsTrialAvailable { get; set; }
		public long TrialSessions { get; set; }
		public double PricePerSession { get; set; }

		public List<string> CourseContents { get; set; }

	}


}
