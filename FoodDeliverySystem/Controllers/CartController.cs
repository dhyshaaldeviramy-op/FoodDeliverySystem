using FoodDeliverySystem.DTOs.Cart;
using FoodDeliverySystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliverySystem.Controllers{
   

    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpPost("add/{userId}")]
        public async Task<IActionResult> AddToCart(int userId, AddToCartDto dto)
        {
            await _service.AddToCart(userId, dto);
            return Ok("Item added to cart");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            var data = await _service.GetCart(userId);
            return Ok(data);
        }

        [HttpDelete("{itemId}")]
        public async Task<IActionResult> RemoveItem(int itemId)
        {
            await _service.RemoveItem(itemId);
            return Ok("Item removed");
        }

    }
}
