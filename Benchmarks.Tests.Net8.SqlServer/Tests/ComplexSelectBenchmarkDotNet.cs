using Dapper;
using Benchmarks.Tests.Net8.SqlServer.Context;
using Benchmarks.Tests.Net8.SqlServer.Dtos;
using Benchmarks.Tests.Net8.SqlServer.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Benchmarks.Tests.Net8.SqlServer.Tests
{
    public class ComplexSelectBenchmarkDotNet
    {
        // ---------------------- Dapper ----------------------
        public async Task<List<AddressDto>> SelectComplexAddressesDapper(int take, SqlConnection sqlConnection)
        {
            // Asegurar que la conexión esté abierta
            if (sqlConnection.State == ConnectionState.Closed)
                await sqlConnection.OpenAsync();

            var subQuery = $@"
                SELECT TOP {take} Id 
                FROM efdp_address
                ORDER BY Id";

            var sql = $@"
                SELECT 
                    ad.Id AS AddressId, ad.number AS Number, ad.street AS Street, ad.city AS City, ad.country AS Country, ad.zip_code AS ZipCode,
                    c.Id AS CustomerId, c.first_name AS FirstName, c.last_name AS LastName, c.email AS Email, c.birth_date AS BirthDate,
                    p.Id AS ProductId, p.name AS ProductName, p.description AS ProductDescription, p.price AS Price, p.brand AS Brand,
                    pp.Id AS ProductPageId, pp.title AS Title, pp.small_description AS SmallDescription
                FROM efdp_address ad
                INNER JOIN efdp_customer c ON ad.Id = c.address_id
                INNER JOIN efdp_product p ON c.Id = p.customer_id
                INNER JOIN efdp_product_page pp ON p.product_page_id = pp.Id
                WHERE ad.Id IN ({subQuery})
                ORDER BY ad.Id, c.Id, p.Id";

            var flat = await sqlConnection.QueryAsync<FlatCustomerData>(sql);

            // Agrupar manualmente
            var result = flat
                .GroupBy(f => f.AddressId)
                .Select(addressGroup =>
                {
                    var first = addressGroup.First();
                    return new AddressDto
                    {
                        AddressId = first.AddressId,
                        Number = first.Number,
                        Street = first.Street,
                        City = first.City,
                        Country = first.Country,
                        ZipCode = first.ZipCode,
                        Customers = addressGroup
                            .GroupBy(f => f.CustomerId)
                            .Select(customerGroup =>
                            {
                                var cFirst = customerGroup.First();
                                return new CustomerDto
                                {
                                    CustomerId = cFirst.CustomerId,
                                    Name = cFirst.Name,
                                    Email = cFirst.Email,
                                    BirthDate = cFirst.BirthDate,
                                    Products = customerGroup
                                        .Where(f => f.ProductId != Guid.Empty)
                                        .Select(f => new ProductDto
                                        {
                                            ProductId = f.ProductId,
                                            Name = f.ProductName,
                                            Description = f.ProductDescription,
                                            Price = f.Price,
                                            Brand = f.Brand,
                                            ProductPage = new ProductPageDto
                                            {
                                                ProductPageId = f.ProductPageId,
                                                Title = f.Title,
                                                Description = f.SmallDescription,
                                                ImageLink = null
                                            }
                                        })
                                        .ToList()
                                };
                            })
                            .ToList()
                    };
                })
                .ToList();

            return result;
        }

        // ---------------------- EF Core ----------------------
        public async Task<List<AddressDto>> SelectComplexAddressesEFCore(int take, string connectionString)
        {
            var options = new DbContextOptionsBuilder<DotNetCoreContext>()
                .UseSqlServer(connectionString)
                .Options;

            using var context = new DotNetCoreContext(options);
            context.ChangeTracker.LazyLoadingEnabled = false;

            var addresses = await context.Address
                .OrderBy(a => a.Id)
                .Take(take)
                .Include(a => a.Customers)
                    .ThenInclude(c => c.Products)
                        .ThenInclude(p => p.ProductPage)
                .AsNoTracking()
                .ToListAsync();

            return addresses.Select(a => new AddressDto
            {
                AddressId = a.Id,
                Number = a.Number,
                Street = a.Street,
                City = a.City,
                Country = a.Country,
                ZipCode = a.ZipCode,
                Customers = a.Customers?.Select(c => new CustomerDto
                {
                    CustomerId = c.Id,
                    Name = c.FirstName + " " + c.LastName,
                    Email = c.Email,
                    BirthDate = c.BirthDate,
                    Products = c.Products?.Select(p => new ProductDto
                    {
                        ProductId = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Brand = p.Brand,
                        ProductPage = p.ProductPage == null ? null : new ProductPageDto
                        {
                            ProductPageId = p.ProductPage.Id,
                            Title = p.ProductPage.Title,
                            Description = p.ProductPage.SmallDescription,
                            ImageLink = p.ProductPage.ImageLink
                        }
                    }).ToList()
                }).ToList()
            }).ToList();
        }

        // ---------------------- EF6 ----------------------
        public async Task<List<AddressDto>> SelectComplexAddressesEF6(int take, string connectionString)
        {
            using var context = new Ef6Context(connectionString);
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;

            // Obtener IDs de direcciones (similar a SingleSelect)
            var addressIds = await context.Address
                .OrderBy(a => a.Id)
                .Select(a => a.Id)
                .Take(take)
                .ToListEf6Async();

            // Consulta principal con Include en cadena
            var addresses = await context.Address
                .Where(a => addressIds.Contains(a.Id))
                .Include("Customers.Products.ProductPage") // ← Cadena, no lambda
                .AsNoTracking()
                .ToListEf6Async(); // ← ToListEf6Async como en el método que funciona

            // Mantener orden (opcional)
            addresses = addresses
                .OrderBy(a => addressIds.IndexOf(a.Id))
                .ToList();

            // Mapeo a DTOs (igual que antes)
            return addresses.Select(a => new AddressDto
            {
                AddressId = a.Id,
                Number = a.Number,
                Street = a.Street,
                City = a.City,
                Country = a.Country,
                ZipCode = a.ZipCode,
                Customers = a.Customers?.Select(c => new CustomerDto
                {
                    CustomerId = c.Id,
                    Name = c.FirstName + " " + c.LastName,
                    Email = c.Email,
                    BirthDate = c.BirthDate,
                    Products = c.Products?.Select(p => new ProductDto
                    {
                        ProductId = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Brand = p.Brand,
                        ProductPage = p.ProductPage == null ? null : new ProductPageDto
                        {
                            ProductPageId = p.ProductPage.Id,
                            Title = p.ProductPage.Title,
                            Description = p.ProductPage.SmallDescription,
                            ImageLink = p.ProductPage.ImageLink
                        }
                    }).ToList()
                }).ToList()
            }).ToList();
        }

        // ---------------------- EntitySpaces ----------------------
        public async Task<List<AddressDto>>SelectComplexAddressesEntitySpaces(int take, EntitySpacesService esService)
        {

            // EntitySpacesService ya tiene el método InsertComplexCustomers (síncrono)
            // Lo envolvemos en Task para mantener la firma asíncrona
            return await esService.SelectComplexAddresses(take);
        }
    }
}