using Application.DTOs.Commons;
using Application.DTOs.Cousre;
using Application.DTOs.Tutors.Courses;
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
		Task<IdResponse> CreateCourseAsync(long tutorId, CreateCourse create);
	}
}
