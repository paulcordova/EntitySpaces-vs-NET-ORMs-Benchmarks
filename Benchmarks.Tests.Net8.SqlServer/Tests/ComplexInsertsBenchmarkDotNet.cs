using Bogus;
using BusinessObjects;
using Dapper;
using Benchmarks.Tests.Net8.SqlServer.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;

using System.Data.Entity;

using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Benchmarks.Tests.Net8.SqlServer.Tests
{
    public class ComplexInsertsBenchmarkDotNet
    {
        // ---------------------- ADO.NET ----------------------
        public async Task InsertComplexCustomersAdo(int interactions, SqlConnection sqlConnection)
        {
            var customers = new ListTests().ObtenirListCustomersAleatoire(interactions);
            await AddCustomersAdo(customers, sqlConnection);
            await sqlConnection.CloseAsync();
        }

        private async Task AddCustomersAdo(IEnumerable<Customer> customers, SqlConnection sqlConnection)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                await sqlConnection.OpenAsync();

            using var transaction = sqlConnection.BeginTransaction();

            try
            {
                foreach (var customer in customers)
                {
                    // 1. Insert Address
                    var addressSql = @"
                        INSERT INTO efdp_address (Id, Number, Street, City, Country, ZipCode, AdministrativeRegion)
                        VALUES (@Id, @Number, @Street, @City, @Country, @ZipCode, @AdministrativeRegion)";
                    using var cmdAddress = new SqlCommand(addressSql, sqlConnection, transaction);
                    cmdAddress.Parameters.AddWithValue("@Id", customer.Address.Id);
                    cmdAddress.Parameters.AddWithValue("@Number", customer.Address.Number);
                    cmdAddress.Parameters.AddWithValue("@Street", customer.Address.Street);
                    cmdAddress.Parameters.AddWithValue("@City", customer.Address.City);
                    cmdAddress.Parameters.AddWithValue("@Country", customer.Address.Country);
                    cmdAddress.Parameters.AddWithValue("@ZipCode", customer.Address.ZipCode);
                    cmdAddress.Parameters.AddWithValue("@AdministrativeRegion", customer.Address.AdministrativeRegion);
                    await cmdAddress.ExecuteNonQueryAsync();

                    // 2. Insert Customer
                    var customerSql = @"
                        INSERT INTO efdp_customer (Id, FirstName, LastName, Email, Status, BirthDate, AddressId)
                        VALUES (@Id, @FirstName, @LastName, @Email, @Status, @BirthDate, @AddressId)";
                    using var cmdCustomer = new SqlCommand(customerSql, sqlConnection, transaction);
                    cmdCustomer.Parameters.AddWithValue("@Id", customer.Id);
                    cmdCustomer.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    cmdCustomer.Parameters.AddWithValue("@LastName", customer.LastName);
                    cmdCustomer.Parameters.AddWithValue("@Email", customer.Email);
                    cmdCustomer.Parameters.AddWithValue("@Status", customer.Status);
                    cmdCustomer.Parameters.AddWithValue("@BirthDate", customer.BirthDate);
                    cmdCustomer.Parameters.AddWithValue("@AddressId", customer.AddressId);
                    await cmdCustomer.ExecuteNonQueryAsync();

                    // 3. Insert ProductPages and Products
                    foreach (var product in customer.Products)
                    {
                        // ProductPage
                        var pageSql = @"
                            INSERT INTO efdp_product_page (Id, Title, SmallDescription, FullDescription, ImageLink)
                            VALUES (@Id, @Title, @SmallDescription, @FullDescription, @ImageLink)";
                        using var cmdPage = new SqlCommand(pageSql, sqlConnection, transaction);
                        cmdPage.Parameters.AddWithValue("@Id", product.ProductPage.Id);
                        cmdPage.Parameters.AddWithValue("@Title", product.ProductPage.Title);
                        cmdPage.Parameters.AddWithValue("@SmallDescription", product.ProductPage.SmallDescription);
                        cmdPage.Parameters.AddWithValue("@FullDescription", product.ProductPage.FullDescription);
                        cmdPage.Parameters.AddWithValue("@ImageLink", product.ProductPage.ImageLink);
                        await cmdPage.ExecuteNonQueryAsync();

                        // Product
                        var productSql = @"
                            INSERT INTO efdp_product (Id, Name, Description, Price, OldPrice, Brand, CustomerId, ProductPageId)
                            VALUES (@Id, @Name, @Description, @Price, @OldPrice, @Brand, @CustomerId, @ProductPageId)";
                        using var cmdProduct = new SqlCommand(productSql, sqlConnection, transaction);
                        cmdProduct.Parameters.AddWithValue("@Id", product.Id);
                        cmdProduct.Parameters.AddWithValue("@Name", product.Name);
                        cmdProduct.Parameters.AddWithValue("@Description", product.Description);
                        cmdProduct.Parameters.AddWithValue("@Price", product.Price);
                        cmdProduct.Parameters.AddWithValue("@OldPrice", product.OldPrice);
                        cmdProduct.Parameters.AddWithValue("@Brand", product.Brand);
                        cmdProduct.Parameters.AddWithValue("@CustomerId", product.CustomerId);
                        cmdProduct.Parameters.AddWithValue("@ProductPageId", product.ProductPageId);
                        await cmdProduct.ExecuteNonQueryAsync();
                    }
                }

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    await sqlConnection.CloseAsync();
            }
        }

        // ---------------------- Dapper ----------------------
        public async Task InsertComplexCustomersDapper(int interactions, SqlConnection sqlConnection)
        {
            var customers = new ListTests().ObtenirListCustomersAleatoire(interactions);
            await AddCustomersDapper(customers, sqlConnection);
            await sqlConnection.CloseAsync();
        }

        private async Task AddCustomersDapper(IEnumerable<Customer> customers, SqlConnection sqlConnection)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                await sqlConnection.OpenAsync();

            using var transaction = sqlConnection.BeginTransaction();

            try
            {
                foreach (var customer in customers)
                {
                    // Address
                    var addressSql = @"
                        INSERT INTO efdp_address (Id, Number, Street, City, Country, ZipCode, AdministrativeRegion)
                        VALUES (@Id, @Number, @Street, @City, @Country, @ZipCode, @AdministrativeRegion)";
                    await sqlConnection.ExecuteAsync(addressSql, customer.Address, transaction);

                    // Customer
                    var customerSql = @"
                        INSERT INTO efdp_customer (Id, FirstName, LastName, Email, Status, BirthDate, AddressId)
                        VALUES (@Id, @FirstName, @LastName, @Email, @Status, @BirthDate, @AddressId)";
                    await sqlConnection.ExecuteAsync(customerSql, customer, transaction);

                    // ProductPages and Products
                    foreach (var product in customer.Products)
                    {
                        var pageSql = @"
                            INSERT INTO efdp_product_page (Id, Title, SmallDescription, FullDescription, ImageLink)
                            VALUES (@Id, @Title, @SmallDescription, @FullDescription, @ImageLink)";
                        await sqlConnection.ExecuteAsync(pageSql, product.ProductPage, transaction);

                        var productSql = @"
                            INSERT INTO efdp_product (Id, Name, Description, Price, OldPrice, Brand, CustomerId, ProductPageId)
                            VALUES (@Id, @Name, @Description, @Price, @OldPrice, @Brand, @CustomerId, @ProductPageId)";
                        await sqlConnection.ExecuteAsync(productSql, product, transaction);
                    }
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    await sqlConnection.CloseAsync();
            }
        }


        // ---------------------- Dapper (con productos existentes) ----------------------
        public async Task InsertComplexCustomersDapperWithExistingProducts(int numberOfCustomers, SqlConnection sqlConnection)
        {
            // 1. Obtener productos sin cliente (huérfanos)

            //var orphanProducts = await sqlConnection.QueryAsync<Product>(
            //    @"SELECT id, name, description, price, old_price AS OldPrice, brand, 
            //     customer_id AS CustomerId, product_page_id AS ProductPageId 
            //    FROM efdp_product WHERE customer_id IS NULL");

            var needed = 10 * numberOfCustomers;
            var orphanProducts = await sqlConnection.QueryAsync<Product>(
                @"SELECT TOP (@count) id, name, description, price, old_price AS OldPrice, brand, 
                customer_id AS CustomerId, product_page_id AS ProductPageId 
                FROM efdp_product WHERE customer_id IS NULL",
                new { count = needed });


            var orphanList = orphanProducts.ToList();
            if (orphanList.Count < 10 * numberOfCustomers)
            {
                throw new InvalidOperationException(
                    $"Not enough orphan products. Need {10 * numberOfCustomers}, but only {orphanList.Count} available.");
            }

            var rnd = new Random();
            var selectedProducts = orphanList
                .OrderBy(_ => rnd.Next())
                .Take(10 * numberOfCustomers)
                .ToList();

            if (sqlConnection.State == ConnectionState.Closed)
                await sqlConnection.OpenAsync();

            using var transaction = sqlConnection.BeginTransaction();

            try
            {
                int productIndex = 0;

                for (int i = 0; i < numberOfCustomers; i++)
                {
                    var faker = new Faker();

                    // 3a. Crear dirección (con nombres de columna reales)
                    var address = new Address
                    {
                        Id = Guid.NewGuid(),
                        Number = faker.Address.BuildingNumber(),
                        Street = faker.Address.StreetName(),
                        City = faker.Address.City(),
                        Country = faker.Address.Country(),
                        ZipCode = faker.Address.ZipCode(),
                        AdministrativeRegion = faker.Address.CountryCode()
                    };

                    var addressSql = @"
                INSERT INTO efdp_address (Id, number, street, city, country, zip_code, administrative_region)
                VALUES (@Id, @Number, @Street, @City, @Country, @ZipCode, @AdministrativeRegion)";
                    await sqlConnection.ExecuteAsync(addressSql, address, transaction);

                    // 3b. Crear cliente (con nombres de columna reales)
                    var customer = new Customer
                    {
                        Id = Guid.NewGuid(),
                        FirstName = faker.Name.FirstName(),
                        LastName = faker.Name.LastName(),
                        Email = faker.Person.Email,
                        BirthDate = faker.Person.DateOfBirth,
                        Status = faker.Person.Gender.ToString(),
                        AddressId = address.Id
                    };

                    var customerSql = @"
                INSERT INTO efdp_customer (Id, first_name, last_name, email, status, birth_date, address_id)
                VALUES (@Id, @FirstName, @LastName, @Email, @Status, @BirthDate, @AddressId)";
                    await sqlConnection.ExecuteAsync(customerSql, customer, transaction);

                    // 3c. Asignar productos a este cliente
                    var productsForCustomer = selectedProducts
                        .Skip(productIndex)
                        .Take(10)
                        .ToList();

                    foreach (var product in productsForCustomer)
                    {
                        // Crear página de producto (con nombres de columna reales)
                        var page = new ProductPage
                        {
                            Id = Guid.NewGuid(),
                            Title = faker.Lorem.Letter(25),
                            SmallDescription = faker.Lorem.Letter(34),
                            FullDescription = faker.Lorem.Letter(35),
                            ImageLink = faker.Lorem.Letter(45)
                        };

                        var pageSql = @"
                    INSERT INTO efdp_product_page (Id, title, small_description, full_description, image_link)
                    VALUES (@Id, @Title, @SmallDescription, @FullDescription, @ImageLink)";
                        await sqlConnection.ExecuteAsync(pageSql, page, transaction);

                        // Actualizar el producto existente (con nombres de columna reales)
                        var updateProductSql = @"
                    UPDATE efdp_product 
                    SET customer_id = @CustomerId, product_page_id = @ProductPageId 
                    WHERE id = @Id";
                        await sqlConnection.ExecuteAsync(updateProductSql, new
                        {
                            CustomerId = customer.Id,
                            ProductPageId = page.Id,
                            Id = product.Id
                        }, transaction);
                    }

                    productIndex += 10;
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    await sqlConnection.CloseAsync();
            }
        }


        // ---------------------- EF Core ----------------------
        public async Task InsertComplexCustomersEfCore(int interactions, DotNetCoreContext context)
        {
            var customers = new ListTests().ObtenirListCustomersAleatoire(interactions);
            await context.Customers.AddRangeAsync(customers);
            await context.SaveChangesAsync();
        }

        public async Task InsertComplexCustomersEfCoreWithExistingProducts(int numberOfCustomers, DotNetCoreContext context)
        {
            // 1. Get existing products without a customer
            //var orphanProducts = await context.Products
            //    .Where(p => p.CustomerId == null)
            //    .ToListAsync();

            int needed = 10 * numberOfCustomers;
            var orphanProducts = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions
                .ToListAsync(
                    context.Products
                        .Where(p => p.CustomerId == null)
                        .Take(needed)
                );

            //int needed = 10 * numberOfCustomers;
            //var orphanProducts = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions
            //    .ToListAsync(
            //        Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions
            //            .Take(context.Products.Where(p => p.CustomerId == null), needed)
            //    );

            if (orphanProducts.Count < 10 * numberOfCustomers)
            {
                throw new InvalidOperationException(
                    $"Not enough orphan products. Need {10 * numberOfCustomers}, but only {orphanProducts.Count} available.");
            }

            var rnd = new Random();
            var selectedProducts = orphanProducts
                .OrderBy(_ => rnd.Next())
                .Take(10 * numberOfCustomers)
                .ToList();

            int productIndex = 0;

            for (int i = 0; i < numberOfCustomers; i++)
            {
                var faker = new Faker();

                // Create Address
                var address = new Address
                {
                    Id = Guid.NewGuid(),
                    Number = faker.Address.BuildingNumber(),
                    Street = faker.Address.StreetName(),
                    City = faker.Address.City(),
                    Country = faker.Address.Country(),
                    ZipCode = faker.Address.ZipCode(),
                    AdministrativeRegion = faker.Address.CountryCode()
                };
                context.Add(address);

                // Create Customer
                var customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    Email = faker.Person.Email,
                    BirthDate = faker.Person.DateOfBirth,
                    Status = faker.Person.Gender.ToString(),
                    Address = address
                };
                context.Add(customer);

                // Assign existing products
                var productsForCustomer = selectedProducts
                    .Skip(productIndex)
                    .Take(10)
                    .ToList();

                foreach (var product in productsForCustomer)
                {
                    // Create ProductPage
                    var page = new ProductPage
                    {
                        Id = Guid.NewGuid(),
                        Title = faker.Lorem.Letter(25),
                        SmallDescription = faker.Lorem.Letter(34),
                        FullDescription = faker.Lorem.Letter(35),
                        ImageLink = faker.Lorem.Letter(45)
                    };
                    context.Add(page);

                    // Update the existing product
                    product.CustomerId = customer.Id;
                    product.ProductPageId = page.Id;
                    // The product is already tracked, EF Core will detect changes
                }

                productIndex += 10;
            }

            // Save all changes in one transaction
            await context.SaveChangesAsync();
        }


        // ---------------------- EF6 ----------------------
        public async Task InsertComplexCustomersEf6(int interactions, Ef6Context context)
        {
            var customers = new ListTests().ObtenirListCustomersAleatoire(interactions);
            context.Customers.AddRange(customers);
            await context.SaveChangesAsync();
        }

        // ---------------------- EF6 (con productos existentes, optimizado) ----------------------
        public async Task InsertComplexCustomersEf6WithExistingProducts(int numberOfCustomers, Ef6Context context)
        {
            // 1. Desactivar AutoDetectChanges para mejorar el rendimiento
            //context.Configuration.AutoDetectChangesEnabled = false;
            //context.Configuration.AutoDetectChangesEnabled = false;
            context.Database.Log = null;

            // 2. Desactivar logging (si está activo)
            context.Database.Log = null;

            // 3. Obtener productos huérfanos sin tracking (solo lectura)
            //var orphanProducts = await context.Products
            //    .Where(p => p.CustomerId == null)
            //    .ToListAsync();

            int needed = 10 * numberOfCustomers;
            var orphanProducts = await context.Products
                .Where(p => p.CustomerId == null)
                .Take(needed)
                .ToListAsync();

            if (orphanProducts.Count < 10 * numberOfCustomers)
            {
                throw new InvalidOperationException(
                    $"Not enough orphan products. Need {10 * numberOfCustomers}, but only {orphanProducts.Count} available.");
            }

            var rnd = new Random();
            var selectedProducts = orphanProducts
                .OrderBy(_ => rnd.Next())
                .Take(10 * numberOfCustomers)
                .ToList();

            // 4. Usar listas para AddRange (más eficiente)
            var addresses = new List<Address>();
            var customers = new List<Customer>();
            var productPages = new List<ProductPage>();

            int productIndex = 0;

            for (int i = 0; i < numberOfCustomers; i++)
            {
                var faker = new Faker();

                // Create Address
                var address = new Address
                {
                    Id = Guid.NewGuid(),
                    Number = faker.Address.BuildingNumber(),
                    Street = faker.Address.StreetName(),
                    City = faker.Address.City(),
                    Country = faker.Address.Country(),
                    ZipCode = faker.Address.ZipCode(),
                    AdministrativeRegion = faker.Address.CountryCode()
                };
                addresses.Add(address);

                // Create Customer
                var customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    Email = faker.Person.Email,
                    BirthDate = faker.Person.DateOfBirth,
                    Status = faker.Person.Gender.ToString(),
                    AddressId = address.Id // FK directa
                };
                customers.Add(customer);

                // Assign existing products
                var productsForCustomer = selectedProducts
                    .Skip(productIndex)
                    .Take(10)
                    .ToList();

                foreach (var product in productsForCustomer)
                {
                    // Create ProductPage
                    var page = new ProductPage
                    {
                        Id = Guid.NewGuid(),
                        Title = faker.Lorem.Letter(25),
                        SmallDescription = faker.Lorem.Letter(34),
                        FullDescription = faker.Lorem.Letter(35),
                        ImageLink = faker.Lorem.Letter(45)
                    };
                    productPages.Add(page);

                    // Update existing product with FK values
                    product.CustomerId = customer.Id;
                    product.ProductPageId = page.Id;
                }

                productIndex += 10;
            }

            // 5. Añadir todas las entidades nuevas en lote
            context.Address.AddRange(addresses);
            context.Customers.AddRange(customers);
            context.ProductPages.AddRange(productPages);

            // 6. Guardar todo en una sola transacción
            await context.SaveChangesAsync();

            // 7. Reactivar AutoDetectChanges (opcional)
            context.Configuration.AutoDetectChangesEnabled = true;
        }
             



        // ---------------------- EntitySpaces ----------------------
        public async Task InsertComplexCustomersEntitySpaces(int interactions, EntitySpacesService esService)
        {
            // EntitySpacesService ya tiene el método InsertComplexCustomers (síncrono)
            // Lo envolvemos en Task para mantener la firma asíncrona
            await Task.Run(() => esService.InsertComplexCustomersWithExistingProducts(interactions));
        }




    }
}