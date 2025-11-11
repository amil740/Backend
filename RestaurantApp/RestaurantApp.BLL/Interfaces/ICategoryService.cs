using RestaurantApp.Core.Models;
using RestaurantApp.Core.DTOs;

namespace RestaurantApp.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task AddAsync(string name);
        Task RemoveAsync(int id);
        Task UpdateAsync(int id, string newName);
        Task<List<CategoryDto>> SearchAsync(string search);
    }
}
