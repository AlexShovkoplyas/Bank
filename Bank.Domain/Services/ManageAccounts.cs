using Bank.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Services
{
    public class ManageAccounts
    {
        private readonly IRepository repository;

        public ManageAccounts(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task TransferMoney(Guid accountFrom, Guid accountTo, long amount)
        {
            var account1 = await repository.GetById<Account>(accountFrom.ToString());
            account1.Debit(amount);
            await repository.SaveAsync(account1, 0);

            var account2 = await repository.GetById<Account>(accountTo.ToString());
            account2.Credit(amount);
            await repository.SaveAsync(account2, 0);
        }

    }
}
