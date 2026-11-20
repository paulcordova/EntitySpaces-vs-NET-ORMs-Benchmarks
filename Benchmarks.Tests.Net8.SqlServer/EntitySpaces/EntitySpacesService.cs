using Bogus;
using BusinessObjects;
using Benchmarks.Tests.Net8.SqlServer.Dtos;
using EntitySpaces;
using EntitySpaces.DynamicQuery;
using EntitySpaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benchmarks.Tests.Net8.SqlServer.Tests
{
    public class EntitySpacesService
    {
        private readonly string _connectionString;

        public EntitySpacesService(string connectionString)
        {
            _connectionString = connectionString;
            ConfigureEntitySpaces();
        }

        private void ConfigureEntitySpaces()
        {
            // Configuración de EntitySpaces para SQL Server según la documentación oficial
            // https://mikegriffinreborn.github.io/EntitySpaces/

            // 1. Establecer el factory provider
            // En versiones modernas, se usa esDataProviderFactory
            esProviderFactory.Factory = new EntitySpaces.Loader.esDataProviderFactory();

            // 2. Configurar el elemento de conexión
            esConnectionElement conn = new esConnectionElement();
            conn.Provider = "EntitySpaces.SqlClientProvider"; // Provider para SQL Server[reference:2]
            conn.ConnectionString = _connectionString;

            // 3. Asignar la conexión al manager
            // Nota: La sintaxis exacta puede variar según la versión.
            // En algunas versiones, se asigna directamente a esConnectionString.ConnectionString
            esConfigSettings.ConnectionInfo.Connections.Add(conn);

            // Alternativamente, si usas el enfoque de conexión por nombre:
            // esConnectionManager.Connections.Add(conn);
            // esConnectionManager.DefaultConnectionName = conn.Name;
        }

        /// <summary>
        /// Inserta productos usando EntitySpaces
        /// </summary>
        public async Task InsertSingleProducts(int interactions)
        {
            var products = new ListTests().ObtenirListProductsAleatoire(interactions, null);

            foreach (var product in products)
            {
                // Crear una nueva entidad (clase generada por EntitySpaces Studio)
                // Asumiendo que la clase se llama "Product" y está en el namespace correspondiente
                var esProduct = new EfdpProduct(); // Tu clase generada

                // Mapear propiedades
                esProduct.Id = product.Id;
                esProduct.Name = product.Name;
                esProduct.Description = product.Description;
                esProduct.Price = product.Price;
                esProduct.OldPrice = product.OldPrice;
                esProduct.Brand = product.Brand;
                esProduct.CustomerId = product.CustomerId;

                // Guardar usando el método Save()[reference:3]
                esProduct.Save();
            }

            // Nota: EntitySpaces soporta operaciones asíncronas, pero el método Save()
            // es síncrono. Si necesitas versión asíncrona, verifica si existe SaveAsync().
            await Task.CompletedTask; // Para mantener la firma async
        }

        /// <summary>
        /// Selecciona productos usando EntitySpaces
        /// </summary>
        public async Task<List<Product>> SelectSingleProducts(int take)
        {
            // Crear la consulta usando el generador de consultas fluido
            // Asumimos que las clases generadas se llaman EfdpProductQuery y EfdpProductCollection
            var collection = new EfdpProductQuery("p", out var q)
                .Select(q.Id, q.Name, q.Description, q.Price, q.OldPrice, q.Brand)
                .Top(take)
                .ToCollection<EfdpProductCollection>(); // Especificamos el tipo de colección

            // Mapear los resultados a nuestro DTO Product
            var result = new List<Product>();
            foreach (EfdpProduct esProduct in collection) // EfdpProduct es la entidad generada
            {
                result.Add(new Product
                {
                    //Id = esProduct.Id,
                    Name = esProduct.Name,
                    Description = esProduct.Description,
                    Price = (decimal)esProduct.Price,
                    OldPrice = (decimal)esProduct.OldPrice,
                    Brand = esProduct.Brand
                });
            }

            return await Task.FromResult(result);
        }

        /// <summary>
        /// Versión alternativa usando Load() en lugar de ToCollection()
        /// </summary>
        public async Task<List<Product>> SelectSingleProductsAlt(int take)
        {


            var col = new EfdpProductQuery("p", out var q)
                .Select(q.Id, q.Name, q.Description, q.Price, q.OldPrice, q.Brand)
                .Top(take)
                .ToCollection<EfdpProductCollection>();

            // Cargar la colección usando el query
            if (col.Count > 0)
            {
                var result = new List<Product>();
                // Iterar sobre la colección (cada elemento es de tipo EfdpProduct)
                foreach (EfdpProduct esProduct in col)
                {
                    result.Add(new Product
                    {
                        // Id = esProduct.Id,
                        Name = esProduct.Name,
                        Description = esProduct.Description,
                        Price = (decimal)esProduct.Price,
                        OldPrice = (decimal)esProduct.OldPrice,
                        Brand = esProduct.Brand
                    });
                }
                return result;
            }

            return new List<Product>();
        }

        /// <summary>
        /// Selects complex customers (with Address, Products, and ProductPages) 
        /// using EntitySpaces joins and returns a list of CustomerDto.
        /// </summary>
        public List<CustomerDto> SelectComplexCustomers(int take)
        {
            // Build the query with explicit joins.
            // We use aliases for the virtual columns and store them via "out" parameters.
            esAlias aliasAddressId = null, aliasNumber = null, aliasStreet = null,
                     aliasCity = null, aliasCountry = null, aliasZipCode = null,
                     aliasProductId = null, aliasProductName = null,
                     aliasProductDescription = null, aliasPrice = null, aliasBrand = null,
                     aliasProductPageId = null, aliasTitle = null,
                     aliasSmallDescription = null;

            var flatData = new EfdpCustomerQuery("c", out var c)
                .InnerJoin<EfdpAddressQuery>("ad", out var ad).On(c.AddressId == ad.Id)
                .InnerJoin<EfdpProductQuery>("pr", out var pr).On(c.Id == pr.CustomerId)
                .InnerJoin<EfdpProductPageQuery>("pp", out var pp).On(pr.ProductPageId == pp.Id)
                .Select(
                    // Customer fields (already mapped to EfdpCustomer properties)
                    c.Id.As("CustomerId"),
                    (c.FirstName + " " + c.LastName).As("Name"),
                    c.Email,
                    c.BirthDate,
                    // Address fields (virtual)
                    ad.Id.As("AddressId", out aliasAddressId),
                    ad.Number.As("Number", out aliasNumber),
                    ad.Street.As("Street", out aliasStreet),
                    ad.City.As("City", out aliasCity),
                    ad.Country.As("Country", out aliasCountry),
                    ad.ZipCode.As("ZipCode", out aliasZipCode),
                    // Product fields (virtual)
                    pr.Id.As("ProductId", out aliasProductId),
                    pr.Name.As("ProductName", out aliasProductName),
                    pr.Description.As("ProductDescription", out aliasProductDescription),
                    pr.Price.As("Price", out aliasPrice),
                    pr.Brand.As("Brand", out aliasBrand),
                    // ProductPage fields (virtual)
                    pp.Id.As("ProductPageId", out aliasProductPageId),
                    pp.Title.As("Title", out aliasTitle),
                    pp.SmallDescription.As("SmallDescription", out aliasSmallDescription)
                )
                .Top(take)
                .ToCollection<EfdpCustomerCollection>(); // Collection of EfdpCustomer with virtual columns


            // Now, group in memory using the virtual columns from 'dynamic'
            var result = flatData
                .GroupBy(row => row.Id) // row.Id is the CustomerId (mapped property)
                .Select(group =>
                {
                    var first = group.First();
                    // Access virtual columns via 'dynamic'
                    dynamic dyn = first.dynamic;

                    return new CustomerDto
                    {
                        CustomerId = (Guid)group.Key,
                        Name = first.FirstName,
                        Email = first.Email,
                        BirthDate = (DateTime)first.BirthDate,
                        Address = new AddressDto
                        {
                            AddressId = dyn.AddressId,
                            Number = dyn.Number,
                            Street = dyn.Street,
                            City = dyn.City,
                            Country = dyn.Country,
                            ZipCode = dyn.ZipCode
                        },
                        Products = group
                            .Where(row => row.dynamic.ProductId != Guid.Empty)
                            .Select(row =>
                            {
                                dynamic r = row.dynamic;
                                return new ProductDto
                                {
                                    ProductId = r.ProductId,
                                    Name = r.ProductName,
                                    Description = r.ProductDescription,
                                    Price = r.Price,
                                    Brand = r.Brand,
                                    ProductPage = new ProductPageDto
                                    {
                                        ProductPageId = r.ProductPageId,
                                        Title = r.Title,
                                        Description = r.SmallDescription
                                    }
                                };
                            })
                            .ToList()
                    };
                })
                .ToList();

            return result;

        }


        /// <summary>
        /// Inserts complex customers using EntitySpaces cascade save.
        /// - Takes existing products without a customer (randomly selected)
        /// - Creates new addresses and product pages
        /// - Assigns products to customers via navigation properties
        /// - Saves the customer collection, which propagates all changes
        /// </summary>
        public void InsertComplexCustomersWithExistingProducts(int numberOfCustomers)
        {
            // 1. Get existing products without a customer
            //var orphanProducts = new EfdpProductQuery("p", out var p)
            //    .Where(p.CustomerId.IsNull())
            //    .ToCollection<EfdpProductCollection>();

            var orphanProducts = new EfdpProductQuery("p", out var p)
                .Where(p.CustomerId.IsNull())
                //.OrderBy("NEWID()") // si es posible
                .Top(10 * numberOfCustomers)
                .ToCollection<EfdpProductCollection>();

            if (orphanProducts.Count < 10 * numberOfCustomers)
            {
                throw new InvalidOperationException(
                    $"Not enough orphan products. Need {10 * numberOfCustomers}, but only {orphanProducts.Count} available.");
            }

            // 2. Shuffle and select the needed products
            var rnd = new Random();
            var selectedProducts = orphanProducts
                .OrderBy(_ => rnd.Next())
                .Take(10 * numberOfCustomers)
                .ToList();

            // 3. Create customers, addresses, and pages
            var customerCollection = new EfdpCustomerCollection();
            int productIndex = 0;

            for (int i = 0; i < numberOfCustomers; i++)
            {
                var faker = new Faker();

                // 3a. Create Address (new node)
                var address = new EfdpAddress
                {
                    Id = Guid.NewGuid(),
                    Number = faker.Address.BuildingNumber(),
                    Street = faker.Address.StreetName(),
                    City = faker.Address.City(),
                    Country = faker.Address.Country(),
                    ZipCode = faker.Address.ZipCode(),
                    AdministrativeRegion = faker.Address.CountryCode()
                };

                // 3b. Create Customer (new node)
                var customer = new EfdpCustomer
                {
                    Id = Guid.NewGuid(),
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    Email = faker.Person.Email,
                    BirthDate = faker.Person.DateOfBirth,
                    Status = faker.Person.Gender.ToString(),
                    UpToEfdpAddressByAddressId = address        // Navigation property – establishes the relationship
                };

                // 3c. Assign 10 existing products to this customer
                var productsForCustomer = selectedProducts
                    .Skip(productIndex)
                    .Take(10)
                    .ToList();

                foreach (var product in productsForCustomer)
                {
                    // Create ProductPage (new node) for each product
                    var page = new EfdpProductPage
                    {
                        Id = Guid.NewGuid(),
                        Title = faker.Lorem.Letter(25),
                        SmallDescription = faker.Lorem.Letter(34),
                        FullDescription = faker.Lorem.Letter(35),
                        ImageLink = faker.Lorem.Letter(45)
                    };

                    // Assign the page to the product (navigation property)
                    product.UpToEfdpProductPageByProductPageId = page;

                    // 🔥 CRUCIAL: Set the CustomerId explicitly to mark the product as modified
                    product.CustomerId = customer.Id;


                    // Add the product to the customer's Products collection (navigation property)
                    // This establishes the relationship: product → customer and product → page
                    //customer.Products.Add(product);
                    customer.EfdpProductCollectionByCustomerId.Add(product);

                }

                productIndex += 10;

                // Add customer to the collection
                customerCollection.Add(customer);
            }

            // 4. Save the customer collection – EntitySpaces will cascade:
            //    - Insert all addresses (because they are referenced by customers)
            //    - Insert all customers
            //    - Insert all product pages (because they are referenced by products)
            //    - Update all products (set CustomerId and ProductPageId)
            //    - All in the correct order, respecting FK constraints
            customerCollection.Save();
        }

        /// <summary>
        /// Carga un número exacto de direcciones con todos sus clientes, productos y páginas.
        /// Usa subconsulta para limitar el número de direcciones raíz.
        /// </summary>
        public async Task <List<AddressDto>> SelectComplexAddresses(int take)
        {
            // 1. Subconsulta para obtener los primeros 'take' Address Ids
            var subQuery = new EfdpAddressQuery("o", out var QueryAddress)
                .Select(QueryAddress.Id)
                .Top(take);

            // 2. Consulta principal con joins y proyección
            esAlias aliasAddressId = null, aliasNumber = null, aliasStreet = null,
                     aliasCity = null, aliasCountry = null, aliasZipCode = null,
                     aliasCustomerId = null, aliasFirstName = null, aliasLastName = null,
                     aliasEmail = null, aliasBirthDate = null,
                     aliasProductId = null, aliasProductName = null, aliasProductDescription = null,
                     aliasPrice = null, aliasBrand = null,
                     aliasProductPageId = null, aliasTitle = null, aliasSmallDescription = null;

            var flatData = new EfdpAddressQuery("ad", out var ad)
                .InnerJoin<EfdpCustomerQuery>("c", out var c).On(ad.Id == c.AddressId)
                .InnerJoin<EfdpProductQuery>("p", out var p).On(c.Id == p.CustomerId)
                .InnerJoin<EfdpProductPageQuery>("pp", out var pp).On(p.ProductPageId == pp.Id)
                .Where(ad.Id.In(subQuery))   // 🔥 Filtro por los ids de la subconsulta
                .Select(
                    // Address fields
                    ad.Id.As("AddressId", out aliasAddressId),
                    ad.Number.As("Number", out aliasNumber),
                    ad.Street.As("Street", out aliasStreet),
                    ad.City.As("City", out aliasCity),
                    ad.Country.As("Country", out aliasCountry),
                    ad.ZipCode.As("ZipCode", out aliasZipCode),
                    // Customer fields
                    c.Id.As("CustomerId", out aliasCustomerId),
                    c.FirstName.As("FirstName", out aliasFirstName),
                    c.LastName.As("LastName", out aliasLastName),
                    c.Email.As("Email", out aliasEmail),
                    c.BirthDate.As("BirthDate", out aliasBirthDate),
                    // Product fields
                    p.Id.As("ProductId", out aliasProductId),
                    p.Name.As("ProductName", out aliasProductName),
                    p.Description.As("ProductDescription", out aliasProductDescription),
                    p.Price.As("Price", out aliasPrice),
                    p.Brand.As("Brand", out aliasBrand),
                    // ProductPage fields
                    pp.Id.As("ProductPageId", out aliasProductPageId),
                    pp.Title.As("Title", out aliasTitle),
                    pp.SmallDescription.As("SmallDescription", out aliasSmallDescription)
                )
                .ToCollection<EfdpAddressCollection>();

            // 3. Agrupación en memoria para construir el grafo anidado
            // The entity Id is not part of the projection (the query selects the aliased
            // AddressId column), so grouping by row.Id collapses every address into one
            // group. Group by the projected alias instead.
            var result = flatData
                .GroupBy(row => (Guid)row.dynamic.AddressId) // AddressId is the projected alias
                .Select(addressGroup =>
                {
                    var firstAddress = addressGroup.First();
                    dynamic addr = firstAddress.dynamic;

                    return new AddressDto
                    {
                        AddressId = addr.AddressId,
                        Number = addr.Number,
                        Street = addr.Street,
                        City = addr.City,
                        Country = addr.Country,
                        ZipCode = addr.ZipCode,
                        Customers = addressGroup
                            .Where(row => row.dynamic.CustomerId != Guid.Empty)
                            .GroupBy(row => row.dynamic.CustomerId)
                            .Select(customerGroup =>
                            {
                                var firstCustomer = customerGroup.First();
                                dynamic cust = firstCustomer.dynamic;

                                return new CustomerDto
                                {
                                    CustomerId = cust.CustomerId,
                                    Name = cust.FirstName + " " + cust.LastName,
                                    Email = cust.Email,
                                    BirthDate = cust.BirthDate,
                                    Products = customerGroup
                                        .Where(row => row.dynamic.ProductId != Guid.Empty)
                                        .Select(row =>
                                        {
                                            dynamic prod = row.dynamic;
                                            return new ProductDto
                                            {
                                                ProductId = prod.ProductId,
                                                Name = prod.ProductName,
                                                Description = prod.ProductDescription,
                                                Price = prod.Price,
                                                Brand = prod.Brand,
                                                ProductPage = new ProductPageDto
                                                {
                                                    ProductPageId = prod.ProductPageId,
                                                    Title = prod.Title,
                                                    Description = prod.SmallDescription,
                                                    ImageLink = null // si no lo trajiste, puedes dejarlo nulo
                                                }
                                            };
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


    } //end class
} // end namespace