using RestaurantApp.Core.Models;
using RestaurantApp.Core.DTOs;

namespace RestaurantApp.BLL.Interfaces
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItemDto>> GetAllMenuItemsAsync();
        Task<IEnumerable<MenuItemDto>> GetMenuItemsByCategoryAsync(int categoryId);
        Task AddAsync(string name, double price, int categoryId);
        Task RemoveAsync(int id);
        Task UpdateAsync(int id, string newName, double newPrice);
        Task<List<MenuItemDto>> SearchAsync(string search);
        Task<List<MenuItemDto>> GetByPriceIntervalAsync(double minPrice, double maxPrice);
    }
}
