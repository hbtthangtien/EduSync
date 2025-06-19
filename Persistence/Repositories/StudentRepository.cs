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
	public class StudentRepository : BaseRepository<Student>, IStudentRepository
	{
		public StudentRepository(EduSyncContext context) : base(context) { }
		public async Task<Student?> FindAsync(Expression<Func<Student, bool>> predicate)
		{
			return await _context.Students.FirstOrDefaultAsync(predicate);
		}
	}
}
