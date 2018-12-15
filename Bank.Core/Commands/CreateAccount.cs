using Bank.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Core.Commands
{
    public interface CreateAccount
    {
        Guid Id { get; }
        int PersonId { get; }
        Currency Currency { get; }
    }
}
