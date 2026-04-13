namespace FoodDeliverySystem.Services.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using FoodDeliverySystem.Data;
    using FoodDeliverySystem.Models;
    using FoodDeliverySystem.Services.Interfaces;
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> PlaceOrder(int userId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null || !cart.Items.Any())
                throw new Exception("Cart is empty");

            var orderItems = cart.Items.Select(i => new OrderItem
            {
                MenuItemId = i.MenuItemId,
                Quantity = i.Quantity,
                Price = i.Price
            }).ToList();

            var totalAmount = orderItems.Sum(i => i.Price * i.Quantity);

            var order = new Order
            {
                UserId = userId,
                Status = "Pending",
                TotalAmount = totalAmount,
                Items = orderItems
            };

            _context.Orders.Add(order);

            // 🔥 Clear cart after placing order
            _context.CartItems.RemoveRange(cart.Items);

            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>> GetOrders(int userId)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
