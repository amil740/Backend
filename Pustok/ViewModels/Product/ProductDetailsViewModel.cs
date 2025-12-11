namespace Pustok.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
  public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
 public decimal? OldPrice { get; set; }
        public int? DiscountPercentage { get; set; }
        public string? Author { get; set; }
        public int StockQuantity { get; set; }
      public string? SKU { get; set; }
        public string? ISBN { get; set; }
    public int? PageCount { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishDate { get; set; }
        public string? Language { get; set; }
        public decimal? Weight { get; set; }
      public string? Dimensions { get; set; }
        public string MainImagePath { get; set; } = string.Empty;
        public string? HoverImagePath { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
public bool IsOnSale { get; set; }
        public DateTime? SaleEndDate { get; set; }
        public int ViewCount { get; set; }
        public int SalesCount { get; set; }
        public decimal Rating { get; set; }
        public int ReviewCount { get; set; }
        public DateTime CreatedDate { get; set; }
      public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<ProductListViewModel> RelatedProducts { get; set; } = new();
        public List<string> ProductImages { get; set; } = new();
    }
}
