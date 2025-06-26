using Application.DTOs.Commons;
using Application.DTOs.Cousre;
using Application.DTOs.Tutors.Courses;
using Application.DTOs.Tutors.Courses.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IService
{
	public interface ICourseService
	{
		Task<CourseDetailDTO?> GetCourseDetailByIdAsync(long courseId);
		Task<List<CourseDTO>> GetAllCoursesAsync();
		Task<BaseResponse<ResponseCreateCourse>> CreateCourseAsync(long tutorId, CreateCourse create);
		Task CreateContentForCourse(long courseId, List<CreateContent> listContent);
		Task<BaseResponse<List<CourseCreateSlot>>> GetAllCoursePublish(long tutorId);

	}
}
