using Application.Interfaces.IRepository;
using Application.Interfaces.IService;
using Application.IUnitOfWorks;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseConfigs;
using Persistence.Repositories;
using Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseExtensions
{
	public static class DependenceInjection
	{
		public static void AddDatabaseInjection(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<EduSyncContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("localmssql"));
			});
		}

		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IRoleRepository, RoleRepository>();
			services.AddScoped<IStudentRepository, StudentRepository>();
			services.AddScoped<ITuTorRepository, TuTorRepository>();
			services.AddScoped<IAuthService, AuthService>();

			//unit of work
			services.AddScoped<IUnitOfWork, UnitOfWork>();
		}

	}
}
