using Bank.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Core.Events.Account
{
    public class AccountCredited : Event
    {
        public readonly Guid Id;
        public readonly long Amount;

        public AccountCredited(Guid id, long amount)
        {
            Id = id;
            Amount = amount;
        }
    }
}
