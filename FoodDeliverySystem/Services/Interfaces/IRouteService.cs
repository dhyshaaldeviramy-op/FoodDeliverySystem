namespace FoodDeliverySystem.Services.Interfaces
{
    public interface IRouteService
    {
        Task<string> GetRoute(double sLat, double sLng, double dLat, double dLng);

    }
}
