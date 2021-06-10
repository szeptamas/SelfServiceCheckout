using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelfServiceCheckout.DTOs;
using SelfServiceCheckout.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SelfServiceCheckout.Controllers
{
	[ApiController]
	public class MoneyController : ControllerBase
	{
		private readonly ILogger<MoneyController> _logger;
		private IMoneyService _moneyService;

		public MoneyController(IMoneyService moneyService, ILogger<MoneyController> logger)
		{
			_logger = logger;
			_moneyService = moneyService;
		}

		[HttpGet]
		[Route("/api/v1/Stock")]
		public ActionResult<List<Money>> GetAll()
		{
			return _moneyService.GetAll();
		}

		[HttpPost]
		[Route("/api/v1/Stock")]
		public async Task<IActionResult> Add(MoneyDTO insertedMoney)
		{
			var result = await _moneyService.Add(insertedMoney);
											
			return Ok();
		}

		[HttpPost]
		[Route("/api/v1/Checkout")]
		public ActionResult<List<Money>> Checkout(List<Money> givenMoney, int price)
		{
			if (givenMoney.Count == 0 || price <= 0)  // input check
				return BadRequest();

			//int sumMoney = givenMoney.Sum(x => x.Value);
			//if (sumMoney < price) // price is higher than the given money
			//	return BadRequest();

			//TODO implement cashback logic here

			return Ok(null);
		}
	}
}
