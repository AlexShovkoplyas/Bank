using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Domain
{
    public interface IRepository
    {
        Task<int> SaveAsync(IAgregate aggregate, int expectedVersion, params KeyValuePair<string, string>[] extraHeaders);
        Task<TAggregate> GetById<TAggregate>(string id) where TAggregate : IAgregate, new();
    }
}
