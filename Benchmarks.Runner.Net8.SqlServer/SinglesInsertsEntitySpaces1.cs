using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Benchmarks.Tests.Net8.SqlServer.Tests;

namespace Benchmarks.Runner.Net8.SqlServer
{
    [MarkdownExporterAttribute.GitHub]
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
