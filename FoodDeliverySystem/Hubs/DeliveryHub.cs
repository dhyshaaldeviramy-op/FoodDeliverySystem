using Microsoft.AspNetCore.SignalR;

namespace FoodDeliverySystem.Hubs
{
    public class DeliveryHub:Hub
    {
        public async Task SendLocation(int orderId, double lat, double lng)
        {
            await Clients.All.SendAsync("ReceiveLocation", new
            {
                OrderId = orderId,
                Latitude = lat,
                Longitude = lng
            });
        }
    }
}
