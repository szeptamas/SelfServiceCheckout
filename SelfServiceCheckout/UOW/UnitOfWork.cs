using SelfServiceCheckout.Infrastructure;
using SelfServiceCheckout.Repositories;
using System.Threading.Tasks;

namespace SelfServiceCheckout.UOW
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MoneyDbContext _context;
		public IMoneyRepository MoneyRepository { get; private set; }

		public UnitOfWork(MoneyDbContext moneyDbContext)
		{
			_context = moneyDbContext;
			MoneyRepository = new MoneyRepository(moneyDbContext);
		}

		public bool Save() => _context.SaveChanges() > 0;

		public async Task<bool> SaveAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
