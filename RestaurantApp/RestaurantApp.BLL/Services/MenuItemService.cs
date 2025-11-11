using RestaurantApp.BLL.Interfaces;
using RestaurantApp.BLL.Mappers;
using RestaurantApp.Core.Models;
using RestaurantApp.Core.DTOs;
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

            var existingItem = await _menuItemRepository.FindAsync(item => item.Name.ToLower() == name.ToLower());
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

        public async Task<IEnumerable<MenuItemDto>> GetAllMenuItemsAsync()
        {
            var menuItems = await _menuItemRepository.GetAllAsync();
            return MenuItemMapper.ToDtoList(menuItems);
        }

        public async Task<List<MenuItemDto>> GetByPriceIntervalAsync(double minPrice, double maxPrice)
        {
            if (minPrice < 0 || maxPrice < 0)
            {
                throw new ArgumentOutOfRangeException("Qiymetler menfi ola bilmez.");
            }

            var items = await _menuItemRepository.GetAllAsync();

            var filteredItems = items
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
              .ToList();

            return MenuItemMapper.ToDtoList(filteredItems);
        }

        public async Task<IEnumerable<MenuItemDto>> GetMenuItemsByCategoryAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new ArgumentException("Bele bir category yoxdur.", nameof(categoryId));
            }

            var menuItems = await _menuItemRepository.FindAsync(item => item.CategoryId == categoryId);
            return MenuItemMapper.ToDtoList(menuItems);
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

        public async Task<List<MenuItemDto>> SearchAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                var allItems = await _menuItemRepository.GetAllAsync();
                return MenuItemMapper.ToDtoList(allItems);
            }

            var items = await _menuItemRepository.FindAsync(item =>
             item.Name.ToLower().Contains(search.ToLower()));

            return MenuItemMapper.ToDtoList(items);
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

            if (menuItem.Name.ToLower() != newName.ToLower())
            {
                var existingItem = await _menuItemRepository.FindAsync(item =>
           item.Name.ToLower() == newName.ToLower());

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
