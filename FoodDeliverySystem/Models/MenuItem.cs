using System.ComponentModel.DataAnnotations;

namespace FoodDeliverySystem.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
    }
}
