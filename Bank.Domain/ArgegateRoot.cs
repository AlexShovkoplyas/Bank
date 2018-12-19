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
        public int Version { get; internal set; } = -1;

        private readonly List<Event> changes = new List<Event>();

        public ICollection<Event> GetPendingEvents()
        {
            return changes;
        }

        public void ClearPendingEvents()
        {
            changes.Clear();
        }

        public void LoadsFromHistory(IEnumerable<Event> history)
        {
            foreach (var e in history) ((IAgregate)this).ApplyEvent(e);
        }

        public void ApplyEvent(Event @event)
        {
            ((dynamic)this).Apply((dynamic)@event);
            Version++;
        }
    }
}
