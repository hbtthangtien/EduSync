using Application.DTOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Tutors.Bio
{
	public class BioUpdate
	{
		public long UserId {  get; set; }
		public string? FullName { get; set; }

		public string? Specializations { get; set; }

		public string? Introduces { get; set; }
	}
}
