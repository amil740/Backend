using System.ComponentModel.DataAnnotations;

namespace Pustok.ViewModels.Category
{
    public class CategoryEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(100)]
        public string? IconClass { get; set; }

        public int? ParentCategoryId { get; set; }
        public bool IsActive { get; set; } = true;
        public int ProductCount { get; set; }
        public int SubCategoryCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
