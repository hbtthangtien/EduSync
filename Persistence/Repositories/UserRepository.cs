using Application.Interfaces.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(EduSyncContext context) : base(context) { }


		public async Task AddAsync(User entity)
		{
			await _context.Users.AddAsync(entity);
		}

		public bool Exists(string username)
		{
			throw new NotImplementedException();
		}

		public async Task<User?> GetByUserAsync(string username)
		{
			return await _context.Users
				.Include(u => u.Role)
				.FirstOrDefaultAsync(u => u.Email == username);
		}


	}
}
