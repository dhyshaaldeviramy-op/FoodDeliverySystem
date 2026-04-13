using FoodDeliverySystem.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliverySystem.Services.Implementations
{
    public class DeliveryService
    {
        private readonly AppDbContext _context;

        public DeliveryService(AppDbContext context)
        {
            _context = context;
        }

        // Assign nearest available agent
        public async Task AssignAgent(int orderId)
        {
            var agent = await _context.DeliveryAgents
                .Where(a => a.IsAvailable)
                .FirstOrDefaultAsync();

            if (agent == null)
                throw new Exception("No delivery agent available");

            var order = await _context.Orders.FindAsync(orderId);

            order.DeliveryAgentId = agent.Id;
            order.Status = "Assigned";

            agent.IsAvailable = false;

            await _context.SaveChangesAsync();
        }

        // Update agent location
        public async Task UpdateLocation(int agentId, double lat, double lng)
        {
            var agent = await _context.DeliveryAgents.FindAsync(agentId);

            if (agent == null)
                throw new Exception("Agent not found");

            agent.Latitude = lat;
            agent.Longitude = lng;

            await _context.SaveChangesAsync();
        }
    }
}
