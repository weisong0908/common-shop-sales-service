using System;
using System.Linq;
using System.Threading.Tasks;
using CommonShop.SalesService.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CommonShop.SalesService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductRepository productRepository, ILogger<ProductsController> logger)
        {
            _productRepository = productRepository;
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
    }
}