using System.ComponentModel.DataAnnotations;

namespace FoodDeliverySystem.Models
{
    public class Order
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } // Pending, Confirmed, Delivered
        public List<OrderItem> Items { get; set; }
        public int DeliveryAgentId { get; internal set; }
    }
}
