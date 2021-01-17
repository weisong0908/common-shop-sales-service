using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CommonShop.SalesService.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Address PrimaryAddress { get; set; }
        public IList<Order> Orders { get; set; }
    }
}