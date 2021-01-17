using System;
using System.Text.Json.Serialization;

namespace CommonShop.SalesService.Models
{
    public class OrderProduct
    {
        [JsonIgnore]
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}