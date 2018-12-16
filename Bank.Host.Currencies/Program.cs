using Bank.Core.Model;
using System;
using System.Threading.Tasks;

namespace Bank.Host.Currencies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var manager = new CurrencyManager();
            manager.ProcessAsync();

            Console.WriteLine("Press key to shutdown the client...");
            Console.ReadLine();
        }         
    }
}
