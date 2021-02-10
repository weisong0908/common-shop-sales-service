using System.Collections.Generic;

namespace CommonShop.SalesService.Models.Responses
{
    public class ProductListing
    {
        public IEnumerable<Product> Products { get; set; }
        public int ProductCount { get; set; }
    }
}