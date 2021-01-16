using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonShop.SalesService.Models;

namespace CommonShop.SalesService.Persistence
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(Guid id);
        Task<IEnumerable<Product>> GetProducts();
    }
}