using System;
using System.Threading.Tasks;

namespace Benchmarks.Tests.Net8.SqlServer.Contracts
{
    public interface IDapperService
    {
        Task<TimeSpan> SelectSingleProducts(int take);
        Task<TimeSpan> SelectComplexCustomers(int take);

        Task<TimeSpan> InsertSingleProducts(int interactions);
        Task<TimeSpan> InsertComplexCustomers(int interactions);
    }
}
