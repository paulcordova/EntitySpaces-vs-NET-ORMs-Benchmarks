namespace Benchmarks.Tests.Net8.SqlServer
{
    public class ProductPage : Entity
    {
        public string Title { get; set; }
        public string SmallDescription { get; set; }
        public string FullDescription { get; set; }
        public string ImageLink { get; set; }
    }
}