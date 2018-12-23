﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bank.Core.Transporting;
using MassTransit;

namespace Bank.Infrustructure
{
    class PublishBus : IPublishBus
    {
        private readonly IPublishEndpoint messageBus;

        public PublishBus(IPublishEndpoint messageBus)
        {
            this.messageBus = messageBus;            
        }        

        public void Publish<TMessage>(object message) where TMessage : class
        {
            messageBus.Publish<TMessage>(message);
        }      
    }
}
