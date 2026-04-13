using FoodDeliverySystem.Data;
using FoodDeliverySystem.Models;
using FoodDeliverySystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliverySystem.Services.Implementations
{
    public class MenuService: IMenuService
    {
        private readonly AppDbContext _context;

        public MenuService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuItem>> GetByRestaurant(int restaurantId)
        {
            return await _context.MenuItems
                .Where(m => m.RestaurantId == restaurantId)
                .ToListAsync();
        }
    }
}
