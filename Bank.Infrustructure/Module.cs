using Autofac;
using Bank.Core.Transporting;
using MassTransit;
using MassTransit.RabbitMqTransport;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Infrustructure
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BusFactory>().AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<BusFactory>().GetSender(c.Resolve<BusSettings>()))
                .As<ISendEndpointProvider>().SingleInstance();
            builder.Register(c => c.Resolve<BusFactory>().GetPublisher(c.Resolve<BusSettings>(), c.Resolve<IEndpointsConfigurator>(), c))
                .As<IPublishEndpoint>().SingleInstance();

            builder.RegisterType<PublishBus>().SingleInstance().As<IPublishBus>();
            builder.RegisterType<CommandBus>().SingleInstance().As<ICommandBus>();
        }
    }    
}
