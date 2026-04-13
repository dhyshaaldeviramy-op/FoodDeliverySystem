using Microsoft.AspNetCore.Http;
using FoodDeliverySystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliverySystem.Controllers
{
    

    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost("place")]
        public async Task<IActionResult> PlaceOrder(int userId)
        {
            var order = await _service.PlaceOrder(userId);
            return Ok(order);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrders(int userId)
        {
            return Ok(await _service.GetOrders(userId));
        }

        [HttpGet("details/{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            return Ok(await _service.GetOrderById(orderId));
        }
    }
}
