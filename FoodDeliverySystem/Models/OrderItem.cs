using System.ComponentModel.DataAnnotations;

namespace FoodDeliverySystem.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key → Order
        public int OrderId { get; set; }
        public Order Order { get; set; }

        // Foreign Key → MenuItem
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
