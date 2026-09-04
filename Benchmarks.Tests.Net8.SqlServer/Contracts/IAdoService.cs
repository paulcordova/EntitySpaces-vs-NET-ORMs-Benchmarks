using System;
using System.Threading.Tasks;

namespace Benchmarks.Tests.Net8.SqlServer.Contracts
{
    public interface IAdoService
    {
        Task<TimeSpan> InsertSingleProducts(int interactions);
    }
}
