using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Transporting
{
    public interface IMessageBus
    {
        Task SendAsync<TMessage>(TMessage message) where TMessage : class;

        Task PublishAsync<TMessage>(TMessage message) where TMessage : class;
    }
}
