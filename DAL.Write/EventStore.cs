using Bank.Core.Domain;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Write
{
    public class EventStore : IEventStore
    {
        private readonly IDocumentStore store;

        public EventStore()
        {
            store = DocumentStoreHolder.Store;
            documentStore.Initialize();
        }

        public List<Event> GetEventsForAggregate(Guid aggregateId)
        {
            using (var session = store.OpenSession())
            {
                return session.Query<Event>().Where(e => e.)
            }
        }

        public void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion)
        {
            throw new NotImplementedException();
        }
    }
}
