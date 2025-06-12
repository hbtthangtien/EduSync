using Application.Interfaces.IRepository;
using Application.IUnitOfWorks;
using Persistence.DatabaseConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly EduSyncContext _context;
		public IUserRepository User { get; private set; }
		public IRoleRepository Role { get; private set; }
		public IStudentRepository Student { get; private set; }
		public ITuTorRepository TuTor { get; private set; }

		public UnitOfWork(EduSyncContext context,
			IUserRepository userRepository, IStudentRepository studentRepository,
			IRoleRepository roleRepository, ITuTorRepository tutorRepository)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			User = userRepository;
			Role = roleRepository;
			Student = studentRepository;
			TuTor = tutorRepository;
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();

		}
	}


}
