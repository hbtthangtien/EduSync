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
	public class RoleRepository : BaseRepository<Role>, IRoleRepository
	{
		public RoleRepository(EduSyncContext context) : base(context) { }

		public async Task<Role> GetByIdAsync(long id)
		{
			return await _context.Roles.FindAsync(id);
		}

		public async Task<string?> GetRoleNameAsync(long id)
		{
			var role = await _context.Roles.FindAsync(id);
			return role?.Name;
		}

	}
}
