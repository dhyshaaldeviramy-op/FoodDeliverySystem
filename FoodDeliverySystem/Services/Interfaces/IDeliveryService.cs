namespace FoodDeliverySystem.Services.Interfaces
{
    public interface IDeliveryService
    {
        Task AssignAgent(int orderId);
        Task UpdateLocation(int agentId, double lat, double lng);
    }
}
