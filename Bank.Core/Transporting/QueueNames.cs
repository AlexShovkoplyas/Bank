using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Core.Transporting
{
    public static class QueueNames
    {
        public const string HOST_NAME = "rabbitmq://localhost/";
        public const string ACCOUNT_QUEUE_NAME = "account";
        public const string CREDIR_QUEUE_NAME = "credit";
        public const string DEBIT_QUEUE_NAME = "debit";
        //private const string ACCOUNT_QUEUE_NAME = "account";
    }
}
