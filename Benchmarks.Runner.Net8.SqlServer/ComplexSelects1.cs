using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Benchmarks.Tests.Net8.SqlServer.Context;
using Benchmarks.Tests.Net8.SqlServer.Dtos;
using Benchmarks.Tests.Net8.SqlServer.Tests;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace Benchmarks.Runner.Net8.SqlServer
{
    [SimpleJob(RunStrategy.ColdStart, iterationCount: 10, warmupCount: 3)]
    [MarkdownExporterAttribute.GitHub]
    [MemoryDiagnoser]
    [HtmlExporter]
    public class ComplexSelects1
    {
        private readonly string connectionStrings = @"Data Source=VANHALEN\SQLEXPRESS; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True; 
                               TrustServerCertificate=True;";

        private readonly SqlConnection _sqlConnection;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        private readonly EntitySpacesService _esService;
        private readonly ComplexSelectBenchmarkDotNet _complexSelectService;

        public ComplexSelects1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);

            _sqlConnection = new SqlConnection(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);
            _ef6Context = new Ef6Context(connectionStrings);
            _esService = new EntitySpacesService(connectionStrings);
            _complexSelectService = new ComplexSelectBenchmarkDotNet();
        }

        [Benchmark(Description = "Select 1 Complex Address Dapper")]
        public async Task<List<AddressDto>> SelectDapper() =>
            await _complexSelectService.SelectComplexAddressesDapper(1, _sqlConnection);

        [Benchmark(Description = "Select 1 Complex Address EF Core")]
        public async Task<List<AddressDto>> SelectEfCore() =>
            await _complexSelectService.SelectComplexAddressesEFCore(1, connectionStrings);

        [Benchmark(Description = "Select 1 Complex Address EF6")]
        public async Task<List<AddressDto>> SelectEf6() =>
            await _complexSelectService.SelectComplexAddressesEF6(1, connectionStrings);

        [Benchmark(Description = "Select 1 Complex Address EntitySpaces2026")]
        public async Task<List<AddressDto>> SelectEntitySpaces() =>
            await _complexSelectService.SelectComplexAddressesEntitySpaces(1, _esService);
    }

    // Repite para ComplexSelects5, ComplexSelects50, ComplexSelects500
    // Solo cambia el número en los métodos y el nombre de la clase.

    [SimpleJob(RunStrategy.ColdStart, iterationCount: 10, warmupCount: 3)]
    [MarkdownExporterAttribute.GitHub]
    [MemoryDiagnoser]
    [HtmlExporter]
    public class ComplexSelects5
    {
        private readonly string connectionStrings = @"Data Source=VANHALEN\SQLEXPRESS; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True; 
                               TrustServerCertificate=True;";

        private readonly SqlConnection _sqlConnection;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        private readonly EntitySpacesService _esService;
        private readonly ComplexSelectBenchmarkDotNet _complexSelectService;

        public ComplexSelects5()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);

            _sqlConnection = new SqlConnection(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);
            _ef6Context = new Ef6Context(connectionStrings);
            _esService = new EntitySpacesService(connectionStrings);
            _complexSelectService = new ComplexSelectBenchmarkDotNet();
        }

        [Benchmark(Description = "Select 5 Complex Address Dapper")]
        public async Task<List<AddressDto>> SelectDapper() =>
            await _complexSelectService.SelectComplexAddressesDapper(5, _sqlConnection);

        [Benchmark(Description = "Select 5 Complex Address EF Core")]
        public async Task<List<AddressDto>> SelectEfCore() =>
            await _complexSelectService.SelectComplexAddressesEFCore(5, connectionStrings);

        [Benchmark(Description = "Select 5 Complex Address EF6")]
        public async Task<List<AddressDto>> SelectEf6() =>
            await _complexSelectService.SelectComplexAddressesEF6(5, connectionStrings);

        [Benchmark(Description = "Select 5 Complex Address EntitySpaces2026")]
        public async Task<List<AddressDto>> SelectEntitySpaces() =>
            await _complexSelectService.SelectComplexAddressesEntitySpaces(5, _esService);
    }


    [SimpleJob(RunStrategy.ColdStart, iterationCount: 10, warmupCount: 3)]
    [MarkdownExporterAttribute.GitHub]
    [MemoryDiagnoser]
    [HtmlExporter]
    public class ComplexSelects50
    {
        private readonly string connectionStrings = @"Data Source=VANHALEN\SQLEXPRESS; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True; 
                               TrustServerCertificate=True;";

        private readonly SqlConnection _sqlConnection;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        private readonly EntitySpacesService _esService;
        private readonly ComplexSelectBenchmarkDotNet _complexSelectService;

        public ComplexSelects50()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);

            _sqlConnection = new SqlConnection(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);
            _ef6Context = new Ef6Context(connectionStrings);
            _esService = new EntitySpacesService(connectionStrings);
            _complexSelectService = new ComplexSelectBenchmarkDotNet();
        }

        [Benchmark(Description = "Select 50 Complex Address Dapper")]
        public async Task<List<AddressDto>> SelectDapper() =>
            await _complexSelectService.SelectComplexAddressesDapper(50, _sqlConnection);

        [Benchmark(Description = "Select 50 Complex Address EF Core")]
        public async Task<List<AddressDto>> SelectEfCore() =>
            await _complexSelectService.SelectComplexAddressesEFCore(50, connectionStrings);

        [Benchmark(Description = "Select 50 Complex Address EF6")]
        public async Task<List<AddressDto>> SelectEf6() =>
            await _complexSelectService.SelectComplexAddressesEF6(50, connectionStrings);

        [Benchmark(Description = "Select 50 Complex Address EntitySpaces2026")]
        public async Task<List<AddressDto>> SelectEntitySpaces() =>
            await _complexSelectService.SelectComplexAddressesEntitySpaces(50, _esService);
    }

    [SimpleJob(RunStrategy.ColdStart, iterationCount: 10, warmupCount: 3)]
    [MarkdownExporterAttribute.GitHub]
    [MemoryDiagnoser]
    [HtmlExporter]
    public class ComplexSelects500
    {
        private readonly string connectionStrings = @"Data Source=VANHALEN\SQLEXPRESS; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True; 
                               TrustServerCertificate=True;";

        private readonly SqlConnection _sqlConnection;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        private readonly EntitySpacesService _esService;
        private readonly ComplexSelectBenchmarkDotNet _complexSelectService;

        public ComplexSelects500()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);

            _sqlConnection = new SqlConnection(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);
            _ef6Context = new Ef6Context(connectionStrings);
            _esService = new EntitySpacesService(connectionStrings);
            _complexSelectService = new ComplexSelectBenchmarkDotNet();
        }

        [Benchmark(Description = "Select 500 Complex Address Dapper")]
        public async Task<List<AddressDto>> SelectDapper() =>
            await _complexSelectService.SelectComplexAddressesDapper(500, _sqlConnection);

        [Benchmark(Description = "Select 500 Complex Address EF Core")]
        public async Task<List<AddressDto>> SelectEfCore() =>
            await _complexSelectService.SelectComplexAddressesEFCore(500, connectionStrings);

        [Benchmark(Description = "Select 500 Complex Address EF6")]
        public async Task<List<AddressDto>> SelectEf6() =>
            await _complexSelectService.SelectComplexAddressesEF6(500, connectionStrings);

        [Benchmark(Description = "Select 500 Complex Address EntitySpaces2026")]
        public async Task<List<AddressDto>> SelectEntitySpaces() =>
            await _complexSelectService.SelectComplexAddressesEntitySpaces(500, _esService);


     }

}