using Bank.Core.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Host.Currencies
{
    public class CurrencyWebClient
    {
        public async Task<List<CurrencyPair>> GetCurrencyPairsAsync(string path)
        {
            using (var client = new HttpClient())
            {
                List<CurrencyPair> currencyPairs = null;
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    currencyPairs = await response.Content.ReadAsAsync<List<CurrencyPair>>();
                }
                return currencyPairs;
            }            
        }
    }
}
