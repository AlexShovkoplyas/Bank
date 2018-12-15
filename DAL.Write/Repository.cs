using Bank.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Write
{
    class Repository : IRepository
    {
        public async Task<TAggregate> GetById<TAggregate>(object id) where TAggregate : IAgregate, new()
        {
            var aggregate = new TAggregate();

            var streamName = $"{aggregate.Identifier}/{id}";

            var eventNumber = 0;
            StreamEventsSlice currentSlice;
            do
            {
                currentSlice = await _eventStoreConnection.ReadStreamEventsForwardAsync(streamName, eventNumber, ReadPageSize, false);

                if (currentSlice.Status == SliceReadStatus.StreamNotFound)
                {
                    throw new AggregateNotFoundException(id, typeof(TAggregate));
                }

                if (currentSlice.Status == SliceReadStatus.StreamDeleted)
                {
                    throw new AggregateDeletedException(id, typeof(TAggregate));
                }

                eventNumber = currentSlice.NextEventNumber;

                foreach (var resolvedEvent in currentSlice.Events)
                {
                    var payload = DeserializeEvent(resolvedEvent.Event);
                    aggregate.ApplyEvent(payload);
                }
            } while (!currentSlice.IsEndOfStream);

            return aggregate;
        }

        public Task<int> SaveAsync(IAgregate aggregate, int expectedVersion, params KeyValuePair<string, string>[] extraHeaders)
        {
            throw new NotImplementedException();
        }
    }
}
