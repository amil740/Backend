namespace Pustok.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public int TotalProducts { get; set; }
        public int TotalCategories { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int LowStockProducts { get; set; }
        public int OutOfStockProducts { get; set; }
        public int ActiveSliders { get; set; }
        public List<Product.ProductListViewModel> RecentProducts { get; set; } = new();
        public List<Product.ProductListViewModel> LowStockItems { get; set; } = new();
        public List<Product.ProductListViewModel> BestSellingProducts { get; set; } = new();
        public Dictionary<string, int> SalesByMonth { get; set; } = new();
        public Dictionary<string, int> ProductsByCategory { get; set; } = new();
    }
}
