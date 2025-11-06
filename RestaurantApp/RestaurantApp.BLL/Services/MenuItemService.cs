using RestaurantApp.BLL.Interfaces;
using RestaurantApp.Core.Models;
using RestaurantApp.Core.Interfaces;

namespace RestaurantApp.BLL.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IGenericRepository<MenuItem> _menuItemRepository;
        private readonly IGenericRepository<Category> _categoryRepository;

        public MenuItemService(IGenericRepository<MenuItem> menuItemRepository, IGenericRepository<Category> categoryRepository)
        {
            _menuItemRepository = menuItemRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task AddAsync(string name, double price, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Menu item adi null ve ya bos ola bilmez.", nameof(name));
            }
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Qiymet 0-dan boyuk olmalidir.");
            }

            var existingItem = await _menuItemRepository.FindAsync(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existingItem.Any())
            {
                throw new InvalidOperationException($"'{name}' adinda artiq menu item movcuddur.");
            }

            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new ArgumentException("Bele bir category yoxdur.", nameof(categoryId));
            }

            var newMenuItem = new MenuItem
            {
                Name = name,
                Price = price,
                CategoryId = categoryId
            };

            await _menuItemRepository.AddAsync(newMenuItem);
            await _menuItemRepository.SaveChangesAsync();
        }

        public Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return _menuItemRepository.GetAllAsync();
        }


        public async Task<List<MenuItem>> GetByPriceIntervalAsync(double minPrice, double maxPrice)
        {
            if (minPrice < 0 || maxPrice < 0)
            {
                throw new ArgumentOutOfRangeException("Qiymetler menfi ola bilmez.");
            }

            var items = await _menuItemRepository.GetAllAsync();

            var filteredItems = items
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .ToList();

            return filteredItems;
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItemsByCategoryAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new ArgumentException("Bele bir category yoxdur.", nameof(categoryId));
            }

            return await _menuItemRepository.FindAsync(item => item.CategoryId == categoryId);
        }

        public async Task RemoveAsync(int id)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id);
            if (menuItem == null)
            {
                throw new ArgumentException("Bele bir menu item yoxdur.", nameof(id));
            }

            _menuItemRepository.Delete(menuItem);
            await _menuItemRepository.SaveChangesAsync();
        }

        public async Task<List<MenuItem>> SearchAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                var allItems = await _menuItemRepository.GetAllAsync();
                return allItems.ToList();
            }

            var items = await _menuItemRepository.FindAsync(item =>
                item.Name.Contains(search, StringComparison.OrdinalIgnoreCase));

            return items.ToList();
        }

        public async Task UpdateAsync(int id, string newName, double newPrice)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Menu item adi null ve ya bos ola bilmez.", nameof(newName));
            }

            if (newPrice < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(newPrice), "Qiymet 0-dan boyuk olmalidir.");
            }

            var menuItem = await _menuItemRepository.GetByIdAsync(id);
            if (menuItem == null)
            {
                throw new ArgumentException("Bele bir menu item yoxdur.", nameof(id));
            }

            if (!menuItem.Name.Equals(newName, StringComparison.OrdinalIgnoreCase))
            {
                var existingItem = await _menuItemRepository.FindAsync(item =>
                    item.Name.Equals(newName, StringComparison.OrdinalIgnoreCase));

                if (existingItem.Any())
                {
                    throw new InvalidOperationException("Bu adda artiq basqa menu item var.");
                }
            }

            menuItem.Name = newName;
            menuItem.Price = newPrice;

            _menuItemRepository.Update(menuItem);
            await _menuItemRepository.SaveChangesAsync();
        }
    }
}
