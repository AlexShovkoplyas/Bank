using Autofac;
using Bank.Infrustructure;
using MassTransit;
using MassTransit.RabbitMqTransport;
using System;
using System.Collections.Generic;
using System.Text;
using static Bank.Core.Transporting.QueueNames;

namespace Bank.Consumers
{
    public class EndpointsConfigurator : IEndpointsConfigurator
    {
        public void Configure(IRabbitMqHost host, IRabbitMqBusFactoryConfigurator cfg, IComponentContext context)
        {
            cfg.ReceiveEndpoint(ACCOUNT_QUEUE_NAME, ep =>
            {
                ep.Consumer<CreateAccountConsumer>(context);
                ep.Consumer<CreditAccountConsumer>(context);
                ep.Consumer<DebitAccountConsumer>(context);
            });
        }
    }
}
