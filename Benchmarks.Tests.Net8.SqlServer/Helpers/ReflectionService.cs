using Benchmarks.Tests.Net8.SqlServer.Results;

namespace Benchmarks.Tests.Net8.SqlServer.Helpers
{
    public class ReflectionService
    {
        public ReflectionService()
        {
            ReflectionResult = new ReflectionResult();
        }
        public ReflectionResult ReflectionResult { get; set; }
    }
}
