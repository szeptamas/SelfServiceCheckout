using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SelfServiceCheckout.Repositories
{
	public interface IRepository<T> where T : class
	{
		T Get(int id);
		DbSet<T> GetAll();
		IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

		void Add(T entity);
		void AddRange(IEnumerable<T> entities);

		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
		Task AddAsync(T entity);
		Task AddRangeAsync(IEnumerable<T> entities);
		Task<T> FirstOrDefaultAsync();
		void Update(T entity);
	}
}