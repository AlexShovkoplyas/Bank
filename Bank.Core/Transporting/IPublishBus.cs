﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Transporting
{
    public interface IPublishBus
    {
        void Publish<TMessage>(object message) where TMessage : class;
    }
}
