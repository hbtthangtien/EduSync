using Application.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IUnitOfWorks
{
	public interface IUnitOfWork : IDisposable
	{
		public IUserRepository User {  get; }
		public IRoleRepository Role { get; }
		public	IStudentRepository Student { get; }
		public ITuTorRepository TuTor { get; }
		public IUserTokenRepository UserToken { get; }

		Task<int> SaveChangesAsync();
	}
}
