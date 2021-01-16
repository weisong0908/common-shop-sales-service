using System;
using System.Linq;
using System.Threading.Tasks;
using CommonShop.SalesService.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderRepository orderRepository, ILogger<OrdersController> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderRepository.GetOrders();

            _logger.LogInformation($"{orders.Count()} order(s) found");

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            var order = await _orderRepository.GetOrder(orderId);

            if (order == null)
            {
                _logger.LogInformation($"Order {orderId} not found");
                return NotFound();
            }

            _logger.LogInformation($"Order {orderId} is found");

            return Ok(order);
        }
    }
}