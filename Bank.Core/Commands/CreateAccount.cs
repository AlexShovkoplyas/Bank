using Bank.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Core.Commands
{
    public interface CreateAccount
    {
        Guid Id { get; set; }
        int PersonId { get; set; }
        Currency Currency { get; set; }
    }
}
