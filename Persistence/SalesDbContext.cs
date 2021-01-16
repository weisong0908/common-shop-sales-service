using Microsoft.EntityFrameworkCore;
using CommonShop.SalesService.Models;
using System.Collections.Generic;
using System;

namespace CommonShop.SalesService.Persistence
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public SalesDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedDatabase(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var productIds = new List<Guid>()
            {
                new Guid("de039434-d200-43b9-8191-79869c895821"),
                new Guid("d6a76809-7088-465d-bfe8-4d95c4f38c40"),
                new Guid("387ba502-67ff-4cc5-ab50-15d436a4b455"),
                new Guid("a14ac91b-1ad1-40c4-8092-d08109e5ca78"),
                new Guid("c0cd14c3-c55c-4b94-a4bd-7298e7eff811"),
                new Guid("e10fcad7-a24f-416f-a43e-0fc1fce71727"),
                new Guid("3c72192c-578f-4e37-9061-029f70f94b8b"),
                new Guid("5114e1c1-0ad1-44bc-88cb-cbe70ee07c3e"),
                new Guid("b6890fea-68a6-4188-aec2-9e99c71f0c9a"),
                new Guid("48347309-5131-4cbc-aed7-9a64b40059c4"),
            };

            var orderIds = new List<Guid>()
            {
                new Guid("e148921a-f292-4078-8004-120a392836ab"),
                new Guid("e0c33624-316f-454e-9952-c4b88f6f4318"),
                new Guid("cf8df904-dc82-4f7f-8cf8-84dd03fee8bd"),
                new Guid("06706a27-4213-4d6c-a3c6-8789462b2f5c")
            };

            var products = CreateProducts(productIds, orderIds);

            modelBuilder.Entity<Product>().HasData(products);

            var orders = CreateOrders(orderIds, products);

            modelBuilder.Entity<Order>().HasData(orders);


        }

        private IList<Product> CreateProducts(IList<Guid> productIds, IList<Guid> orderIds)
        {
            var products = new List<Product>();

            for (int i = 1; i <= 10; i++)
            {
                products.Add(new Product()
                {
                    Id = productIds[i - 1],
                    Title = "Product " + i,
                    Description = "Some description",
                    Price = i * 10,
                    Quantity = i % 3 + 1,
                    Category = i % 2 == 0 ? "Category 2" : "Category 1",
                    ThumbnailUrl = "https://bulma.io/images/placeholders/640x480.png",
                    OrderId = orderIds[i % 4]
                });
            }

            return products;
        }

        private IList<Order> CreateOrders(IList<Guid> orderIds, IList<Product> products)
        {
            var orders = new List<Order>();

            var guids = new List<Guid>()
            {
                new Guid("e148921a-f292-4078-8004-120a392836ab"),
                new Guid("e0c33624-316f-454e-9952-c4b88f6f4318"),
                new Guid("cf8df904-dc82-4f7f-8cf8-84dd03fee8bd"),
                new Guid("06706a27-4213-4d6c-a3c6-8789462b2f5c")
            };

            for (int i = 0; i < 4; i++)
            {
                var order = new Order()
                {
                    Id = guids[i],
                    Date = DateTime.Today.AddDays(-i),
                    // Products = new List<Product>() { products[i], products[i + 1] },
                    Customer = Guid.Empty,
                    ShippingAddress = Guid.Empty,
                    // Fees = new List<Guid>() { Guid.Empty },
                    OrderStatus = OrderStatus.New
                };
                order.TotalPrice = products[i].Price * products[i].Quantity + products[i + 1].Price * products[i + 1].Quantity;

                orders.Add(order);
            }

            return orders;
        }
    }
}