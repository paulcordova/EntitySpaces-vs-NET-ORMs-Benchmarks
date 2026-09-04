namespace Benchmarks.Tests.Net8.SqlServer.Results
{
    public class ReflectionResult
    {
        public string ListReflection { get; set; }
        public string ListWithoutReflection { get; set; }

        public string StaticMethod { get; set; }
        public string ReflectionMethod { get; set; }
    }
}
