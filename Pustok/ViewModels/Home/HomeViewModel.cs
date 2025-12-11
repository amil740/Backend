namespace Pustok.ViewModels.Home
{
    public class HomeViewModel
    {
        public List<Models.Slider> Sliders { get; set; } = new();
        public List<Product.ProductListViewModel> FeaturedProducts { get; set; } = new();
        public List<Product.ProductListViewModel> NewProducts { get; set; } = new();
        public List<Product.ProductListViewModel> BestSellers { get; set; } = new();
        public List<Product.ProductListViewModel> OnSaleProducts { get; set; } = new();
        public List<Category.CategoryViewModel> PopularCategories { get; set; } = new();
    }
}
