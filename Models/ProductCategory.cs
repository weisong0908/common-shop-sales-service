using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CommonShop.SalesService.Models
{
    public class ProductCategory
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        [JsonIgnore]
        public IList<Product> Products { get; set; }
    }
}