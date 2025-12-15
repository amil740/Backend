namespace Pustok.Models
{
    public class Order
    {
   public int Id { get; set; }
     public string OrderNumber { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
  public AppUser User { get; set; } = null!;
public DateTime OrderDate { get; set; } = DateTime.Now;
    public decimal TotalAmount { get; set; }
     public OrderStatus Status { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
   public string ShippingCity { get; set; } = string.Empty;
        public string ShippingZipCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
    }

    public enum OrderStatus
    {
        Pending = 0,
  Processing = 1,
        Shipped = 2,
 Delivered = 3,
  Cancelled = 4
    }
}
