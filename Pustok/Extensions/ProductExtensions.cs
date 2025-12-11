using Pustok.Models;
using Pustok.ViewModels.Product;

namespace Pustok.Extensions
{
    public static class ProductExtensions
    {
        public static ProductListViewModel ToListViewModel(this Product product)
        {
            return new ProductListViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Author = product.Author,
                Price = product.Price,
                OldPrice = product.OldPrice,
                DiscountPercentage = product.DiscountPercentage,
                MainImagePath = product.MainImagePath,
                HoverImagePath = product.HoverImagePath,
                StockQuantity = product.StockQuantity,
                SKU = product.SKU,
                CategoryName = product.Category?.Name ?? string.Empty,
                IsActive = product.IsActive,
                IsFeatured = product.IsFeatured,
                IsNew = product.IsNew,
                IsOnSale = product.IsOnSale,
                ViewCount = product.ViewCount,
                SalesCount = product.SalesCount,
                Rating = product.Rating,
                ReviewCount = product.ReviewCount,
                CreatedDate = product.CreatedDate
            };
        }

        public static ProductDetailsViewModel ToDetailsViewModel(this Product product)
        {
            return new ProductDetailsViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                OldPrice = product.OldPrice,
                DiscountPercentage = product.DiscountPercentage,
                Author = product.Author,
                StockQuantity = product.StockQuantity,
                SKU = product.SKU,
                ISBN = product.ISBN,
                PageCount = product.PageCount,
                Publisher = product.Publisher,
                PublishDate = product.PublishDate,
                Language = product.Language,
                Weight = product.Weight,
                Dimensions = product.Dimensions,
                MainImagePath = product.MainImagePath,
                HoverImagePath = product.HoverImagePath,
                IsActive = product.IsActive,
                IsFeatured = product.IsFeatured,
                IsNew = product.IsNew,
                IsOnSale = product.IsOnSale,
                SaleEndDate = product.SaleEndDate,
                ViewCount = product.ViewCount,
                SalesCount = product.SalesCount,
                Rating = product.Rating,
                ReviewCount = product.ReviewCount,
                CreatedDate = product.CreatedDate,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name ?? string.Empty,
                ProductImages = product.ProductImages?.Select(pi => pi.ImagePath).ToList() ?? new()
            };
        }

        public static ProductEditViewModel ToEditViewModel(this Product product)
        {
            return new ProductEditViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                OldPrice = product.OldPrice,
                DiscountPercentage = product.DiscountPercentage,
                Author = product.Author,
                StockQuantity = product.StockQuantity,
                SKU = product.SKU,
                ISBN = product.ISBN,
                PageCount = product.PageCount,
                Publisher = product.Publisher,
                PublishDate = product.PublishDate,
                Language = product.Language,
                Weight = product.Weight,
                Dimensions = product.Dimensions,
                MainImagePath = product.MainImagePath,
                HoverImagePath = product.HoverImagePath,
                CategoryId = product.CategoryId,
                IsActive = product.IsActive,
                IsFeatured = product.IsFeatured,
                IsNew = product.IsNew,
                IsOnSale = product.IsOnSale,
                SaleEndDate = product.SaleEndDate,
                ViewCount = product.ViewCount,
                SalesCount = product.SalesCount,
                ReviewCount = product.ReviewCount,
                Rating = product.Rating
            };
        }

        public static void UpdateFromViewModel(this Product product, ProductEditViewModel model)
        {
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.OldPrice = model.OldPrice;
            product.DiscountPercentage = model.DiscountPercentage;
            product.Author = model.Author;
            product.StockQuantity = model.StockQuantity;
            product.SKU = model.SKU;
            product.ISBN = model.ISBN;
            product.PageCount = model.PageCount;
            product.Publisher = model.Publisher;
            product.PublishDate = model.PublishDate;
            product.Language = model.Language;
            product.Weight = model.Weight;
            product.Dimensions = model.Dimensions;
            product.CategoryId = model.CategoryId;
            product.IsActive = model.IsActive;
            product.IsFeatured = model.IsFeatured;
            product.IsNew = model.IsNew;
            product.IsOnSale = model.IsOnSale;
            product.SaleEndDate = model.SaleEndDate;
        }

        public static Product ToEntity(this ProductCreateViewModel model)
        {
            return new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                OldPrice = model.OldPrice,
                DiscountPercentage = model.DiscountPercentage,
                Author = model.Author,
                StockQuantity = model.StockQuantity,
                SKU = model.SKU,
                ISBN = model.ISBN,
                PageCount = model.PageCount,
                Publisher = model.Publisher,
                PublishDate = model.PublishDate,
                Language = model.Language,
                Weight = model.Weight,
                Dimensions = model.Dimensions,
                CategoryId = model.CategoryId,
                IsActive = model.IsActive,
                IsFeatured = model.IsFeatured,
                IsNew = model.IsNew,
                IsOnSale = model.IsOnSale,
                SaleEndDate = model.SaleEndDate,
                CreatedDate = DateTime.Now,
                ViewCount = 0,
                SalesCount = 0,
                ReviewCount = 0,
                Rating = 0,
                MainImagePath = string.Empty
            };
        }
    }
}
