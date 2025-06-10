using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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
			var optionsBuilder = new DbContextOptionsBuilder<EduSyncContext>();
			optionsBuilder.UseSqlServer("Server=DUONG-MEEP\\MSSQLSERVER01;Database=EduSyncDb;Trusted_Connection=True;TrustServerCertificate=True;");

			return new EduSyncContext(optionsBuilder.Options);
		}
	}
}
