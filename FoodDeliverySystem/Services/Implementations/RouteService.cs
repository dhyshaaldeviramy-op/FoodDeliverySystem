using FoodDeliverySystem.Services.Interfaces;

namespace FoodDeliverySystem.Services.Implementations
{
    public class RouteService: IRouteService
    {
        public async Task<string> GetRoute(double sLat, double sLng, double dLat, double dLng)
        {
            return $"Route from ({sLat},{sLng}) to ({dLat},{dLng})";
        }
    }
}
