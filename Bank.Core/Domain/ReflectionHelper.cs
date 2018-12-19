using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Bank.Core.Domain
{
    public class ReflectionHelper
    {
        public static Assembly ContractsAssembly = typeof(Event).GetTypeInfo().Assembly;
    }
}
