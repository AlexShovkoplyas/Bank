using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Core.Domain
{
    public interface IAgregate
    {
        Guid Id { get; }
        int Version { get; }
        string Identifier { get; }
        void ApplyEvent(Event @event);
        ICollection<object> GetPendingEvents();
        void ClearPendingEvents();
    }
}
