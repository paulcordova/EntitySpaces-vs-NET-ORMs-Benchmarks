using System;
using System.Threading.Tasks;

namespace Benchmarks.Tests.Net8.SqlServer.Contracts
{
    public interface IEf6Service
    {
        Task<TimeSpan> InsertSingleProducts(int interactions);
        Task<TimeSpan> InsertComplexCustomers(int interactions);

        Task<TimeSpan> SelectComplexCustomers(int take);
        Task<TimeSpan> SelectSingleProducts(int take);
    }
}
