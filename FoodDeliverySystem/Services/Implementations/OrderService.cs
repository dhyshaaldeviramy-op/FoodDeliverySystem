namespace FoodDeliverySystem.Services.Implementations
{
    using FoodDeliverySystem.Data;
    using FoodDeliverySystem.DTOs.Order;
    using FoodDeliverySystem.Models;
    using FoodDeliverySystem.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrderResponseDto> PlaceOrder(int userId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.MenuItem)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            var order = new Order
            {
                UserId = userId,
                Status = "Pending",
                TotalAmount = cart.Items.Sum(i => i.Price * i.Quantity),
                Items = cart.Items.Select(i => new OrderItem
                {
                    MenuItemId = i.MenuItemId,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.CartItems.RemoveRange(cart.Items);

            await _context.SaveChangesAsync();

            return new OrderResponseDto
            {
                Id = order.Id,
                TotalAmount = order.TotalAmount,
                Status = order.Status
            };
        }

        public async Task<List<OrderResponseDto>> GetOrders(int userId)
        {
            var orders = await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.MenuItem)
                .Where(o => o.UserId == userId)
                .ToListAsync();

            return orders.Select(o => new OrderResponseDto
            {
                Id = o.Id,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                Items = o.Items.Select(i => new OrderItemDetailsDto
                {
                    MenuItemName = i.MenuItem.Name,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            }).ToList();
        }
    }
}
