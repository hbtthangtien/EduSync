using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseExtensions
{
	public static class DbSeeder_SeedingTutorsAndCourse
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			// Cấu hình precision cho decimal
			modelBuilder.Entity<Course>()
				.Property(c => c.ServiceFeePercentage)
				.HasPrecision(5, 2);

			modelBuilder.Entity<Payment>()
				.Property(p => p.Amount)
				.HasPrecision(18, 2);

			// Cấu hình chuyển đổi TimeSpan cho DurationSession
			modelBuilder.Entity<Slot>()
				.Property(s => s.DurationSession)
				.HasConversion(
					v => v.Ticks,
					v => TimeSpan.FromTicks(v)
				);

			// Dùng thời gian cố định để tránh lỗi PendingModelChangesWarning
			var createdDate = new DateTime(2025, 1, 1, 9, 0, 0);

			// Seed Role
			modelBuilder.Entity<Role>().HasData(
				new Role { Id = 1, Name = "Admin", CreatedAt = createdDate, UpdatedAt = createdDate },
				new Role { Id = 2, Name = "Tutor", CreatedAt = createdDate, UpdatedAt = createdDate },
				new Role { Id = 3, Name = "Student", CreatedAt = createdDate, UpdatedAt = createdDate }
			);

			// Seed User
			modelBuilder.Entity<User>().HasData(
				new User
				{
					Id = 1,
					Email = "tutor1@example.com",
					Username = "tutor1",
					PasswordHash = "hashedpassword",
					RoleId = 2,
					CreatedAt = createdDate
				},
				new User
				{
					Id = 2,
					Email = "student1@example.com",
					Username = "student1",
					PasswordHash = "hashedpassword",
					RoleId = 3,
					CreatedAt = createdDate
				}
			);

			// Seed Tutor
			modelBuilder.Entity<Tutor>().HasData(
				new Tutor
				{
					UserId = 1,
					CreatedAt = createdDate
				}
			);

			// Seed Student
			modelBuilder.Entity<Student>().HasData(
				new Student
				{
					UserId = 2,
					CreatedAt = createdDate
				}
			);

			// Seed 10 IELTS Courses
			var courses = Enumerable.Range(1, 10).Select(i => new Course
			{
				Id = i,
				Title = $"IELTS Preparation Course {i}",
				Description = "A comprehensive IELTS preparation course covering Listening, Reading, Writing, and Speaking.",
				CreatedByTutorId = 1,
				IsTrialAvailable = true,
				TrialSessions = 2,
				PricePerSession = 150,
				ServiceFeePercentage = 10,
				Status = CourseStatus.Published,
				CreatedAt = createdDate
			});
			modelBuilder.Entity<Course>().HasData(courses);

			// Seed 2 Slots per Course => 20 slots, assign student to even slots
			var slots = new List<Slot>();
			int slotId = 1;
			for (int i = 1; i <= 10; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					slots.Add(new Slot
					{
						Id = slotId,
						CourseId = i,
						TutorId = 1,
						StudentId = slotId % 2 == 0 ? 1 : null,
						NumberOfSlot = 1,
						DurationSession = new TimeSpan(0, 1, 30, 0),
						StartTime = createdDate.AddDays(j),
						IsBooked = slotId % 2 == 0,
						IsTrial = j == 0,
						MeetUrl = $"https://meetlink.com/ielts-{i}-slot{j + 1}",
						CreatedAt = createdDate
					});
					slotId++;
				}
			}
			modelBuilder.Entity<Slot>().HasData(slots);

			// Seed 30 Content per Course => 300 content
			var contents = new List<Content>();
			int contentId = 1;
			for (int i = 1; i <= 10; i++)
			{
				for (int j = 1; j <= 30; j++)
				{
					contents.Add(new Content
					{
						Id = contentId++,
						CourseId = i,
						ContentType = j % 2 == 0 ? "Document" : "Video",
						Descriptions = $"IELTS Lesson {j} for Course {i}.",
						CreatedAt = createdDate
					});
				}
			}
			modelBuilder.Entity<Content>().HasData(contents);

			// Seed 30 WeeklySchedules per Slot => 600 schedules
			var weeklySchedules = new List<WeeklySchedule>();
			int scheduleId = 1;
			for (int i = 1; i <= 20; i++) // 20 slots total
			{
				for (int j = 0; j < 30; j++)
				{
					weeklySchedules.Add(new WeeklySchedule
					{
						Id = scheduleId++,
						CourseId = slots[i - 1].CourseId,
						SlotId = i,
						DayOfWeek = (DayOfWeek)(j % 7),
						CreatedAt = createdDate
					});
				}
			}
			modelBuilder.Entity<WeeklySchedule>().HasData(weeklySchedules);
		}
	}
}
