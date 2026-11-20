using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Benchmarks.Tests.Net8.SqlServer.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Benchmarks.Runner.Net8.SqlServer
{
    [SimpleJob(RunStrategy.ColdStart, iterationCount: 10, warmupCount: 3)]
    [MarkdownExporterAttribute.GitHub]
    [MemoryDiagnoser]
    [HtmlExporter]
    public class SinglesSelectsEntitySpaces1
    {
        private readonly string connectionStrings = @"Data Source=VANHALEN\SQLEXPRESS; 
                               Initial Catalog=CamparationEntityDapper; 
                               Integrated Security=True; 
                               TrustServerCertificate=True;";

        private readonly EntitySpacesService _esService;

        public SinglesSelectsEntitySpaces1()
        {
            _esService = new EntitySpacesService(connectionStrings);
        }

        [Benchmark(Description = "Select 1 Product EntitySpaces")]
        public async Task SelectProductsEntitySpaces1() =>
            await _esService.SelectSingleProducts(1);
    }
}
