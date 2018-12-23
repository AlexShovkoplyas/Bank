using Bank.Core.Commands;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Consumers
{
    class EndpointConventions
    {
        private const string HOST_NAME = "rabbitmq://";
        private const string ACCOUNT_QUEUE_NAME = "account";
        private const string CREDIR_QUEUE_NAME = "credit";
        private const string DEBIT_QUEUE_NAME = "debit";
        //private const string ACCOUNT_QUEUE_NAME = "account";

        public void Map()
        {
            EndpointConvention.Map<CreateAccount>(new Uri(HOST_NAME + ACCOUNT_QUEUE_NAME));
            EndpointConvention.Map<CreditAccount>(new Uri(HOST_NAME + ACCOUNT_QUEUE_NAME));
            EndpointConvention.Map<DebitAccount>(new Uri(HOST_NAME + ACCOUNT_QUEUE_NAME));
            EndpointConvention.Map<TransferFunds>(new Uri(HOST_NAME + ACCOUNT_QUEUE_NAME));
        }
    }
}
