using Microsoft.EntityFrameworkCore;
using SelfServiceCheckout.Infrastructure;

namespace SelfServiceCheckout.Repositories
{
	public class MoneyRepository : Repository<Money>, IMoneyRepository
	{
		public MoneyDbContext MoneyDbContext => Context as MoneyDbContext;

		public MoneyRepository(DbContext context) : base(context)
		{
		}
	}
}
