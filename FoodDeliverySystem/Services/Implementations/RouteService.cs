namespace FoodDeliverySystem.Services.Implementations
{
    public class RouteService
    {
        public async Task<string> GetOptimalRoute(double sourceLat, double sourceLng,
                                            double destLat, double destLng)
        {
            // Normally call Google Maps API here
            // For now return dummy route

            return $"Route from ({sourceLat},{sourceLng}) to ({destLat},{destLng})";
        }
    }
}
