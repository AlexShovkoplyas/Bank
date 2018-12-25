using Bank.Core.Commands;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using static Bank.Core.Transporting.QueueNames;

namespace Bank.Infrustructure
{
    class EndpointConventions
    {
        public void Map()
        {
            EndpointConvention.Map<CreateAccount>(new Uri(HOST_NAME + ACCOUNT_QUEUE_NAME));
            //EndpointConvention.Map<CreditAccount>(new Uri(HOST_NAME + ACCOUNT_QUEUE_NAME));
            //EndpointConvention.Map<DebitAccount>(new Uri(HOST_NAME + ACCOUNT_QUEUE_NAME));
            //EndpointConvention.Map<TransferFunds>(new Uri(HOST_NAME + ACCOUNT_QUEUE_NAME));
        }
    }
}
