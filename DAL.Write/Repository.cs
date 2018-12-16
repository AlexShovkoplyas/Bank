using Bank.Core.Domain;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Write
{
    class Repository : IRepository
    {
        private readonly IDocumentStore store;

        public Repository(IDocumentStore store)
        {
            this.store = store;
        }

        public async Task<TAggregate> GetById<TAggregate>(object id) where TAggregate : IAgregate, new()
        {
            var aggregate = new TAggregate();

            var streamName = $"{aggregate.Identifier}/{id}";

            using (var session = store.OpenSession())
            {
                var events = await session.Query<Event>().Where(e => e.Id.Contains(streamName), false).ToListAsync();

                events.ForEach(e => aggregate.ApplyEvent(e));
            }

            return aggregate;            
        }

        public async Task SaveAsync(IAgregate aggregate, int expectedVersion, params KeyValuePair<string, string>[] extraHeaders)
        {
            using (var session = store.OpenAsyncSession())
            {
                foreach (var _event in aggregate.GetPendingEvents())
                {
                    await session.StoreAsync(_event);                    
                }
                await session.SaveChangesAsync();
            }
        }
    }
}
