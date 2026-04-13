
using FoodDeliverySystem.Data;
using FoodDeliverySystem.Models;
using FoodDeliverySystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliverySystem.Services.Implementations
{
    using FoodDeliverySystem.DTOs.Cart;
    using Microsoft.EntityFrameworkCore;

    public class CartService : ICartService
    {
        private readonly AppDbContext _context;

        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddToCart(int userId, AddToCartDto dto)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId, Items = new List<CartItem>() };
                _context.Carts.Add(cart);
            }

            var menuItem = await _context.MenuItems.FindAsync(dto.MenuItemId);

            cart.Items.Add(new CartItem
            {
                MenuItemId = dto.MenuItemId,
                Quantity = dto.Quantity,
                Price = menuItem.Price
            });

            await _context.SaveChangesAsync();
        }

        public async Task<CartResponseDto> GetCart(int userId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.MenuItem)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            var items = cart.Items.Select(i => new CartItemDto
            {
                MenuItemId = i.MenuItemId,
                MenuItemName = i.MenuItem.Name,
                Quantity = i.Quantity,
                Price = i.Price
            }).ToList();

            return new CartResponseDto
            {
                Items = items,
                TotalAmount = items.Sum(i => i.Price * i.Quantity)
            };
        }

        public async Task RemoveItem(int itemId)
        {
            var item = await _context.CartItems.FindAsync(itemId);
            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
