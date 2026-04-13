using FoodDeliverySystem.Hubs;
using FoodDeliverySystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {

        private readonly IDeliveryService _deliveryService;
        private readonly IRouteService _routeService;
        private readonly IHubContext<DeliveryHub> _hub;

        public DeliveryController(
            IDeliveryService deliveryService,
            IRouteService routeService,
            IHubContext<DeliveryHub> hub)
        {
            _deliveryService = deliveryService;
            _routeService = routeService;
            _hub = hub;
        }

        // Assign agent
        [HttpPost("assign/{orderId}")]
        public async Task<IActionResult> AssignAgent(int orderId)
        {
            await _deliveryService.AssignAgent(orderId);
            return Ok("Agent Assigned");
        }

        // Update location (called by delivery agent app)
        [HttpPost("update-location")]
        public async Task<IActionResult> UpdateLocation(int agentId, double lat, double lng, int orderId)
        {
            await _deliveryService.UpdateLocation(agentId, lat, lng);

            // Send real-time update
            await _hub.Clients.All.SendAsync("ReceiveLocation", new
            {
                OrderId = orderId,
                Latitude = lat,
                Longitude = lng
            });

            return Ok();
        }

        // Get optimized route
        [HttpGet("route")]
        public async Task<IActionResult> GetRoute(double sLat, double sLng, double dLat, double dLng)
        {
            var route = await _routeService.GetOptimalRoute(sLat, sLng, dLat, dLng);
            return Ok(route);
        }
    }
}
