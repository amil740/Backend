using Pustok.Models;
using Pustok.ViewModels.Category;

namespace Pustok.Extensions
{
    public static class CategoryExtensions
    {
        public static CategoryViewModel ToViewModel(this Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                IconClass = category.IconClass,
                ParentCategoryId = category.ParentCategoryId,
                IsActive = category.IsActive,
                ParentCategoryName = category.ParentCategory?.Name,
                ProductCount = category.Products?.Count ?? 0,
                SubCategoryCount = category.SubCategories?.Count ?? 0,
                CreatedDate = category.CreatedDate
            };
        }

        public static CategoryEditViewModel ToEditViewModel(this Category category)
        {
            return new CategoryEditViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                IconClass = category.IconClass,
                ParentCategoryId = category.ParentCategoryId,
                IsActive = category.IsActive,
                ProductCount = category.Products?.Count ?? 0,
                SubCategoryCount = category.SubCategories?.Count ?? 0,
                CreatedDate = category.CreatedDate
            };
        }

        public static Category ToEntity(this CategoryCreateViewModel model)
        {
            return new Category
            {
                Name = model.Name,
                Description = model.Description,
                IconClass = model.IconClass,
                ParentCategoryId = model.ParentCategoryId,
                IsActive = model.IsActive,
                CreatedDate = DateTime.Now
            };
        }

        public static void UpdateFromViewModel(this Category category, CategoryEditViewModel model)
        {
            category.Name = model.Name;
            category.Description = model.Description;
            category.IconClass = model.IconClass;
            category.ParentCategoryId = model.ParentCategoryId;
            category.IsActive = model.IsActive;
        }
    }
}
