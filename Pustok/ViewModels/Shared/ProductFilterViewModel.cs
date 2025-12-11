namespace Pustok.ViewModels.Shared
{
    public class ProductFilterViewModel
    {
        public string? SearchTerm { get; set; }
        public int? CategoryId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsOnSale { get; set; }
        public bool? InStock { get; set; }
        public string SortBy { get; set; } = "newest";
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 12;
    }
}
