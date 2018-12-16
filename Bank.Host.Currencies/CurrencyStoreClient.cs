using Bank.Core.Model;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Host.Currencies
{
    class CurrencyStoreClient
    {
        private readonly IDocumentStore store;

        public CurrencyStoreClient(IDocumentStore store)
        {
            this.store = store;
        }

        public async Task SaveCurrencyPair(CurrencyPair currencyPair)
        {
            using (var session = store.OpenSession())
            {
                session.Store(currencyPair);
                session.SaveChanges();
            }            
        }
    }
}
