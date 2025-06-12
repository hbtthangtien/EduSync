using Application.DTOs.Commons;
using Application.DTOs.Login;
using Application.DTOs.Register;
using Application.Interfaces.IService;
using Application.IUnitOfWorks;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Mapster;

namespace Application.Services
{
	public class AuthService : IAuthService
	{
		private readonly IConfiguration _config;
		private readonly IUnitOfWork _unitOfWorks;

		public AuthService(IConfiguration config, IUnitOfWork unitOfWorks)
		{
			_config = config;
			_unitOfWorks = unitOfWorks;
		}

		private string GenerateToken(User user, string roleName)
		{
			var key = Encoding.UTF8.GetBytes(_config["Jwt:super_secret_key_123456"]);
			var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim(ClaimTypes.Name, user.Email),
				new Claim(ClaimTypes.Role, roleName)
			};

			var token = new JwtSecurityToken(
				issuer: _config["Jwt:EduSyncIssuer"],
				audience: _config["Jwt:EduSyncAudience"],
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(60),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public async Task<BaseResponse<string>> LoginAsync(LoginDTO loginDto)
		{
			var user = await _unitOfWorks.User.GetByUserAsync(loginDto.Username);
			if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
				return BaseResponse<string>.Failure("Sai thông tin đăng nhập");

			var role = await _unitOfWorks.Role.GetByIdAsync(user.RoleId);
			var token = GenerateToken(user, role?.Name ?? "User");

			return BaseResponse<string>.SuccessResponse(token, null, "Đăng nhập thành công");
		}

		public async Task<BaseResponse<object>> RegisterAsync(RegisterDTO registerDto)
		{
			if (await _unitOfWorks.User.GetByUserAsync(registerDto.Email) is not null)
				return BaseResponse<object>.Failure("Email đã tồn tại");

			if (registerDto.RoleId is not (2 or 3))
				return BaseResponse<object>.Failure("Vai trò không hợp lệ (chỉ chấp nhận Tutor hoặc Student)");

			// using Mapster map DTO and Entity
			var newUser = registerDto.Adapt<User>();
			newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
			newUser.CreatedAt = DateTime.UtcNow;

			await _unitOfWorks.User.AddAsync(newUser);

			switch (registerDto.RoleId)
			{
				case 2:
					await _unitOfWorks.TuTor.AddAsync(new Tutor { UserId = newUser.Id, CreatedAt = DateTime.UtcNow });
					break;
				case 3:
					await _unitOfWorks.Student.AddAsync(new Student { UserId = newUser.Id, CreatedAt = DateTime.UtcNow });
					break;
			}

			await _unitOfWorks.SaveChangesAsync();

			return BaseResponse<object>.SuccessResponse(
				new { UserId = newUser.Id },
				message: "Đăng ký thành công"
			);
		}
	}
}
