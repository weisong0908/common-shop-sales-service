using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonShop.SalesService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommonShop.SalesService.Persistence
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly SalesDbContext _dbContext;

        public OrdersRepository(SalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetTotalOrderCount()
        {
            var orders = _dbContext
                .Orders;

            return await orders.CountAsync();
        }

        public async Task<IEnumerable<Order>> GetOrders(int take, int skip = 0)
        {
            var orders = _dbContext.Orders;

            return await orders
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<Order> GetOrder(Guid id)
        {
            var order = await _dbContext
                .Orders
                .Include(o => o.Customer)
                .ThenInclude(c => c.PrimaryAddress)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Include(o => o.Fees)
                .SingleOrDefaultAsync(o => o.Id == id);

            return order;
        }
    }
}