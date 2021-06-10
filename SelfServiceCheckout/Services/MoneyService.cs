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
		public List<Money> GetAll() => _unitOfWork.MoneyRepository.GetAll().ToList();

		// Add money to stock
		public async Task<bool> Add(MoneyDTO money)
		{
			var result = _unitOfWork.MoneyRepository.Find(x => x.Key == money.Key.Trim())?.FirstOrDefault();
			result.Value += money.Value;

			_unitOfWork.MoneyRepository.Update(result);
			return await _unitOfWork.SaveAsync();
		}

		// Add money to stock as payment, return cashback
		public List<Money> Checkout(List<Money> inserted, int price)
		{
			//TODO BL
			return null;
		}
	}
}
