using Application.DTOs.Commons;
using Application.DTOs.Tutors;
using Application.DTOs.Tutors.Bio;
using Application.DTOs.Tutors.Courses;
using Application.DTOs.Tutors.Dashboard;
using Application.DTOs.Tutors.Slots;
using Application.DTOs.Tutors.Students;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IService
{
	public interface ITutorService
	{
		public Task<IdResponse> UpdateBioTutors(BioUpdate request);
		Task<List<TutorDTO>> GetAllTutorsAsync();
		Task<BaseResponse<List<SlotTutorDTO>>> GetSlotsBytutorAsync(long tutorId);
		Task<BaseResponse<List<StudentInCourse>>> GetStudentsByCourseId(long tutorId, long courseId);	
		Task<BaseResponse<List<StudentInCourse>>> GetAllStudentInAllCourse(long tutorId);
		Task<BaseResponse<List<CourseTutors>>> GetAllCourseOfTutors(long tutorId);
		Task<BaseResponse<DashboardOfTutors>> ReportOftutors(long tutorId);
	}
}
