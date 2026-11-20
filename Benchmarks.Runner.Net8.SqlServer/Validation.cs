using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using Benchmarks.Tests.Net8.SqlServer.Dtos;
using Benchmarks.Tests.Net8.SqlServer.Tests;
using Microsoft.Data.SqlClient;

namespace Benchmarks.Runner.Net8.SqlServer
{
    /// <summary>
    /// Cross-checks the graph-read implementations outside BenchmarkDotNet.
    /// A latency comparison is only meaningful if every ORM loads the same graph,
    /// so this prints the addresses, customers and products each one returns.
    /// </summary>
    internal static class Validation
    {
        private const string ConnectionString =
            @"Data Source=VANHALEN\SQLEXPRESS; Initial Catalog=CamparationEntityDapper; Integrated Security=True; TrustServerCertificate=True;";

        public static async Task RunGraphReadChecksAsync()
        {
            var service = new ComplexSelectBenchmarkDotNet();
            var entitySpaces = new EntitySpacesService(ConnectionString);
            using var connection = new SqlConnection(ConnectionString);

            Console.WriteLine("Graph read validation: every ORM must return the same addresses, customers and products.");
            Console.WriteLine($"{"requested",9} {"orm",-14} {"run",-5} {"elapsed",9} {"addresses",10} {"customers",10} {"products",9}");

            foreach (var requested in new[] { 3, 500 })
            {
                await MeasureAsync(requested, "Dapper", () => service.SelectComplexAddressesDapper(requested, connection));
                await MeasureAsync(requested, "EF Core", () => service.SelectComplexAddressesEFCore(requested, ConnectionString));
                await MeasureAsync(requested, "EF6", () => service.SelectComplexAddressesEF6(requested, ConnectionString));
                await MeasureAsync(requested, "EntitySpaces", () => service.SelectComplexAddressesEntitySpaces(requested, entitySpaces));
            }

            RunEf6Diagnostics();
        }

        /// <summary>
        /// Explains why the EF6 graph comes back empty: it prints whether the model contains the
        /// Address-Customer association, whether the Include populates the navigation and whether
        /// the database actually has customers for that address.
        /// </summary>
        private static void RunEf6Diagnostics()
        {
            Console.WriteLine();
            Console.WriteLine("EF6 diagnostics");

            using var context = new Benchmarks.Tests.Net8.SqlServer.Context.Ef6Context(ConnectionString);
            var address = context.Address.OrderBy(a => a.Id).First();
            var related = context.Customers.Count(c => c.AddressId == address.Id);

            var workspace = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;
            var associations = workspace
                .GetItemCollection(System.Data.Entity.Core.Metadata.Edm.DataSpace.CSpace)
                .GetItems<System.Data.Entity.Core.Metadata.Edm.AssociationType>()
                .Select(a => a.Name);

            Console.WriteLine($"  address                 : {address.Id}");
            Console.WriteLine($"  customers in database   : {related}");
            Console.WriteLine($"  model associations      : {string.Join(", ", associations)}");

            // The benchmark uses a three-level Include with AsNoTracking and proxies disabled, so
            // each variation below isolates one of those factors.
            Probe("include Customers", "Customers", asNoTracking: true, configure: false);
            Probe("include 2 levels", "Customers.Products", asNoTracking: true, configure: false);
            Probe("include 3 levels", "Customers.Products.ProductPage", asNoTracking: true, configure: false);
            Probe("3 levels, no tracking off", "Customers.Products.ProductPage", asNoTracking: false, configure: false);
            Probe("3 levels, proxies off", "Customers.Products.ProductPage", asNoTracking: true, configure: true);

            void Probe(string label, string path, bool asNoTracking, bool configure)
            {
                using var ctx = new Benchmarks.Tests.Net8.SqlServer.Context.Ef6Context(ConnectionString);
                if (configure)
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                }

                var query = ctx.Address.Where(a => a.Id == address.Id).Include(path);
                var entity = asNoTracking ? query.AsNoTracking().Single() : query.Single();
                var customers = entity.Customers == null ? -1 : entity.Customers.Count;
                var products = entity.Customers == null
                    ? -1
                    : entity.Customers.Sum(c => c.Products == null ? 0 : c.Products.Count);
                Console.WriteLine($"  {label,-28} customers={customers,3} products={products,4}");
            }
        }

        private static async Task MeasureAsync(int requested, string orm, Func<Task<List<AddressDto>>> action)
        {
            // The first call pays connection and plan setup; the second one shows the steady state.
            for (var run = 0; run < 2; run++)
            {
                var watch = Stopwatch.StartNew();
                var graph = await action();
                watch.Stop();

                var addresses = graph?.Count ?? 0;
                var customers = graph == null ? 0 : graph.Sum(a => a.Customers == null ? 0 : a.Customers.Count());
                var products = graph == null
                    ? 0
                    : graph.Sum(a => a.Customers == null
                        ? 0
                        : a.Customers.Sum(c => c.Products == null ? 0 : c.Products.Count()));

                Console.WriteLine($"{requested,9} {orm,-14} {(run == 0 ? "cold" : "warm"),-5} {watch.ElapsedMilliseconds,7} ms {addresses,10} {customers,10} {products,9}");
            }
        }
    }
}
