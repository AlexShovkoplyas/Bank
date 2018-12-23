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
        private readonly ISendEndpointProvider endpoint;

        public CommandBus(ISendEndpointProvider endpoint)
        {
            this.endpoint = endpoint;
        }

        public void Send<TMessage>(object message) where TMessage : class
        {
            endpoint.Send<TMessage>(message);
        }
    }
}
