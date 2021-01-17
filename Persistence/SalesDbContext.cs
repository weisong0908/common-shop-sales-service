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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Fee> Fees { get; set; }

        public SalesDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.ProductId);

            SeedDatabase(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var customerIds = new List<Guid>()
            {
                new Guid("6865a7fa-6866-4516-9002-53cc8386991e"),
                new Guid("f5f1e765-a3bb-44bb-89b9-52ab8eab9db4"),
                new Guid("3a538afc-1441-4c96-bf86-81a18ad0ca04"),
                new Guid("97bdd552-ae59-403a-ba6c-3162d17560ec")
            };

            var addressIds = new List<Guid>()
            {
                new Guid("108e7c96-ea21-44f2-9cbe-db4237c2d1dd"),
                new Guid("41881c20-df28-43df-8e1c-e42748181ea3"),
                new Guid("5df7c00b-3cfd-48e7-a674-6aee0f120313"),
                new Guid("c9871377-210e-4979-a006-a8e156b05147")
            };

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

            var feeIds = new List<Guid>()
            {
                new Guid("132898f9-ef64-474b-884c-d0b7801e9269"),
                new Guid("48173c46-4ad1-4f94-8241-2c2aadd9cd49"),
                new Guid("d7b7454d-0593-48de-aab2-d20a00b3db96"),
                new Guid("02238e28-1b03-48db-94b9-c0b335ae6d7a"),
            };

            var customers = SeedCustomers(customerIds);
            var addresses = SeedAddresses(addressIds, customerIds);
            var products = SeedProducts(productIds, orderIds);
            var fees = SeedFees(feeIds, orderIds);
            var orders = SeedOrders(orderIds, customerIds, products);
            var orderProducts = SeedOrderProducts(orderIds, productIds, products);

            modelBuilder.Entity<Customer>().HasData(customers);
            modelBuilder.Entity<Address>().HasData(addresses);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Fee>().HasData(fees);
            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<OrderProduct>().HasData(orderProducts);
        }

        private IList<Customer> SeedCustomers(IList<Guid> customerIds)
        {
            var customers = new List<Customer>();

            for (int i = 0; i < 4; i++)
            {
                var customer = new Customer()
                {
                    Id = customerIds[i],
                    Name = "John " + i,
                    Phone = "98765432",
                    Email = "weisong0908@gmail.com"
                };

                customers.Add(customer);
            }

            return customers;
        }

        private IList<Address> SeedAddresses(IList<Guid> addressIds, IList<Guid> customerIds)
        {
            var addresses = new List<Address>();

            for (int i = 0; i < 4; i++)
            {
                var address = new Address()
                {
                    Id = addressIds[i],
                    Line1 = $"Block {i} Street {i * 2}",
                    Line2 = $"#{10 - i}-{i * i}",
                    PostalCode = "123456",
                    CustomerId = customerIds[i]
                };

                addresses.Add(address);
            }

            return addresses;
        }

        private IList<Product> SeedProducts(IList<Guid> productIds, IList<Guid> orderIds)
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
                    Category = i % 2 == 0 ? "Category 2" : "Category 1",
                    ThumbnailUrl = "https://bulma.io/images/placeholders/640x480.png",
                    StockLevel = i
                });
            }

            return products;
        }

        private IList<Order> SeedOrders(IList<Guid> orderIds, IList<Guid> customerIds, IList<Product> products)
        {
            var orders = new List<Order>();

            for (int i = 0; i < 4; i++)
            {
                var order = new Order()
                {
                    Id = orderIds[i],
                    Date = DateTime.Today.AddDays(-i),
                    CustomerId = customerIds[i],
                    OrderStatus = OrderStatus.New
                };

                order.TotalPrice = products[i].Price * 2 + 2;

                orders.Add(order);
            }

            return orders;
        }

        private IList<Fee> SeedFees(IList<Guid> feeIds, IList<Guid> orderIds)
        {
            var fees = new List<Fee>();

            for (int i = 0; i < 4; i++)
            {
                var fee = new Fee()
                {
                    Id = feeIds[i],
                    Title = "Shipping fee",
                    Cost = 2,
                    OrderId = orderIds[i]
                };

                fees.Add(fee);

            }

            return fees;
        }

        private IList<OrderProduct> SeedOrderProducts(IList<Guid> orderIds, IList<Guid> productIds, IList<Product> products)
        {
            var orderProducts = new List<OrderProduct>();

            for (int i = 0; i < 4; i++)
            {
                var orderProduct = new OrderProduct()
                {
                    OrderId = orderIds[i],
                    ProductId = productIds[i],
                    Quantity = 2,
                    Amount = products[i].Price * 2
                };

                orderProducts.Add(orderProduct);
            }

            return orderProducts;
        }
    }
}