using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace External.Currency.Api.Models
{
    public class CurrencyPair
    {
        public CurrencyPair(string currencyFrom, string currencyTo, double fxRate)
        {
            CurrencyFrom = CurrencyFrom;
            CurrencyTo = currencyTo;
            FxRate = fxRate;
        }

        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public double FxRate { get; set; }
    }

    public enum Currency
    {
        EUR,
        USD,
        UAH
    }
}
