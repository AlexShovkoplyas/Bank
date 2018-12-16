using Bank.Core.Domain;
using Bank.Core.Events.Account;
using Bank.Core.EventsAccount;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain
{
    public class Account : AggregateRoot
    {
        public static string CollectionName => "account";

        public long Balance { get; private set; }
        public Currency Currency { get; private set; }
        public Person AccountOwner { get; private set; }

        public Account() { }

        public Account(long balance, Currency currency, Person person)
        {
            Id = Guid.NewGuid();
            Version = 0;

            Balance = balance;
            Currency = currency;
            AccountOwner = person;

            ApplyEvent(new AccountCreated(Id, AccountOwner.Id, Currency);
        } 

        public void Credit(double amount)
        {
            ApplyEvent(new AccountCreated(Id, amount));
        }

        public void Debit(double amount)
        {
            ApplyEvent(new AccountDebited(Id, amount));
        }

        private void Apply(AccountCredited risedEvent) => Balance += risedEvent.Amount;

        private void Apply(AccountDebited risedEvent) => Balance -= risedEvent.Amount;
    }
}
