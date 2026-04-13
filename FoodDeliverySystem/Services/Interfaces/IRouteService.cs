namespace FoodDeliverySystem.Services.Interfaces
{
    public interface IRouteService
    {
        Task<string> GetOptimalRoute(double sourceLat, double sourceLng,
                            double destLat, double destLng);

    }
}
