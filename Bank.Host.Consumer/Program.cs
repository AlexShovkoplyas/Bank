using Autofac;
using Bank.Core.Transporting;
using System;

namespace Bank.Host.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var container = new IocContainerBuilder().Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IPublishBus>();
            }
        }
    }
}
