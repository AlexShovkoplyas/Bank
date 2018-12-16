using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Core.Model
{
    public class CurrencyPair
    {
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public double FxRate { get; set; }
    }
}
