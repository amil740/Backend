using RestaurantApp.BLL.Interfaces;
using RestaurantApp.Core.Models;
using RestaurantApp.Core.Interfaces;

namespace RestaurantApp.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task AddAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Category adi null ve ya bos ola bilmez.", nameof(name));
            }

            var existingCategory = await _categoryRepository.FindAsync(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existingCategory.Any())
            {
                throw new InvalidOperationException($"'{name}' adinda artiq category movcuddur.");
            }

            var newCategory = new Category
            {
                Name = name
            };

            await _categoryRepository.AddAsync(newCategory);
            await _categoryRepository.SaveChangesAsync();
        }

        public Task<Category> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> SearchAsync(string search)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
