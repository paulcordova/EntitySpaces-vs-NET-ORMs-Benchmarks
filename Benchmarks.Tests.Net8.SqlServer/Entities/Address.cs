using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TableAttribute = System.ComponentModel.DataAnnotations.Schema.TableAttribute;

namespace Benchmarks.Tests.Net8.SqlServer
{
    public class Address : Entity
    {
        [Column("number")]  // Mapea a la columna "number" en la BD
        public string Number { get; set; }

        [Column("street")]
        public string Street { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("zip_code")]
        public string ZipCode { get; set; }

        [Column("administrative_region")]
        public string AdministrativeRegion { get; set; }

        // Relación uno a muchos con Customer
        public ICollection<Customer> Customers { get; set; }
    }
}
