using System.ComponentModel.DataAnnotations;

namespace FoodDeliverySystem.Models
{
    public class CartItem
    {

        [Key]
        public int Id { get; set; }

        // Foreign Key → Cart
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        // Foreign Key → MenuItem (Product)
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

    }
}
