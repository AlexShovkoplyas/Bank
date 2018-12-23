using Autofac;
using Bank.Core.Commands;
using Bank.Core.Domain;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Infrustructure
{
    public class BusFactory
    {
        public IPublishEndpoint GetPublisher(BusSettings settings, IEndpointsConfigurator endpointsConfigurator, IComponentContext context)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(settings.HostAddress), h =>
                {
                    h.Username(settings.Username);
                    h.Password(settings.Password);
                });
                cfg.PrefetchCount = 4;

                endpointsConfigurator?.Configure(host, cfg, context);
            });

            bus.Start();
            return bus;
        }

        public ISendEndpointProvider GetSender(BusSettings settings)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(settings.HostAddress), h =>
                {
                    h.Username(settings.Username);
                    h.Password(settings.Password);
                });
            });
            new EndpointConventions().Map();
            
            bus.Start();
            return bus;
        }
    }

 

    

    
}
