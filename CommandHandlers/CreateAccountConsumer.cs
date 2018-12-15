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
    public class CreateAccountConsumer : IConsumer<CreateAccount>
    {
        private readonly IRepository repository;

        public CreateAccountConsumer(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task Consume(ConsumeContext<CreateAccount> context)
        {
            var person = new Person(context.Message.Id, "Alex", "AlexShovkoplyas@gmail.com");
            var account = new Account(0, context.Message.Currency, person);
            await repository.SaveAsync(account, 0);
        }
    }
}
