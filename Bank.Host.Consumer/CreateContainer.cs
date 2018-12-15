using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Host.Consumer
{
    public IContainer CreateContainer()
    {
        var builder = new ContainerBuilder();

        builder.RegisterModule<BusModule>();
        builder.RegisterModule<ConsumerModule>();

        return builder.Build();
    }

    public void CreateContainer()
    {
        _container = new Container(x =>
        {
            x.AddRegistry(new BusRegistry());
            x.AddRegistry(new ConsumerRegistry());
        });
    }
}
