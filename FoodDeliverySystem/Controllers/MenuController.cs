using FoodDeliverySystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _service;

        public MenuController(IMenuService service)
        {
            _service = service;
        }

        [HttpGet("{restaurantId}")]
        public async Task<IActionResult> GetMenu(int restaurantId)
        {
            var data = await _service.GetByRestaurant(restaurantId);
            return Ok(data);
        }
    }
}
