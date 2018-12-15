using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Core.Domain
{
    public interface IEventStore
    {
        void SaveEvents(string aggregateId, IEnumerable<Event> events, int expectedVersion);
        List<Event> GetEventsForAggregate(string aggregateId);
    }
}
