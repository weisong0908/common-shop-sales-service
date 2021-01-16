using System;
using System.Text.Json.Serialization;

namespace CommonShop.SalesService.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string ThumbnailUrl { get; set; }
        public int StockLevel { get; set; }
        public Guid OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
    }
}