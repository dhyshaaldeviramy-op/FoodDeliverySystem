using FoodDeliverySystem.Data;
using FoodDeliverySystem.Models;
using FoodDeliverySystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliverySystem.Services.Implementations
{
    public class RestaurantService: IRestaurantService
    {
        private readonly AppDbContext _context;

        public RestaurantService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Restaurant>> GetAll()
        {
            return await _context.Restaurants.ToListAsync();
        }
    }
}
