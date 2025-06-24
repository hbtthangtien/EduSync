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
			modelBuilder.Entity<Course>()
				.Property(c => c.ServiceFeePercentage)
				.HasPrecision(5, 2);

			modelBuilder.Entity<Payment>()
				.Property(p => p.Amount)
				.HasPrecision(18, 2);

			modelBuilder.Entity<Slot>()
				.Property(s => s.DurationSession)
				.HasConversion(
					v => v.Ticks,
					v => TimeSpan.FromTicks(v)
				);

			var createdDate = new DateTime(2025, 1, 1, 9, 0, 0);

			modelBuilder.Entity<Role>().HasData(
				new Role { Id = 1, Name = "Admin", CreatedAt = createdDate, UpdatedAt = createdDate },
				new Role { Id = 2, Name = "Tutor", CreatedAt = createdDate, UpdatedAt = createdDate },
				new Role { Id = 3, Name = "Student", CreatedAt = createdDate, UpdatedAt = createdDate }
			);		
		}
	}
}
