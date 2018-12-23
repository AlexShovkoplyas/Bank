using Autofac;
using Bank.Infrustructure;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Bank.Consumers
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EndpointsConfigurator>().As<IEndpointsConfigurator>().SingleInstance();
            builder.RegisterConsumers(Assembly.GetExecutingAssembly());
        }
    }
}
