using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodDeliverySystem.Services.Interfaces;

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

        // Add item to cart
        [HttpPost("add")]
        public async Task<IActionResult> Add(
            int userId,
            int menuItemId,
            string name,
            decimal price,
            int quantity)
        {
            await _service.AddToCart(userId, menuItemId, name, price, quantity);
            return Ok("Item added to cart");
        }

        // Remove item
        [HttpDelete("remove/{itemId}")]
        public async Task<IActionResult> Remove(int itemId)
        {
            await _service.RemoveFromCart(itemId);
            return Ok("Item removed");
        }

        // Get cart
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            var cart = await _service.GetCart(userId);
            return Ok(cart);
        }
    }
}
