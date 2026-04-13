namespace FoodDeliverySystem.DTOs.Cart
{
    public class CartResponseDto
    {
        public List<CartItemDto> Items { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
