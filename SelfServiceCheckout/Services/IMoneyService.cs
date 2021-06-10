using SelfServiceCheckout.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SelfServiceCheckout.Services
{
	public interface IMoneyService
	{
		List<Money> GetAll();
		Task<bool> Add(MoneyDTO money);
		List<Money> Checkout(List<Money> inserted, int price);
	}
}
