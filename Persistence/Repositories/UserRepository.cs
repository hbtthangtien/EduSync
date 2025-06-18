using Application.Interfaces.IRepository;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		public UserRepository(EduSyncContext context, IHttpContextAccessor httpContextAccessor) : base(context)
		{
			_httpContextAccessor = httpContextAccessor;

		}
		public long GetUserId()
		{
			var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (long.TryParse(userIdClaim, out var userId))
				return userId;

			throw new UnauthorizedAccessException("UserId không hợp lệ hoặc chưa đăng nhập.");
		}
		public async Task AddAsync(User entity)
		{
			await _context.Users.AddAsync(entity);
		}

		public bool Exists(string username)
		{
			return _context.Users.Any(u => u.Email == username);
		}

		public async Task<User?> GetByUserAsync(string email)
		{
			return await _context.Users
				.FirstOrDefaultAsync(u => u.Email == email);
		}


	}
}
