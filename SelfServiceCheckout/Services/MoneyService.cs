using Microsoft.EntityFrameworkCore;
using SelfServiceCheckout.DTOs;
using SelfServiceCheckout.UOW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServiceCheckout.Services
{
	public class MoneyService : IMoneyService
	{
		private IUnitOfWork _unitOfWork;

		public MoneyService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// Get the stock of money
		public async Task<List<Money>> GetAll()
		{
			return await _unitOfWork.MoneyRepository.GetAll().ToListAsync();
		}

		// Add money to stock
		public async Task<bool> Add(MoneyDTO money)
		{
			var stock = GetAll().Result;
			var result = stock.Where(x => x.Key == money.Key).First();
			result.Value += money.Value;

			_unitOfWork.MoneyRepository.Update(result);
			return await _unitOfWork.SaveAsync();
		}

		// Add money to stock as payment, return cashback
		public List<Money> Checkout(List<Money> givenMoney, int price)
		{
			var st = GetAll().Result;
			if (st == null)
				return null;

			// get actual stock
			Dictionary<string, int> stock = new Dictionary<string, int>();
			foreach (var item in st)
			{
				stock.Add(item.Key, item.Value ?? 0);
			}

			// add givenMoney to stock
			foreach (var item in givenMoney)
			{
				stock[item.Key] = item.Value ?? 0;
			}
			
			Dictionary<string, int> cashbackList = new Dictionary<string, int>();

			while (price > 0)
			{
				// get highest money in stock that is less than price
				var maxMoney = stock.Keys.Where(x => int.Parse(x) < price).Max();
				if (maxMoney == null)
					return null;

				stock[maxMoney] -= 1;
				cashbackList[maxMoney] = 1;
				price -= int.Parse(maxMoney);
			}
			if (price == 0)
				return cashbackList.Select(x => new Money { Key = x.Key.ToString(), Value = x.Value }).ToList();
			else
				return null;
		}
	}
}
