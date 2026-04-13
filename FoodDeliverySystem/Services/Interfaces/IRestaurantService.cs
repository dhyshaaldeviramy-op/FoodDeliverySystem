using FoodDeliverySystem.Models;

namespace FoodDeliverySystem.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task<List<Restaurant>> GetAll();
    }
}
