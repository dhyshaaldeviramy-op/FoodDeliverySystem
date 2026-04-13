using System.ComponentModel.DataAnnotations;

namespace FoodDeliverySystem.Models
{
    public class DeliveryAgent
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsAvailable { get; set; } = true;

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
