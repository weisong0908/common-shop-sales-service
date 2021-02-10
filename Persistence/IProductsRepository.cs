using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonShop.SalesService.Models;

namespace CommonShop.SalesService.Persistence
{
    public interface IProductsRepository
    {
        Task<Product> GetProduct(Guid id);
        Task<int> GetTotalProductCount(string category = "");
        Task<IEnumerable<Product>> GetProducts(int take, int skip = 0, string category = "");
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Task<IEnumerable<ProductCategory>> GetProductCategories();
    }
}