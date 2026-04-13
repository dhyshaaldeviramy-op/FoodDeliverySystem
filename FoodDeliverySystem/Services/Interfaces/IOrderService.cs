using FoodDeliverySystem.DTOs.Order;
using FoodDeliverySystem.Models;

namespace FoodDeliverySystem.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponseDto> PlaceOrder(int userId);
        Task<List<OrderResponseDto>> GetOrders(int userId);
    }
}
