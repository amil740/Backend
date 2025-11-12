namespace RestaurantApp.Core.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public double MenuItemPrice { get; set; }
        public int Count { get; set; }
    }
}
