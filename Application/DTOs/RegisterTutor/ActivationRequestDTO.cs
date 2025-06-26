using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.RegisterTutor
{
	public class ActivationRequestDTO
	{
		public long RequestId { get; set; }
		public long? TutorUserId { get; set; }
		public long? CourseId { get; set; }
		public string Fullname { get; set; }
		public string Specializations { get; set; }
		public string Introduces { get; set; }
		public bool IsActivated { get; set; }
		public DateTime? ActivationDate { get; set; }
		public DateTime CreatedAt { get; set; }
		public List<string> CertificateUrls { get; set; }
		public CourseStatus? CourseStatus { get; set; }
	}
}
