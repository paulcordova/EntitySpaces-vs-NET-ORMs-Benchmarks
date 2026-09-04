using Benchmarks.Tests.Net8.SqlServer.Context.Maps;
using Benchmarks.Tests.Net8.SqlServer.Results;
using Microsoft.EntityFrameworkCore;

namespace Benchmarks.Tests.Net8.SqlServer.Context
{
    public class DotNetCoreContext : DbContext
    {
        public DotNetCoreContext(DbContextOptions<DotNetCoreContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ProductPage> ProductPages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new ProductPageMap());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=VANHALEN\SQLEXPRESS; 
        //                   Initial Catalog=CamparationEntityDapper; Integrated Security=True");
        //}
    }
}
