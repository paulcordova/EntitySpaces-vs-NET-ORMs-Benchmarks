using System;

namespace Benchmarks.Tests.Net8.SqlServer.Results
{
    public class ResultDetailsCell
    {
        public Guid? IdResult { get; set; }
        public string TempoMax { get; set; }
        public string TempoMin { get; set; }
        public double? Ram { get; set; }
    }

}
