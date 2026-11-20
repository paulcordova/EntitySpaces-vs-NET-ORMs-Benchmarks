using BenchmarkDotNet.Attributes;
using Benchmarks.Tests.Net8.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Benchmarks.Runner.Net8.SqlServer.Models;

namespace Benchmarks.Runner.Net8.SqlServer
{
    public class DatabaseTestPerformance
    {
        DotNetCoreContext context;
        IDbConnection dapperConnection;
        EfCoreSingleSelect ef;
        DapperSengleSelect dapper;

        public DatabaseTestPerformance()
        {
            var connectionStrings = @"Data Source=VANHALEN\SQLEXPRESS; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True";

            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);
            context = new DotNetCoreContext(optionsBuilder.Options);

            dapperConnection = new SqlConnection(connectionStrings);

            ef = new EfCoreSingleSelect(context);
            dapper = new DapperSengleSelect(dapperConnection);
        }

        [Benchmark]
        public IReadOnlyList<ProductDto> Ef() => ef.GetProductsEF(50);

        [Benchmark]
        public IReadOnlyList<ProductDto> Dapper() => dapper.GetProducts(50);
    }
}
