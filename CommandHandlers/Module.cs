using Autofac;
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
            builder.RegisterConsumers(Assembly.GetExecutingAssembly());

        }
    }
}
