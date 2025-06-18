using Application.DTOs.Commons;
using Application.DTOs.Tutors.Bio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IService
{
	public interface ITutorService
	{
		public Task<IdResponse> UpdateBioTutors(BioUpdate request);

		//public Task<>
	}
}
