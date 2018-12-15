using Bank.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain
{
    public abstract class AggregateRoot : IAgregate
    {
        public static string CollectionName { get; }
        
        public Guid Id { get; internal set; }              
        public string Identifier => $"{CollectionName}/{Id}";
        public int Version { get; internal set; }

        private readonly List<Event> changes = new List<Event>();

        public IEnumerable<Event> GetUncommittedChanges()
        {
            return changes;
        }

        public void MarkChangesAsCommitted()
        {
            changes.Clear();
        }

        public void LoadsFromHistory(IEnumerable<Event> history)
        {
            foreach (var e in history) ((IAgregate)this).ApplyEvent(e);
        }

        void IAgregate.ApplyEvent(Event @event)
        {
            ((dynamic)this).Apply(@event);
            Version++;
        }

        public ICollection<object> GetPendingEvents()
        {
            throw new NotImplementedException();
        }

        public void ClearPendingEvents()
        {
            throw new NotImplementedException();
        }


    }
}
