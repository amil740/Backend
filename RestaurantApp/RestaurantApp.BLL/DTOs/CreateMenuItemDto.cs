namespace RestaurantApp.Core.DTOs
{
    public class CreateMenuItemDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}
