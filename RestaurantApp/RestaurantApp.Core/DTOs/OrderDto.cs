namespace RestaurantApp.Core.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public int TotalItemCount { get; set; }
    }
}
