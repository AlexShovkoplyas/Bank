using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Host.Currencies
{
    public class DocumentStoreHolder
    {
        private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

        public static IDocumentStore Store => store.Value;

        private static IDocumentStore CreateStore()
        {
            IDocumentStore store = new DocumentStore()
            {
                Urls = new[] { "http://localhost:8080" },
                Database = "Bank.EventStore"
            }.Initialize();

            return store;
        }
    }
}
