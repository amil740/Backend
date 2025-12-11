using System.ComponentModel.DataAnnotations;

namespace Pustok.ViewModels.Product
{
    public class ProductEditViewModel
    {
   public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Description { get; set; }

     [Required]
        [Range(0.01, 999999.99)]
        public decimal Price { get; set; }

        [Range(0.01, 999999.99)]
        public decimal? OldPrice { get; set; }

        [Range(0, 100)]
        public int? DiscountPercentage { get; set; }

        [StringLength(200)]
   public string? Author { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        [StringLength(50)]
        public string? SKU { get; set; }

    [StringLength(50)]
     public string? ISBN { get; set; }

        [Range(1, int.MaxValue)]
    public int? PageCount { get; set; }

        [StringLength(200)]
        public string? Publisher { get; set; }

        public DateTime? PublishDate { get; set; }

        [StringLength(100)]
    public string? Language { get; set; }

        [Range(0, 999.99)]
    public decimal? Weight { get; set; }

      [StringLength(100)]
        public string? Dimensions { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        public bool IsOnSale { get; set; }
        public DateTime? SaleEndDate { get; set; }

        public string? MainImagePath { get; set; }
        public string? HoverImagePath { get; set; }

        public IFormFile? MainImageFile { get; set; }
        public IFormFile? HoverImageFile { get; set; }
        public List<IFormFile>? AdditionalImages { get; set; }

        public int ViewCount { get; set; }
      public int SalesCount { get; set; }
        public int ReviewCount { get; set; }
        public decimal Rating { get; set; }
    }
}
