using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonShop.SalesService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommonShop.SalesService.Persistence
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SalesDbContext _dbContext;

        public OrderRepository(SalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var orders = await _dbContext.Orders.ToListAsync();

            return orders;
        }

        public async Task<Order> GetOrder(Guid id)
        {
            var order = await _dbContext
                .Orders
                .Include(o => o.OrderProducts)
                .SingleOrDefaultAsync(o => o.Id == id);

            return order;
        }
    }
}