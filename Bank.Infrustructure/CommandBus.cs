using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bank.Core.Transporting;
using MassTransit;

namespace Bank.Infrustructure
{
    class CommandBus : ICommandBus
    {
        private readonly ISendEndpoint endpoint;

        public CommandBus(ISendEndpoint endpoint)
        {
            this.endpoint = endpoint;
        }

        public void Send<TMessage>(TMessage message) where TMessage : class
        {
            endpoint.Send(message);
        }
    }
}
