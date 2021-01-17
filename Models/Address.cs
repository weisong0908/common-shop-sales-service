using System;
using System.Text.Json.Serialization;

namespace CommonShop.SalesService.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string PostalCode { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
    }
}