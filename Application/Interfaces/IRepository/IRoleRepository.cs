using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepository
{
	public interface IRoleRepository : IBaseRepository<Role>
	{
		Task<Role> GetByIdAsync(long id);
		Task<string?> GetRoleNameAsync(long id);
	}
}
