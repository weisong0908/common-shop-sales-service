using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<int> GetTotalProductCount(string category = "")
        {
            var products = _dbContext
                .Products;

            if (string.IsNullOrWhiteSpace(category))
                return await products.CountAsync();

            return await products
                .Where(p => p.ProductCategory.Title.ToLower() == category.ToLower())
                .CountAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts(int take, int skip = 0, string category = "")
        {
            var products = _dbContext
                .Products
                .Include(p => p.ProductCategory)
                .OrderBy(p => p.Title);

            if (string.IsNullOrWhiteSpace(category))
                return await products
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

            return await products
                .Where(p => p.ProductCategory.Title.ToLower() == category.ToLower())
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
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