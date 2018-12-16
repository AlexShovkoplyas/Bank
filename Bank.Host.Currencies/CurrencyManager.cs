using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Host.Currencies
{
    class CurrencyManager
    {
        private readonly CurrencyStoreClient storeClient;
        private readonly CurrencyWebClient webClient;

        private readonly string path = "";

        public CurrencyManager() { }

        public CurrencyManager(CurrencyStoreClient storeClient, CurrencyWebClient webClient)
        {
            this.storeClient = storeClient;
            this.webClient = webClient;
        }
        public async void ProcessAsync()
        {
            while (true)
            {                
                var currencyPairs = await webClient.GetCurrencyPairsAsync(path);

                foreach (var currencyPair in currencyPairs)
                {
                    await storeClient.SaveCurrencyPair(currencyPair);
                }

                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }
    }
}
