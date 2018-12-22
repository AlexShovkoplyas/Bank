using Autofac;
using Bank.Core.Transporting;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Infrustructure
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var busSettings = context.Resolve<BusSettings>();

                var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(busSettings.HostAddress, h =>
                    {
                        h.Username(busSettings.Username);
                        h.Password(busSettings.Password);
                    });

                    if (busSettings.ReceiveQueueName != null)
                    {
                        cfg.ReceiveEndpoint(busSettings.ReceiveQueueName, ec =>
                        {
                            ec.LoadFrom(context);
                        });
                    }                    
                });

                return busControl;
            })
            .As<IBusControl>();


            builder.RegisterType<MessageBus>().SingleInstance().As<IMessageBus>();
        }
    }
}
