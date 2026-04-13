using FoodDeliverySystem.DTOs.Delivery;
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

        // Assign delivery agent
        [HttpPost("assign")]
        public async Task<IActionResult> AssignAgent(AssignAgentDto dto)
        {
            await _deliveryService.AssignAgent(dto.OrderId);
            return Ok("Agent Assigned");
        }

        // Update location (REAL-TIME 🔥)
        [HttpPost("update-location")]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto dto)
        {
            await _deliveryService.UpdateLocation(dto.AgentId, dto.Latitude, dto.Longitude);

            // Send live update
            await _hub.Clients.All.SendAsync("ReceiveLocation", new
            {
                OrderId = dto.OrderId,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude
            });

            return Ok("Location Updated");
        }

        // Route optimization
        [HttpGet("route")]
        public async Task<IActionResult> GetRoute(double sLat, double sLng, double dLat, double dLng)
        {
            var route = await _routeService.GetRoute(sLat, sLng, dLat, dLng);
            return Ok(route);
        }

    }
}
