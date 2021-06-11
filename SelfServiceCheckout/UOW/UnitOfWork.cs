using SelfServiceCheckout.Infrastructure;
using SelfServiceCheckout.Repositories;
using System.Threading.Tasks;

namespace SelfServiceCheckout.UOW
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MoneyDbContext _context;

		public IMoneyRepository MoneyRepository { get; private set; }

		public UnitOfWork(MoneyDbContext context)
		{
			_context = context;
			MoneyRepository = new MoneyRepository(context);
		}

		public bool Save() => _context.SaveChanges() > 0;

		public async Task<bool> SaveAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
