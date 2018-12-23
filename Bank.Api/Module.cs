using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Api
{
    internal class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<Consumers.Module>();
            builder.RegisterModule<Infrustructure.Module>();
        }
    }


    //FOR TESTING ......................................

    public class Printer : IPrinter
    {
        public string Print(string message)
        {
            return $"*** {message} ***";
        }
    }

    public interface IPrinter
    {
        string Print(string message);
    }
}
