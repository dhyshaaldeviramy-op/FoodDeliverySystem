using FoodDeliverySystem.Models;

namespace FoodDeliverySystem.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> PlaceOrder(int userId);
        Task<List<Order>> GetOrders(int userId);
        Task<Order> GetOrderById(int orderId);
    }
}
