using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using External.Currency.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace External.Currency.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FxRatesController : ControllerBase
    {
        const double EUR_UAH_RATE = 32;
        const double USD_UAH_RATE = 28;
        private Random random = new Random();

        [HttpGet]
        public ActionResult<IEnumerable<CurrencyPair>> Get()
        {
            var rateEurUah = EUR_UAH_RATE * random.Next(-100, +100);
            var rateUsdUah = USD_UAH_RATE * random.Next(-100, +100);

            var fxRates = new List<CurrencyPair>
            {
                new CurrencyPair("EUR", "USD", rateEurUah / rateUsdUah),
                new CurrencyPair("EUR", "UAH", rateEurUah ),
                new CurrencyPair("USD", "EUR", rateUsdUah / rateEurUah),
                new CurrencyPair("USD", "UAH", rateUsdUah),
                new CurrencyPair("UAH", "EUR", 1 / rateEurUah),
                new CurrencyPair("UAH", "USD", 1 / rateUsdUah)
            };

            return fxRates;
        } 
    }
}
