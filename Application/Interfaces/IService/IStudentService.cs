using Application.DTOs.Commons;
using Application.DTOs.RegisterTutor;
using Application.DTOs.Tutors.Courses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IService
{
	public interface IStudentService
	{
		Task<BaseResponse<string>> RegisterTutorAsync(RegisterTutorDTO registerTutor);
		Task<List<Certificate>> CreateCertificates(long tutorId, RegisterTutorDTO dto);
	}
}
