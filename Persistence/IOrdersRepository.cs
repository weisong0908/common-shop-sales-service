using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonShop.SalesService.Models;

namespace CommonShop.SalesService.Persistence
{
    public interface IOrdersRepository
    {
        Task<int> GetTotalOrderCount();
        Task<Order> GetOrder(Guid id);
        Task<IEnumerable<Order>> GetOrders(int take, int skip = 0);
    }
}