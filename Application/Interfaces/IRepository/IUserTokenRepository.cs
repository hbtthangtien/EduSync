using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepository
{
	public interface IUserTokenRepository : IBaseRepository<UserToken>
	{
		Task<UserToken?> FirstOrDefaultAsync(Expression<Func<UserToken, bool>> predicate);

	}
}
