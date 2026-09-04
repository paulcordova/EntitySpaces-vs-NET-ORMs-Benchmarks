using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benchmarks.Tests.Net8.SqlServer
{
    public class Customer : Entity
    {
        public Guid Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Column("address_id")]
        public Guid? AddressId { get; set; }

        // NAvegacion
        public Address Address { get; set; }
        public ICollection<Product> Products { get; set; }
        
    }
}
