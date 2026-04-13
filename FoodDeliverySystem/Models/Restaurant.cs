using System.ComponentModel.DataAnnotations;

namespace FoodDeliverySystem.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Location { get; set; }

        public string ImageUrl { get; set; }

        public string CuisineType { get; set; } // Indian, Chinese, etc.

        // Navigation Property
        public List<MenuItem> MenuItems { get; set; }
    }
}
