using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonShop.SalesService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommonShop.SalesService.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly SalesDbContext _dbContext;
        public ProductRepository(SalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _dbContext
                .Products
                .ToListAsync();

            return products;
        }

        public async Task<Product> GetProduct(Guid id)
        {
            var product = await _dbContext
                .Products
                .SingleOrDefaultAsync(p => p.Id == id);

            return product;
        }
    }
}