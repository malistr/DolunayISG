using Dolunay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dolunay.Repository.Shared.Abstract
{
	public interface IRepository<T> where T : BaseModel
	{
		//Sadece imzalar atılacak

		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		IQueryable<T> GetAll();
		IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
		T GetById(int id);
		T GetById(Guid id);
		T GetFirstOrDefault(Expression<Func<T, bool>> predicate);
		void AddRange(IEnumerable<T> entities);	
		void DeleteRange(IEnumerable<T> entities);

	}
}
