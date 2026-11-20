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
    public class SinglesInsertsEntitySpaces1
    {
        private readonly string connectionStrings = @"Data Source=VANHALEN\SQLEXPRESS; 
                               Initial Catalog=CamparationEntityDapper; 
                               Integrated Security=True; 
                               TrustServerCertificate=True;";
        private readonly EntitySpacesService _esService;


        public SinglesInsertsEntitySpaces1()
        {
            _esService = new EntitySpacesService(connectionStrings);
        }

        [Benchmark(Description = "Insert 1 Product EntitySpaces")]
        public async Task InsertProductsEntitySpaces1() =>
            await _esService.InsertSingleProducts(1);
    }
}
