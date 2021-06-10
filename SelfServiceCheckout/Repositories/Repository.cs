using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SelfServiceCheckout.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		protected DbContext Context { get; private set; }

		public Repository(DbContext context)
		{
			Context = context;
		}

		public T Get(int id) => Context.Set<T>().Find(id);

		public DbSet<T> GetAll() => Context.Set<T>();


		public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => Context.Set<T>();

		public void Add(T entity) => Context.Set<T>().Add(entity);

		public async Task AddAsync(T entity) => await Context.Set<T>().AddAsync(entity);

		public async Task AddRangeAsync(IEnumerable<T> entity) => await Context.Set<T>().AddRangeAsync(entity);

		public void AddRange(IEnumerable<T> entities) => Context.Set<T>().AddRange(entities);
		public void Remove(T entity) => Context.Set<T>().Remove(entity);
		public void Update(T entity) => Context.Set<T>().Update(entity);

		public void RemoveRange(IEnumerable<T> entities) => Context.Set<T>().RemoveRange(entities);

		public async Task<T> FirstOrDefaultAsync() => await Context.Set<T>().FirstOrDefaultAsync();
	}
}