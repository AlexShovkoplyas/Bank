using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Infrustructure
{
    public class BusSettings
    {
        public string HostAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        //public string ReceiveQueueName { get; }
        //public string[] SendEndpoints { get; }
    }
}
