
using FoodDeliverySystem.Data;
using FoodDeliverySystem.Models;
using FoodDeliverySystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliverySystem.Services.Implementations
{
    using Microsoft.EntityFrameworkCore;

    public class CartService : ICartService
    {
        private readonly AppDbContext _context;

        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddToCart(int userId, int menuItemId, string name, decimal price, int quantity)
        {
            if (quantity <= 0)
                throw new Exception("Quantity must be greater than 0");

            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    Items = new List<CartItem>()
                };

                _context.Carts.Add(cart);
            }

            var existingItem = cart.Items
                .FirstOrDefault(i => i.MenuItemId == menuItemId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Items.Add(new CartItem
                {
                    MenuItemId = menuItemId,
                    Name = name,
                    Price = price,
                    Quantity = quantity
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCart(int itemId)
        {
            var item = await _context.CartItems.FindAsync(itemId);

            if (item == null)
                throw new Exception("Item not found");

            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetCart(int userId)
        {
            return await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }
    }
}
