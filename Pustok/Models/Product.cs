using System.ComponentModel.DataAnnotations;

namespace Pustok.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Product name must be between 2 and 200 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 999999.99, ErrorMessage = "Price must be between 0.01 and 999,999.99")]
        public decimal Price { get; set; }

        [Range(0.01, 999999.99, ErrorMessage = "Old price must be between 0.01 and 999,999.99")]
        public decimal? OldPrice { get; set; }

        [Range(0, 100, ErrorMessage = "Discount percentage must be between 0 and 100")]
        public int? DiscountPercentage { get; set; }

        [StringLength(200, ErrorMessage = "Author name cannot exceed 200 characters")]
        public string? Author { get; set; }

        [Required(ErrorMessage = "Main image is required")]
        public string MainImagePath { get; set; } = string.Empty;

        public string? HoverImagePath { get; set; }

        [Required(ErrorMessage = "Stock quantity is required")]
        [Range(0, 999999, ErrorMessage = "Stock quantity must be between 0 and 999,999")]
        public int StockQuantity { get; set; }

        [StringLength(50, ErrorMessage = "SKU cannot exceed 50 characters")]
        public string? SKU { get; set; }

        [StringLength(20, ErrorMessage = "ISBN cannot exceed 20 characters")]
        public string? ISBN { get; set; }

        [Range(1, 10000, ErrorMessage = "Page count must be between 1 and 10,000")]
        public int? PageCount { get; set; }

        [StringLength(200, ErrorMessage = "Publisher name cannot exceed 200 characters")]
        public string? Publisher { get; set; }

        public DateTime? PublishDate { get; set; }

        [StringLength(50, ErrorMessage = "Language cannot exceed 50 characters")]
        public string? Language { get; set; }

        [Range(0.01, 1000, ErrorMessage = "Weight must be between 0.01 and 1000")]
        public decimal? Weight { get; set; }

        [StringLength(100, ErrorMessage = "Dimensions cannot exceed 100 characters")]
        public string? Dimensions { get; set; }

        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        public bool IsOnSale { get; set; }
        public int ViewCount { get; set; }
        public int SalesCount { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public decimal Rating { get; set; }

        public int ReviewCount { get; set; }
        public DateTime? SaleEndDate { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }

    public class ProductImage
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public bool IsPrimary { get; set; }
        public int Order { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Category name must be between 2 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [StringLength(50, ErrorMessage = "Icon class cannot exceed 50 characters")]
        public string? IconClass { get; set; }

        public int? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
