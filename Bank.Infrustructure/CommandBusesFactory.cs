using Bank.Core.Transporting;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrustructure
{
    class CommandBusesFactory
    {
        public Dictionary<string, ICommandBus> Endpoints = new Dictionary<string, ICommandBus>();

        private readonly IBusControl bus;
        private readonly string[] endpointsAddresses;

        public CommandBusesFactory(IBusControl bus, string[] endpointsAddresses)
        {
            this.bus = bus;
            this.endpointsAddresses = endpointsAddresses;
        }

        public async Task Initialize()
        {
            foreach (var sendEndpoint in endpointsAddresses)
            {
                Endpoints.Add(
                    sendEndpoint.Replace("rabbitmq://", ""),
                    new CommandBus(await bus.GetSendEndpoint(new Uri(sendEndpoint))));
            }            
        }
    }
}
