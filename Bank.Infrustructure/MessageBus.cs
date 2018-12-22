using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bank.Core.Transporting;
using MassTransit;

namespace Bank.Infrustructure
{
    class MessageBus : IMessageBus
    {
        private readonly BusSettings busSettings;
        private readonly IBusControl messageBus;

        public Dictionary<string, ISendEndpoint> Endpoints = new Dictionary<string, ISendEndpoint>();

        public MessageBus(BusSettings busSettings, IBusControl messageBus)
        {
            this.busSettings = busSettings;
            this.messageBus = messageBus;            
        }

        public async Task Initialize()
        {
            foreach (var sendEndpoint in busSettings.SendEndpoints)
            {
                Endpoints.Add(
                    sendEndpoint.Replace("rabbitmq://", ""),
                    await messageBus.GetSendEndpoint(new Uri(sendEndpoint)));
            }

            await messageBus.StartAsync();
        } 

        public Task PublishAsync<TMessage>(TMessage message) where TMessage : class
        {
            messageBus.Publish(message);
            return Task.CompletedTask;
        }

        public Task SendAsync<TMessage>(TMessage message) where TMessage : class
        {
            messageBus.Send(message);
            return Task.CompletedTask;
        }       
    }
}
