using Application.DTOs.BioTutor;
using Application.DTOs.Cousre;
using Application.Interfaces.IService;
using Application.IUnitOfWorks;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class CourseService : ICousreService
	{
		private readonly IUnitOfWork _unitOfWorks;
		public CourseService( IUnitOfWork unitOfWorks)
		{
			_unitOfWorks = unitOfWorks;
		}

		public async Task<CourseDetailDTO?> GetCourseDetailByIdAsync(long courseId)
		{
			var course = await _unitOfWorks.Courses
			.GetInstance()
			.Include(c => c.CreatedByTutor)
			.ThenInclude(t => t.BioTutor)
			.Include(c => c.Contents)
			.FirstOrDefaultAsync(c => c.Id == courseId);

			if (course == null)
				return null;

			var dto = new CourseDetailDTO
			{
				Title = course.Title,
				Description = course.Description,
				TutorBio = new BioTutorDTO
				{
					FullName = course.CreatedByTutor?.BioTutor?.Fullname ?? "Chưa cập nhật",
					Introduces = course.CreatedByTutor?.BioTutor?.Introduces ?? "Chưa có mô tả"
				},
				IsTrialAvailable = course.IsTrialAvailable,
				TrialSessions = course.TrialSessions,
				PricePerSession = course.PricePerSession
			};

			return dto;
		}
	}
}
