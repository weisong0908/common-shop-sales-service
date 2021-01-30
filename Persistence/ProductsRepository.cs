using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonShop.SalesService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommonShop.SalesService.Persistence
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly SalesDbContext _dbContext;
        public ProductsRepository(SalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _dbContext
                .Products
                .Include(p => p.ProductCategory)
                .ToListAsync();

            return products;
        }

        public async Task<Product> GetProduct(Guid id)
        {
            var product = await _dbContext
                .Products
                .Include(p => p.ProductCategory)
                .SingleOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public void CreateProduct(Product product)
        {
            _dbContext.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
        }

        public void DeleteProduct(Product product)
        {
            _dbContext.Remove(product);
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            var productCategories = await _dbContext
                .ProductCategories
                .ToListAsync();

            return productCategories;
        }
    }
}