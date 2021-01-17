using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CommonShop.SalesService.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string ThumbnailUrl { get; set; }
        public int StockLevel { get; set; }
        [JsonIgnore]
        public IList<OrderProduct> OrderProducts { get; set; }
    }
}