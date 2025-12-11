namespace Pustok.ViewModels.Product
{
    public class ProductListViewModel
    {
  public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
        public string? Author { get; set; }
        public decimal Price { get; set; }
  public decimal? OldPrice { get; set; }
        public int? DiscountPercentage { get; set; }
        public string MainImagePath { get; set; } = string.Empty;
    public string? HoverImagePath { get; set; }
   public int StockQuantity { get; set; }
        public string? SKU { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
   public bool IsFeatured { get; set; }
    public bool IsNew { get; set; }
public bool IsOnSale { get; set; }
        public int ViewCount { get; set; }
     public int SalesCount { get; set; }
        public decimal Rating { get; set; }
        public int ReviewCount { get; set; }
        public DateTime CreatedDate { get; set; }
}
}
