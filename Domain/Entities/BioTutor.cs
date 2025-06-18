using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class BioTutor : BaseEntity
	{
		public long TutorId { get; set; }

		public string Fullname { get; set; }

		public string Specializations {  get; set; }

		public string Introduces { get; set; }

		public Tutor? Tutor { get; set; }
	}
}
