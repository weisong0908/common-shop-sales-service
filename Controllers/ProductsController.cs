using System;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using CommonShop.SalesService.Models;
using CommonShop.SalesService.Models.Requests;
using CommonShop.SalesService.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CommonShop.SalesService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductsRepository productRepository, IUnitOfWork unitOfWork, ILogger<ProductsController> logger)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetProducts();

            _logger.LogInformation($"{products.Count()} product(s) found");

            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var product = await _productRepository.GetProduct(productId);

            if (product == null)
            {
                _logger.LogInformation($"Product {productId} not found");
                return NotFound();
            }

            _logger.LogInformation($"Product {productId} is found");

            return Ok(product);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateProduct(ProductModification productModification)
        {
            var product = new Product();
            product.Title = productModification.Title;
            product.Description = productModification.Description;
            product.Price = productModification.Price;
            product.StockLevel = productModification.StockLevel;
            product.ThumbnailUrl = productModification.ThumbnailUrl;

            var category = (await _productRepository.GetProductCategories()).SingleOrDefault(pc => pc.Title == productModification.Category);
            if (category == null)
                return NotFound();

            product.ProductCategory = category;

            _productRepository.CreateProduct(product);

            await _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(GetProduct), new { productId = product.Id }, product);
        }

        [HttpPut("{productId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateProduct(Guid productId, ProductModification productModification)
        {
            if (productId != productModification.Id)
                return BadRequest();

            var product = await _productRepository.GetProduct(productId);

            if (product == null)
                return NotFound();

            product.Title = productModification.Title;
            product.Description = productModification.Description;
            product.Price = productModification.Price;
            product.StockLevel = productModification.StockLevel;
            product.ThumbnailUrl = productModification.ThumbnailUrl;

            var category = (await _productRepository.GetProductCategories()).SingleOrDefault(pc => pc.Title == productModification.Category);
            if (category == null)
                return NotFound("Category not found");

            product.ProductCategory = category;

            _productRepository.UpdateProduct(product);

            await _unitOfWork.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var product = await _productRepository.GetProduct(productId);
            if (product == null)
            {
                _logger.LogInformation($"Product {productId} not found");
                return NotFound();
            }

            _productRepository.DeleteProduct(product);

            await _unitOfWork.SaveChanges();

            return NoContent();
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetProductCategories()
        {
            var productCategories = await _productRepository.GetProductCategories();

            _logger.LogInformation($"{productCategories.Count()} productCategories found");

            return Ok(productCategories);
        }
    }
}