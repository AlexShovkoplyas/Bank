using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Core.Commands
{
    public interface CreditAccount
    {
        Guid AccountId { get; }
        long Amount { get; }
    }
}
