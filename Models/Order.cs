using System;
using System.Collections.Generic;

namespace CommonShop.SalesService.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Guid Customer { get; set; }
        public Guid ShippingAddress { get; set; }
        // public IEnumerable<Guid> Fees { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}