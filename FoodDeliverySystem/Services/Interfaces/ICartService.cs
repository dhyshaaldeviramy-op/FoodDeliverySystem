using FoodDeliverySystem.Models;
namespace FoodDeliverySystem.Services.Interfaces
{
    public interface ICartService
    {
        Task AddToCart(int userId, int menuItemId, string name, decimal price, int quantity);
        Task RemoveFromCart(int itemId);
        Task<Cart> GetCart(int userId);
    }
}
