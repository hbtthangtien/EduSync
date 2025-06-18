using Application.DTOs.Cousre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IService
{
	public interface ICousreService
	{
		Task<CourseDetailDTO?> GetCourseDetailByIdAsync(long courseId);
	}
}
