using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Infrustructure
{
    public class BusSettings
    {
        public Uri HostAddress { get; }
        public string Username { get; }
        public string Password { get; }
        //public string ReceiveQueueName { get; }
        //public string[] SendEndpoints { get; }
    }
}
