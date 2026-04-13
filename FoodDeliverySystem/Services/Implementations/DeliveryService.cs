using FoodDeliverySystem.Data;
using FoodDeliverySystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliverySystem.Services.Implementations
{
    public class DeliveryService: IDeliveryService
    {
        private readonly AppDbContext _context;

        public DeliveryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AssignAgent(int orderId)
        {
            var agent = await _context.DeliveryAgents
                .FirstOrDefaultAsync(a => a.IsAvailable);

            var order = await _context.Orders.FindAsync(orderId);

            order.DeliveryAgentId = agent.Id;
            order.Status = "Out for Delivery";

            agent.IsAvailable = false;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateLocation(int agentId, double lat, double lng)
        {
            var agent = await _context.DeliveryAgents.FindAsync(agentId);

            agent.Latitude = lat;
            agent.Longitude = lng;

            await _context.SaveChangesAsync();
        }
    }
}
