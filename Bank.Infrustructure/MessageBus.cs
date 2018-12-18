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

        public MessageBus(BusSettings busSettings, IBusControl messageBus)
        {
            this.busSettings = busSettings;
            this.messageBus = messageBus;
            messageBus.Start();
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

        ~MessageBus()
        {
            messageBus.Stop();
        }        
    }
}
