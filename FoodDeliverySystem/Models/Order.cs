using System.ComponentModel.DataAnnotations;

namespace FoodDeliverySystem.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } // Pending, Preparing, Delivered
        public int DeliveryAgentId { get; set; }
    }
}
