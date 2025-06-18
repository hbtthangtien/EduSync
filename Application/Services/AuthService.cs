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
using Application.DTOs.Token;

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

		private async Task<TokenResponse> GenerateToken(User user, string roleName)
		{
			var secret = _config["Jwt:Token"]
				?? throw new InvalidOperationException("JWT Token is missing in configuration.");

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var claims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), 
				new Claim(ClaimTypes.Name, user.Email),
				new Claim(ClaimTypes.Role, roleName)
			};


			var accessTokenExpiry = DateTime.UtcNow.AddMinutes(30);
			var refreshTokenExpiry = DateTime.UtcNow.AddDays(7);

			var accessToken = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
				issuer: _config["Jwt:ValidIssuer"],
				audience: _config["Jwt:ValidAudience"],
				claims: claims,
				expires: accessTokenExpiry,
				signingCredentials: creds
			));

			var tokenDto = new TokenCreateDTO
			{
				UserId = user.Id,
				Token = accessToken,
				ExpiryDate = accessTokenExpiry,
				RefreshToken = Guid.NewGuid().ToString("N"),
				RefreshTokenExpiry = refreshTokenExpiry
			};

			var userToken = tokenDto.Adapt<UserToken>();
			userToken.CreatedAt = DateTime.UtcNow;

			await _unitOfWorks.UserTokens.AddAsync(userToken);
			await _unitOfWorks.SaveChangesAsync();

			return new TokenResponse
			{
				AccessToken = tokenDto.Token,
				AccessTokenExpiry = tokenDto.ExpiryDate,
				RefreshToken = tokenDto.RefreshToken,
				RefreshTokenExpiry = tokenDto.RefreshTokenExpiry
			};
		}



		public async Task<BaseResponse<TokenResponse>> LoginAsync(LoginDTO loginDto)
		{
			var user = await _unitOfWorks.Users.GetByUserAsync(loginDto.Email);
			if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
				return BaseResponse<TokenResponse>.Failure("Sai thông tin đăng nhập");

			var role = await _unitOfWorks.Roles.GetByIdAsync(user.RoleId);
			var token = await GenerateToken(user, role?.Name ?? "User");

			return BaseResponse<TokenResponse>.SuccessResponse(token, null, "Đăng nhập thành công");
		}


		public async Task<BaseResponse<object>> RegisterAsync(RegisterDTO registerDto)
		{
			if (await _unitOfWorks.Users.GetByUserAsync(registerDto.Email) is not null)
				return BaseResponse<object>.Failure("Email đã tồn tại");

			var newUser = registerDto.Adapt<User>();
			newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
			newUser.CreatedAt = DateTime.UtcNow;
			newUser.RoleId = 3; 

			await _unitOfWorks.Users.AddAsync(newUser);
			await _unitOfWorks.SaveChangesAsync();

			await _unitOfWorks.Students.AddAsync(new Student
			{
				User = newUser,                       
				RegistrationDate = DateTime.UtcNow,
				CreatedAt = DateTime.UtcNow           
			});

			await _unitOfWorks.SaveChangesAsync();

			return BaseResponse<object>.SuccessResponse(
				new { UserId = newUser.Id },
				message: "Đăng ký thành công"
			);
		}

		public async Task<BaseResponse<string>> LogoutAsync(string token)
		{
			var existingToken = await _unitOfWorks.UserTokens
				.FirstOrDefaultAsync(t => t.RefreshToken == token);

			if (existingToken == null)
				return BaseResponse<string>.Failure("Token không hợp lệ hoặc đã bị thu hồi.");

			_unitOfWorks.UserTokens.RemoveAsync(existingToken);
			await _unitOfWorks.SaveChangesAsync();

			return BaseResponse<string>.SuccessResponse(null, null, "Đăng xuất thành công");
		}

	}
}
