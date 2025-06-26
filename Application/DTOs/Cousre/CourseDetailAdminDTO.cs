using Application.DTOs.Certifiace;
using Application.DTOs.RegisterTutor;
using Application.DTOs.Tutors.Bio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Cousre
{
	public class CourseDetailAdminDTO
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public BioTutorDTO TutorBio { get; set; }
		public bool IsTrialAvailable { get; set; }
		public long TrialSessions { get; set; }
		public double PricePerSession { get; set; }
		public DateTime CreatedAt { get; set; }
		public List<string> CourseContents { get; set; }

		public List<CertificateDTO> Certificate { get; set; }
		public ActivationRequestDTO? ActivationRequest { get; set; }

	}
}
