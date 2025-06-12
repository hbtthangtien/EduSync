using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseConfigs
{
	public class EduSyncContextFactory : IDesignTimeDbContextFactory<EduSyncContext>
	{
		public EduSyncContext CreateDbContext(string[] args)
		{
			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var optionsBuilder = new DbContextOptionsBuilder<EduSyncContext>();
			optionsBuilder.UseSqlServer(config.GetConnectionString("localmssql"));

			return new EduSyncContext(optionsBuilder.Options);
		}
	}

}
