using Domain.Entities;
using Persistence.DatabaseConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.DatabaseExtensions
{
	public static class DbSeeder
	{
		public static async Task SeedRolesAsync(EduSyncContext context)
		{
			if (!await context.Roles.AnyAsync())
			{
				var now = DateTime.UtcNow;

				var roles = new List<Role>
				{
					new Role { Name = "Admin", CreatedAt = now, UpdatedAt = now },
					new Role { Name = "Tutor", CreatedAt = now, UpdatedAt = now },
					new Role { Name = "Student", CreatedAt = now, UpdatedAt = now }
				};

				await context.Roles.AddRangeAsync(roles);
				await context.SaveChangesAsync();
				Console.WriteLine("[Seed] Roles inserted successfully.");
			}
			else
			{
				Console.WriteLine("[Seed] Roles already exist.");
			}
		}
	}
}
