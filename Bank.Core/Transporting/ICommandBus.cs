using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Transporting
{
    public interface ICommandBus
    {
        void Send<TMessage>(TMessage message) where TMessage : class;
    }
}
