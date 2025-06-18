using Application.DTOs.Cousre;
using Application.DTOs.Home;
using Application.DTOs.Tutors;
using Application.Interfaces.IService;
using Application.IUnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
	public class HomePageService : IHomePageService
	{
		private readonly IUnitOfWork _unitOfWorks;

		public HomePageService(IUnitOfWork unitOfWorks)
		{
			_unitOfWorks = unitOfWorks;
		}

		public async Task<HomePageDTO> GetHomePageDataAsync()
		{
			// Lấy tutors
			var tutors = await _unitOfWorks.TuTors
				.GetInstance()
				.Include(t => t.BioTutor)
				.Include(t => t.User)
				.Include(t => t.Ratings)
				.ToListAsync();

			var tutorCards = tutors.Select(t => new TutorCardDTO
			{
				TutorId = t.UserId,
				FullName = t.BioTutor?.Fullname ?? "Chưa cập nhật",
				Specializations = t.BioTutor?.Specializations ?? "",
				Bio = t.BioTutor?.Introduces ?? "",
				//AvatarUrl = t.User?.AvatarUrl ?? "/images/default-avatar.png",
				AverageRating = t.Ratings.Any() ? t.Ratings.Average(r => r.Score) : 0
			}).ToList();

			var totalStudents = await _unitOfWorks.Students.CountAsync();
			var totalTutors = await _unitOfWorks.TuTors.CountAsync();
			var totalCourses = await _unitOfWorks.Courses.CountAsync();
			var allRatings = await _unitOfWorks.Ratings.GetAllAsync().ToListAsync();
			var avgRating = allRatings.Any() ? allRatings.Average(r => r.Score) : 0;

			var featuredCourses = await _unitOfWorks.Courses
				.GetInstance()
				.Include(c => c.CreatedByTutor)
				.ThenInclude(t => t.BioTutor)
				.OrderByDescending(c => c.CreatedAt)
				.Take(5)
				.ToListAsync();

			var courseCards = featuredCourses.Select(c => new CourseCardDTO
			{
				CourseId = c.Id,
				Title = c.Title,
				Description = c.Description,
				TutorName = c.CreatedByTutor?.BioTutor?.Fullname ?? "Không rõ"
			}).ToList();

			return new HomePageDTO
			{
				Tutors = tutorCards,
				Stats = new HomeStatsDTO
				{
					TotalStudents = totalStudents,
					TotalTutors = totalTutors,
					TotalCourses = totalCourses,
					AverageRating = Math.Round(avgRating, 1)
				},
				FeaturedCourses = courseCards
			};
		}

	}

}
