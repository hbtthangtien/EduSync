using Application.Interfaces.IRepository;
using Domain.Entities;
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

	}
}
