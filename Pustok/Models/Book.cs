using System.ComponentModel.DataAnnotations;

namespace Pustok.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book title is required")]
        [StringLength(300, MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author is required")]
        [StringLength(200)]
        public string Author { get; set; } = string.Empty;

        [StringLength(3000)]
        public string? Description { get; set; }

        [Required]
        [Range(0.01, 999999.99)]
        public decimal Price { get; set; }

        [Range(0.01, 999999.99)]
        public decimal? OldPrice { get; set; }

        [Range(0, 100)]
        public int? DiscountPercentage { get; set; }

        [Required]
        public string MainImagePath { get; set; } = string.Empty;

        public string? HoverImagePath { get; set; }

        [Required]
        [StringLength(50)]
        public string ISBN { get; set; } = string.Empty;

        [Range(1, 10000)]
        public int PageCount { get; set; }

        [Required]
        [StringLength(200)]
        public string Publisher { get; set; } = string.Empty;

        public DateTime PublishDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Language { get; set; } = "English";

        [StringLength(100)]
        public string? Genre { get; set; }

        [Range(0.01, 1000)]
        public decimal? Weight { get; set; }

        [StringLength(100)]
        public string? Dimensions { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        [StringLength(50)]
        public string? SKU { get; set; }

        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        public bool IsBestSeller { get; set; }
        public bool IsOnSale { get; set; }

        [Range(0, 5)]
        public decimal Rating { get; set; }
        public int ReviewCount { get; set; }
        public int ViewCount { get; set; }
        public int SalesCount { get; set; }

        public DateTime? SaleEndDate { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
