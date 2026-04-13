namespace FoodDeliverySystem.DTOs.Order
{
    public class OrderResponseDto
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public List<OrderItemDetailsDto> Items { get; set; }
    }
}
