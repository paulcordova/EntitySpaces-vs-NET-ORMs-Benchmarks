using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Benchmarks.Tests.Net8.SqlServer.Context;
using Benchmarks.Tests.Net8.SqlServer.Tests;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Benchmarks.Runner.Net8.SqlServer
{
    [SimpleJob(RunStrategy.ColdStart, iterationCount: 10, warmupCount: 3)]
    //[SimpleJob(RunStrategy.Monitoring, iterationCount: 5, warmupCount: 2)]
    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    public class ComplexInserts1
    {
        private readonly string connectionStrings = @"Data Source=VANHALEN\SQLEXPRESS; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True; 
                               TrustServerCertificate=True;";

        private readonly SqlConnection _sqlConnection;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        private readonly EntitySpacesService _esService; 
        private readonly ComplexInsertsBenchmarkDotNet _complexService;

        public ComplexInserts1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);

            _sqlConnection = new SqlConnection(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);
            _ef6Context = new Ef6Context(connectionStrings);
            _complexService = new ComplexInsertsBenchmarkDotNet(); 
            _esService = new EntitySpacesService(connectionStrings);
        }


        [Benchmark(Description = "Insert 1 Complex Customer Dapper")]
        public async Task InsertComplexDapper1() =>
            await _complexService.InsertComplexCustomersDapperWithExistingProducts(1, _sqlConnection);


        [Benchmark(Description = "Insert 1 Complex Customer EF6")]
        public async Task InsertComplexEf6_1() =>
           await _complexService.InsertComplexCustomersEf6WithExistingProducts(1, _ef6Context);

        [Benchmark(Description = "Insert 1 Complex Customer EF Core")]
        public async Task InsertComplexEfCore1() =>
            await _complexService.InsertComplexCustomersEfCoreWithExistingProducts(1, _efCoreContext);

        [Benchmark(Description = "Insert 1 Complex Customer EntitySpaces2026")]
        public async Task InsertComplexEntitySpaces1() =>
            await _complexService.InsertComplexCustomersEntitySpaces(1, _esService);
    }

    [SimpleJob(RunStrategy.ColdStart, iterationCount: 10, warmupCount: 3)]
    //[SimpleJob(RunStrategy.Monitoring, iterationCount: 5, warmupCount: 2)]
    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    public class ComplexInserts5
    {
        private readonly string connectionStrings = @"Data Source=VANHALEN\SQLEXPRESS; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True; 
                               TrustServerCertificate=True;";
        private readonly SqlConnection _sqlConnection;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        private readonly EntitySpacesService _esService;
        private readonly ComplexInsertsBenchmarkDotNet _complexService;

        public ComplexInserts5()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);
            _complexService = new ComplexInsertsBenchmarkDotNet();
            _sqlConnection = new SqlConnection(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);
            _ef6Context = new Ef6Context(connectionStrings);
            _esService = new EntitySpacesService(connectionStrings);
        }

        //[Benchmark(Description = "Insert 5 Complex Customers Ado")]
        //public async Task InsertComplexAdo5() =>
        //    await _complexService.InsertComplexCustomersAdo(5, _sqlConnection);

        //[Benchmark(Description = "Insert 5 Complex Customers Dapper")]
        //public async Task InsertComplexDapper5() =>
        //    await _complexService.InsertComplexCustomersDapper(5, _sqlConnection);

        [Benchmark(Description = "Insert 5 Complex Customers Dapper")]
        public async Task InsertComplexDapper5() =>
            await _complexService.InsertComplexCustomersDapperWithExistingProducts(5, _sqlConnection);

        [Benchmark(Description = "Insert 5 Complex Customer EF6")]
        public async Task InsertComplexEf6_1() =>
           await _complexService.InsertComplexCustomersEf6WithExistingProducts(5, _ef6Context);

        [Benchmark(Description = "Insert 5 Complex Customer EF Core")]
        public async Task InsertComplexEfCore1() =>
           await _complexService.InsertComplexCustomersEfCoreWithExistingProducts(5, _efCoreContext);

        [Benchmark(Description = "Insert 5 Complex Customers EntitySpaces2026")]
        public async Task InsertComplexEntitySpaces5() =>
            await _complexService.InsertComplexCustomersEntitySpaces(5, _esService);
    }


    [SimpleJob(RunStrategy.ColdStart, iterationCount: 10, warmupCount: 3)]
    //[SimpleJob(RunStrategy.Monitoring, iterationCount: 5, warmupCount: 2)]
    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    public class ComplexInserts20
    {
        private readonly string connectionStrings = @"Data Source=VANHALEN\SQLEXPRESS; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True; 
                               TrustServerCertificate=True;";
        private readonly SqlConnection _sqlConnection;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        private readonly EntitySpacesService _esService;
        private readonly ComplexInsertsBenchmarkDotNet _complexService;

        public ComplexInserts20()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);
            _complexService = new ComplexInsertsBenchmarkDotNet();
            _sqlConnection = new SqlConnection(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);
            _ef6Context = new Ef6Context(connectionStrings);
            _esService = new EntitySpacesService(connectionStrings);
        }

        //[Benchmark(Description = "Insert 5 Complex Customers Ado")]
        //public async Task InsertComplexAdo5() =>
        //    await _complexService.InsertComplexCustomersAdo(5, _sqlConnection);

        //[Benchmark(Description = "Insert 5 Complex Customers Dapper")]
        //public async Task InsertComplexDapper5() =>
        //    await _complexService.InsertComplexCustomersDapper(5, _sqlConnection);

        [Benchmark(Description = "Insert 20 Complex Customers Dapper")]
        public async Task InsertComplexDapper5() =>
            await _complexService.InsertComplexCustomersDapperWithExistingProducts(20, _sqlConnection);

        [Benchmark(Description = "Insert 20 Complex Customer EF6")]
        public async Task InsertComplexEf6_1() =>
           await _complexService.InsertComplexCustomersEf6WithExistingProducts(20, _ef6Context);

        [Benchmark(Description = "Insert 20 Complex Customer EF Core")]
        public async Task InsertComplexEfCore1() =>
           await _complexService.InsertComplexCustomersEfCoreWithExistingProducts(20, _efCoreContext);

        [Benchmark(Description = "Insert 20 Complex Customers EntitySpaces2026")]
        public async Task InsertComplexEntitySpaces5() =>
            await _complexService.InsertComplexCustomersEntitySpaces(20, _esService);
    }
}
