using System;
using System.Text.Json.Serialization;

namespace CommonShop.SalesService.Models
{
    public class Fee
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}