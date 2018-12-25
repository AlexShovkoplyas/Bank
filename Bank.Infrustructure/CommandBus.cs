using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bank.Core.Commands;
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

        public async Task Send<TMessage>(object message) where TMessage : class
        {
            //Uri uri;
            //EndpointConvention.TryGetDestinationAddress<CreateAccount>(out Uri uri);

            await endpoint.Send<TMessage>(message);
        }
    }
}
