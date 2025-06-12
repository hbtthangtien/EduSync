using Persistence.DatabaseConfigs;
using Infrastructure.Extensions;
using Persistence.DatabaseExtensions;
using Microsoft.EntityFrameworkCore;

namespace Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDatabaseInjection(builder.Configuration);
			builder.Services.AddRepositories();
			builder.Services.AddAuthenticationByJwt(builder.Configuration);
			builder.Services.InitialValueConfig(builder.Configuration);
			builder.Services.AddServices();
			builder.Services.AddConfiguredControllers();
			builder.Services.AddDbContext<EduSyncContext>(options =>
			{
			options.UseSqlServer(builder.Configuration.GetConnectionString("localmssql"));
			});
			var app = builder.Build();

			//seed initial data_role
			await app.SeedInitialDataAsync();
			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.MapControllers();
            app.Run();
        }
    }
}
