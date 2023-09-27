using Dolunay.Data;
using Dolunay.Models;
using Dolunay.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dolunay.Repository.Shared.Concrete
{
	public class Repository<T> : IRepository<T> where T : BaseModel
	{
		private readonly ApplicationDbContext _context;
		private  DbSet<T> _dbSet;

		public Repository(ApplicationDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public void Add(T entity)
		{
			_dbSet.Add(entity);
		}

		public void AddRange(IEnumerable<T> entities)
		{
			_dbSet.AddRange(entities);
		}

		public void Delete(T entity)
		{
			entity.IsDeleted = true;
			entity.DateDeleted = DateTime.Now;
			entity.DateModified = DateTime.Now;
			entity.IsActive = false;
			_dbSet.Update(entity);
		}

		public void DeleteRange(IEnumerable<T> entities)
		{
			foreach (var entity in entities)
			{
				entity.IsDeleted = true;
				entity.DateDeleted = DateTime.Now;
				entity.DateModified = DateTime.Now;
				entity.IsActive = false;
			}
			_dbSet.UpdateRange(entities);

		}

		public IQueryable<T> GetAll()
		{
			return _dbSet.Where(x => x.IsDeleted == false);
		}

		public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
		{
			return GetAll().Where(predicate);	
		}

		public T GetById(int id)
		{
			return _dbSet.FirstOrDefault(x => x.Id == id);
		}

		public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
		{
			return _dbSet.FirstOrDefault(predicate);
		}

		public void Update(T entity)
		{
			entity.DateModified = DateTime.Now;
			_dbSet.Update(entity);
		}

		public T GetById(Guid id)
		{
			return _dbSet.FirstOrDefault(x => x.Guid == id);

		}
	}
}
