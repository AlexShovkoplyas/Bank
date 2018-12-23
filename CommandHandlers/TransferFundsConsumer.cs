using Bank.Core.Commands;
using Bank.Core.Domain;
using Bank.Core.EventsAccount;
using Bank.Domain;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Consumers
{
    public class TransferFundsConsumer : IConsumer<TransferFunds>
    {
        private readonly IRepository repository;

        public TransferFundsConsumer(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task Consume(ConsumeContext<TransferFunds> context)
        {
            //var account = await repository.GetById<Account>(context.Message.AccountIdF.ToString());
            //account.Debit(context.Message.Amount);
            //await repository.SaveAsync(account, 0);
        }
    }
}
