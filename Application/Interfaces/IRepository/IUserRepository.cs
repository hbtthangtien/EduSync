using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepository
{
	public interface IUserRepository : IBaseRepository<User>
	{
		Task<User?> GetByUserAsync(string username);
		bool Exists(string username);
	}
}
