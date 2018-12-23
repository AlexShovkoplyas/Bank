using Autofac;
using MassTransit.RabbitMqTransport;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Infrustructure
{
    public interface IEndpointsConfigurator
    {
        void Configure(IRabbitMqHost host, IRabbitMqBusFactoryConfigurator cfg, IComponentContext context);
    }
}
