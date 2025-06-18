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
	public class UserTokenRepository : BaseRepository<UserToken>, IUserTokenRepository
	{
		public UserTokenRepository(EduSyncContext context) : base(context) { }

		public async Task<UserToken?> FirstOrDefaultAsync(Expression<Func<UserToken, bool>> predicate)
		{
			return await _context.UserTokens.FirstOrDefaultAsync(predicate);
		}

	}
}
