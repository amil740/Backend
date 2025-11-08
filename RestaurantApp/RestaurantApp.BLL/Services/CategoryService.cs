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
            
            if (id <= 0)
            {
                throw new ArgumentException("Category ID musbet eded olmalidir.", nameof(id));
            }
            return _categoryRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Category ID musbet eded olmalidir.", nameof(id));
            }
 
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
 {
       throw new InvalidOperationException($"ID-si {id} olan category tapilmadi.");
            }
         _categoryRepository.Delete(category);
        await _categoryRepository.SaveChangesAsync();
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
