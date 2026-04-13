using FoodDeliverySystem.DTOs.Cart;
using FoodDeliverySystem.Models;
namespace FoodDeliverySystem.Services.Interfaces
{
    public interface ICartService
    {
        Task AddToCart(int userId, AddToCartDto dto);
        Task<CartResponseDto> GetCart(int userId);
        Task RemoveItem(int itemId);
    }
}
