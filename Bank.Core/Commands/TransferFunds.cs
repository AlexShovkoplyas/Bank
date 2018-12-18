using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Core.Commands
{
    public interface DebitAccount
    {
        Guid AccountId { get; }
        long Amount { get; }
    }
}
