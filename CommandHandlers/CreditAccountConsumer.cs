using Bank.Core.Commands;
using Bank.Core.Domain;
using Bank.Core.EventsAccount;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Consumers
{
    public class CreditAccountConsumer : IConsumer<CreditAccount>
    {
        private readonly IRepository repository;

        public CreditAccountConsumer(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task Consume(ConsumeContext<CreditAccount> context)
        {
            //var account = await repository.GetById<Account>(context.Message.AccountId.ToString());
            //account.Credit(context.Message.Amount);
            //await repository.SaveAsync(account, 0);
        }
    }
}
