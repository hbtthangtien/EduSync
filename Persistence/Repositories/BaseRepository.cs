using Application.Interfaces.IRepository;
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
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected readonly EduSyncContext _context;
		protected readonly DbSet<T> _dbSet;

		public BaseRepository(EduSyncContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_dbSet = _context.Set<T>();
		}

		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public void UpdateAsync(T entity)
		{
			_dbSet.Update(entity);
		}

		public void RemoveAsync(T entity)
		{
			_dbSet.Remove(entity);
		}

		public IQueryable<T> GetAllAsync()
		{
			return _dbSet.AsQueryable();
		}

		public IQueryable<T> GetInstance()
		{
			return _dbSet;
		}

		public async Task<T?> GetSingle(Expression<Func<T, bool>> expression)
		{
			return await _dbSet.FirstOrDefaultAsync(expression);
		}

		public IQueryable<T> Find(Expression<Func<T, bool>> expression)
		{
			return _dbSet.Where(expression);
		}

		public async Task<bool> HasAnyAsync(Expression<Func<T, bool>> expression)
		{
			return await _dbSet.AnyAsync(expression);
		}
	}
}
