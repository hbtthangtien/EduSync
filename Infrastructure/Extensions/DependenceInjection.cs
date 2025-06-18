using Application.Interfaces.IService;
using Application.Services;
using Domain.Configs;
using Infrastructure.ExternalServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
	public static class DependenceInjection
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddHttpContextAccessor();
			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<IUserContextService, UserContextService>();
		}
		public static void AddAuthenticationByJwt(this IServiceCollection services, IConfiguration configuration)
		{
			var jwt = configuration.GetSection("Jwt").Get<JwtConfigs>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var key = Encoding.UTF8.GetBytes(jwt.Token);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwt.ValidateIssuer,
                    ValidIssuer = jwt.ValidIssuer,
                    ValidateAudience = jwt.ValidateAudience,
                    ValidAudience = jwt.ValidAudience,
                    ValidateLifetime = jwt.ValidateLifetime,
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuerSigningKey = jwt.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
		}
		public static IServiceCollection AddConfiguredControllers(this IServiceCollection services)
		{
			services.AddControllers()
				.AddJsonOptions(options =>
				{
					options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
				});

			return services;
		}
		public static void InitialValueConfig(this IServiceCollection services, IConfiguration configuration)
		{
			var jwtConfig = configuration.GetSection("JwtConfig");
			services.Configure<JwtConfigs>(jwtConfig);
		}
		
	}
}
