using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Host.Consumer
{
    class IocContainerBuilder
    {
        public IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<Infrustructure.Module>();
            builder.RegisterModule<Consumers.Module>();

            return builder.Build();
        }
    }
}
