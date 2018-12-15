using Bank.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Core.EventsAccount
{
    public class AccountCreated : Event
    {
        public readonly Guid Id;
        public readonly int PersonId;
        public readonly Currency Currency;

        public AccountCreated(Guid id, int personId, Currency currency)
        {
            Id = id;
            PersonId = personId;
            Currency = currency;
        }
    }
}


