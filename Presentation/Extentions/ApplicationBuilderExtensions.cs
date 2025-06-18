using Persistence.DatabaseConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseExtensions
{
	public static class ApplicationBuilderExtensions
	{
		public static async Task SeedInitialDataAsync(this IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<EduSyncContext>();
			await DbSeeder.SeedRolesAsync(dbContext);
		}
	}
}
