using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarks.Tests.Net8.SqlServer.DtoDapper
{
    public class ProductDtoDapper
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public ProductPageDtoDapper ProductPage { get; set; }
    }
}
