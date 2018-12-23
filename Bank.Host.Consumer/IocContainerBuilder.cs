using Autofac;
using Bank.Infrustructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Bank.Host.Consumer
{
    class IocContainerBuilder
    {
        public IContainer Build()
        {
            var builder = new ContainerBuilder();
            builder.Register<BusSettings>(c => new BusSettings()
            {
                HostAddress = ConfigurationManager.AppSettings["HostAddress"],
                Username = ConfigurationManager.AppSettings["Username"],
                Password = ConfigurationManager.AppSettings["Password"],
            }).AsSelf().SingleInstance();

            builder.RegisterModule<Consumers.Module>();
            builder.RegisterModule<Infrustructure.Module>();
            
            return builder.Build();
        }
    }
}
