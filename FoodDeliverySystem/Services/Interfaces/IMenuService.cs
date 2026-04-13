using FoodDeliverySystem.Models;

namespace FoodDeliverySystem.Services.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuItem>> GetByRestaurant(int restaurantId);
    }
}
