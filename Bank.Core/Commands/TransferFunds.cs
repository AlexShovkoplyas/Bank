using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Core.Commands
{
    public interface TransferFunds
    {
        Guid AccountIdFrom { get; }
        Guid AccountIdTo { get; }
        long Amount { get; }
    }
}
