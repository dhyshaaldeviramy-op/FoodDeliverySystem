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

        [HttpPost("{userId}")]
        public async Task<IActionResult> PlaceOrder(int userId)
        {
            var result = await _service.PlaceOrder(userId);
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrders(int userId)
        {
            var data = await _service.GetOrders(userId);
            return Ok(data);
        }
    }
}
