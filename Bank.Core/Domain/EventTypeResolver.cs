using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bank.Core.Domain
{
    public class EventTypeResolver
    {
        private readonly IDictionary<string, Type> typeMap;

        public EventTypeResolver(Assembly assembly)
        {
            typeMap = assembly
                .GetExportedTypes()
                .Where(x => x.Name.EndsWith("Event", StringComparison.OrdinalIgnoreCase))
                .ToDictionary(x => x.Name);
        }

        public Type GetTypeForEventName(string name)
        {
            Type eventType;
            var strippedName = name.Replace(" ", string.Empty);
            if (!typeMap.TryGetValue(strippedName, out eventType))
            {
                throw new ArgumentException($"Unable to find suitable type for event name {name}. Expected to find a type named {strippedName}Event");
            }

            return eventType;
        }
    }
}