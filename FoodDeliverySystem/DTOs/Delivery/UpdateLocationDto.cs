namespace FoodDeliverySystem.DTOs.Delivery
{
    public class UpdateLocationDto
    {
        public int AgentId { get; set; }
        public int OrderId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
