using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarks.Tests.Net8.SqlServer.Dtos
{
    public class FlatCustomerData
    {
        // Customer
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        // Address
        public Guid AddressId { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        // Product
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }

        // ProductPage
        public Guid ProductPageId { get; set; }
        public string Title { get; set; }
        public string SmallDescription { get; set; }
    }
}