using RestaurantApp.Core.Models;

namespace RestaurantApp.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task AddAsync(string name);
        Task RemoveAsync(int id);
        Task UpdateAsync(int id, string newName);
        Task<List<Category>> SearchAsync(string search);
    }
}
