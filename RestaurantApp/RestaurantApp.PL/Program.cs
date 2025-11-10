using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.BLL.Extensions;
using RestaurantApp.BLL.Interfaces;
using RestaurantApp.Core.Models;
using RestaurantApp.DLL.Data;
using RestaurantApp.DLL.Extensions;

namespace RestaurantApp.PL
{
    internal class Program
    {
        private static IServiceProvider _serviceProvider;
        private static ICategoryService _categoryService;
        private static IMenuItemService _menuItemService;
        private static IOrderService _orderService;

        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            string connectionString = "Server=Amil;Database=RestaurantApp;Trusted_Connection=true;Encrypt=false;TrustServerCertificate=true;";

            services.AddDataLayerServices(connectionString);
            services.AddBusinessLogicServices();

            _serviceProvider = services.BuildServiceProvider();

            using (var context = _serviceProvider.GetRequiredService<RestaurantDbContext>())
            {
                try
                {
                    context.Database.Migrate();
                    Console.WriteLine("Database connection successful!");
                    Console.WriteLine("Migrations applied successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Database connection failed: {ex.Message}");
                    return;
                }
            }

            _categoryService = _serviceProvider.GetRequiredService<ICategoryService>();
            _menuItemService = _serviceProvider.GetRequiredService<IMenuItemService>();
            _orderService = _serviceProvider.GetRequiredService<IOrderService>();

            await MainMenu();
        }

        static async Task MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== RESTAURANT ORDER SYSTEM ===\n");
                Console.WriteLine("1. Menu operations");
                Console.WriteLine("2. Order operations");
                Console.WriteLine("0. Exit");
                Console.Write("\nSelect: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await MenuOperations();
                        break;
                    case "2":
                        await OrderOperations();
                        break;
                    case "0":
                        Console.WriteLine("\nGoodbye!");
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static async Task MenuOperations()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MENU OPERATIONS ===\n");
                Console.WriteLine("1. Add new item");
                Console.WriteLine("2. Edit item");
                Console.WriteLine("3. Delete item");
                Console.WriteLine("4. Show all items");
                Console.WriteLine("5. Show items by category");
                Console.WriteLine("6. Show items by price range");
                Console.WriteLine("7. Search items");
                Console.WriteLine("0. Back");
                Console.Write("\nSelect: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await AddMenuItem();
                        break;
                    case "2":
                        await EditMenuItem();
                        break;
                    case "3":
                        await RemoveMenuItem();
                        break;
                    case "4":
                        await DisplayAllMenuItems();
                        break;
                    case "5":
                        await DisplayMenuItemsByCategory();
                        break;
                    case "6":
                        await DisplayMenuItemsByPriceRange();
                        break;
                    case "7":
                        await SearchMenuItems();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static async Task OrderOperations()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ORDER OPERATIONS ===\n");
                Console.WriteLine("1. Add new order");
                Console.WriteLine("2. Cancel order");
                Console.WriteLine("3. Show orders by date range");
                Console.WriteLine("4. Show orders by specific date");
                Console.WriteLine("5. Show orders by price range");
                Console.WriteLine("6. Show order by number");
                Console.WriteLine("0. Back");
                Console.Write("\nSelect: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await AddOrder();
                        break;
                    case "2":
                        await RemoveOrder();
                        break;
                    case "3":
                        await GetOrdersByDateInterval();
                        break;
                    case "4":
                        await GetOrdersByDate();
                        break;
                    case "5":
                        await GetOrdersByPriceInterval();
                        break;
                    case "6":
                        await GetOrderByNo();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static async Task AddMenuItem()
        {
            Console.Clear();
            Console.WriteLine("=== ADD NEW MENU ITEM ===\n");

            try
            {
                Console.Write("Enter item name: ");
                string name = Console.ReadLine();

                Console.Write("Enter price: ");
                if (!double.TryParse(Console.ReadLine(), out double price) || price < 0)
                {
                    Console.WriteLine("\nInvalid price format.");
                    Console.ReadKey();
                    return;
                }

                var categories = await _categoryService.GetAllCategoriesAsync();
                if (!categories.Any())
                {
                    Console.WriteLine("\nNo categories exist. Please add a category first.");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("\nAvailable categories:");
                var categoryList = categories.ToList();
                for (int i = 0; i < categoryList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {categoryList[i].Name}");
                }

                Console.Write("\nSelect category (number): ");
                if (!int.TryParse(Console.ReadLine(), out int catIndex) || catIndex < 1 || catIndex > categoryList.Count)
                {
                    Console.WriteLine("\nInvalid selection.");
                    Console.ReadKey();
                    return;
                }

                var selectedCategory = categoryList[catIndex - 1];
                await _menuItemService.AddAsync(name, price, selectedCategory.Id);
                Console.WriteLine("\nItem added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task EditMenuItem()
        {
            Console.Clear();
            Console.WriteLine("=== EDIT MENU ITEM ===\n");

            try
            {
                Console.Write("Enter item number to edit: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("\nInvalid number format.");
                    Console.ReadKey();
                    return;
                }

                var allItems = await _menuItemService.GetAllMenuItemsAsync();
                var menuItem = allItems.FirstOrDefault(m => m.Id == id);
                if (menuItem == null)
                {
                    Console.WriteLine("\nItem not found.");
                    Console.ReadKey();
                    return;
                }

                Console.Write($"Enter new name (current: {menuItem.Name}): ");
                string newName = Console.ReadLine();

                Console.Write($"Enter new price (current: {menuItem.Price}): ");
                if (!double.TryParse(Console.ReadLine(), out double newPrice) || newPrice < 0)
                {
                    Console.WriteLine("\nInvalid price format.");
                    Console.ReadKey();
                    return;
                }

                await _menuItemService.UpdateAsync(id, newName, newPrice);
                Console.WriteLine("\nItem updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task RemoveMenuItem()
        {
            Console.Clear();
            Console.WriteLine("=== DELETE MENU ITEM ===\n");

            try
            {
                Console.Write("Enter item number to delete: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("\nInvalid number format.");
                    Console.ReadKey();
                    return;
                }

                await _menuItemService.RemoveAsync(id);
                Console.WriteLine("\nItem deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task DisplayAllMenuItems()
        {
            Console.Clear();
            Console.WriteLine("=== ALL MENU ITEMS ===\n");

            try
            {
                var items = await _menuItemService.GetAllMenuItemsAsync();
                if (!items.Any())
                {
                    Console.WriteLine("No items found.");
                }
                else
                {
                    ShowMenuItemsTable(items);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task DisplayMenuItemsByCategory()
        {
            Console.Clear();
            Console.WriteLine("=== ITEMS BY CATEGORY ===\n");

            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                if (!categories.Any())
                {
                    Console.WriteLine("No categories found.");
                    Console.ReadKey();
                    return;
                }

                var categoryList = categories.ToList();
                Console.WriteLine("Available categories:");
                for (int i = 0; i < categoryList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {categoryList[i].Name}");
                }

                Console.Write("\nSelect category (number): ");
                if (!int.TryParse(Console.ReadLine(), out int catIndex) || catIndex < 1 || catIndex > categoryList.Count)
                {
                    Console.WriteLine("\nInvalid selection.");
                    Console.ReadKey();
                    return;
                }

                var selectedCategory = categoryList[catIndex - 1];
                var items = await _menuItemService.GetMenuItemsByCategoryAsync(selectedCategory.Id);

                Console.WriteLine($"\nItems in '{selectedCategory.Name}' category:\n");
                if (!items.Any())
                {
                    Console.WriteLine("No items in this category.");
                }
                else
                {
                    ShowMenuItemsTable(items);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task DisplayMenuItemsByPriceRange()
        {
            Console.Clear();
            Console.WriteLine("=== ITEMS BY PRICE RANGE ===\n");

            try
            {
                Console.Write("Enter minimum price: ");
                if (!double.TryParse(Console.ReadLine(), out double minPrice) || minPrice < 0)
                {
                    Console.WriteLine("\nInvalid price format.");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Enter maximum price: ");
                if (!double.TryParse(Console.ReadLine(), out double maxPrice) || maxPrice < minPrice)
                {
                    Console.WriteLine("\nInvalid price format.");
                    Console.ReadKey();
                    return;
                }

                var items = await _menuItemService.GetByPriceIntervalAsync(minPrice, maxPrice);
                Console.WriteLine($"\nItems in price range {minPrice} - {maxPrice}:\n");
                if (!items.Any())
                {
                    Console.WriteLine("No items in this price range.");
                }
                else
                {
                    ShowMenuItemsTable(items);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task SearchMenuItems()
        {
            Console.Clear();
            Console.WriteLine("=== SEARCH MENU ITEMS ===\n");

            try
            {
                Console.Write("Enter search term: ");
                string searchTerm = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    Console.WriteLine("\nSearch term cannot be empty.");
                    Console.ReadKey();
                    return;
                }

                var items = await _menuItemService.SearchAsync(searchTerm);
                Console.WriteLine($"\nSearch results for '{searchTerm}':\n");
                if (!items.Any())
                {
                    Console.WriteLine("No results found.");
                }
                else
                {
                    ShowMenuItemsTable(items);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }

        static void ShowMenuItemsTable(IEnumerable<MenuItem> items)
        {
            Console.WriteLine("ID | Name | Category | Price");
            Console.WriteLine("-------------------------------------------");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id} | {item.Name} | {item.Category?.Name} | {item.Price:F2}");
            }
        }

        static async Task AddOrder()
        {
            Console.Clear();
            Console.WriteLine("=== ADD NEW ORDER ===\n");

            try
            {
                var menuItems = await _menuItemService.GetAllMenuItemsAsync();
                if (!menuItems.Any())
                {
                    Console.WriteLine("No menu items available.");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Available items:");
                ShowMenuItemsTable(menuItems);

                var orderItems = new List<OrderItem>();

                while (true)
                {
                    Console.Write("\nEnter item number (0 to finish): ");
                    if (!int.TryParse(Console.ReadLine(), out int itemId) || itemId < 0)
                    {
                        Console.WriteLine("Invalid number format.");
                        continue;
                    }

                    if (itemId == 0)
                        break;

                    var selectedItem = menuItems.FirstOrDefault(m => m.Id == itemId);
                    if (selectedItem == null)
                    {
                        Console.WriteLine("Item not found.");
                        continue;
                    }

                    Console.Write("Enter quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
                    {
                        Console.WriteLine("Invalid quantity.");
                        continue;
                    }

                    orderItems.Add(new OrderItem
                    {
                        MenuItemId = itemId,
                        Count = count
                    });

                    Console.WriteLine("Item added to order.");
                }

                if (orderItems.Any())
                {
                    var order = new Order
                    {
                        OrderItems = orderItems,
                        Date = DateTime.Now
                    };

                    _orderService.AddOrder(order);
                    Console.WriteLine("\nOrder added successfully!");
                }
                else
                {
                    Console.WriteLine("\nNo items selected.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task RemoveOrder()
        {
            Console.Clear();
            Console.WriteLine("=== CANCEL ORDER ===\n");

            try
            {
                Console.Write("Enter order number to cancel: ");
                if (!int.TryParse(Console.ReadLine(), out int orderId))
                {
                    Console.WriteLine("\nInvalid number format.");
                    Console.ReadKey();
                    return;
                }

                _orderService.RemoveOrder(orderId);
                Console.WriteLine("\nOrder cancelled successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task GetOrdersByDateInterval()
        {
            Console.Clear();
            Console.WriteLine("=== ORDERS BY DATE RANGE ===\n");

            try
            {
                Console.Write("Enter start date (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
                {
                    Console.WriteLine("\nInvalid date format.");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Enter end date (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate) || endDate < startDate)
                {
                    Console.WriteLine("\nInvalid date format.");
                    Console.ReadKey();
                    return;
                }

                var orders = await _orderService.GetOrderByDateIntervalAsync(startDate, endDate);
                Console.WriteLine($"\nOrders from {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}:\n");
                if (!orders.Any())
                {
                    Console.WriteLine("No orders found in this date range.");
                }
                else
                {
                    ShowOrdersTable(orders);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task GetOrdersByDate()
        {
            Console.Clear();
            Console.WriteLine("=== ORDERS BY SPECIFIC DATE ===\n");

            try
            {
                Console.Write("Enter date (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    Console.WriteLine("\nInvalid date format.");
                    Console.ReadKey();
                    return;
                }

                var allOrders = await _orderService.GetAllOrdersAsync();
                var orders = allOrders.Where(o => o.Date.Date == date.Date).ToList();

                Console.WriteLine($"\nOrders on {date:yyyy-MM-dd}:\n");
                if (!orders.Any())
                {
                    Console.WriteLine("No orders found on this date.");
                }
                else
                {
                    ShowOrdersTable(orders);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task GetOrdersByPriceInterval()
        {
            Console.Clear();
            Console.WriteLine("=== ORDERS BY PRICE RANGE ===\n");

            try
            {
                Console.Write("Enter minimum amount: ");
                if (!double.TryParse(Console.ReadLine(), out double minAmount) || minAmount < 0)
                {
                    Console.WriteLine("\nInvalid amount format.");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Enter maximum amount: ");
                if (!double.TryParse(Console.ReadLine(), out double maxAmount) || maxAmount < minAmount)
                {
                    Console.WriteLine("\nInvalid amount format.");
                    Console.ReadKey();
                    return;
                }

                var orders = await _orderService.GetOrdersByPriceIntervalAsync(minAmount, maxAmount);
                Console.WriteLine($"\nOrders in price range {minAmount:F2} - {maxAmount:F2}:\n");
                if (!orders.Any())
                {
                    Console.WriteLine("No orders found in this price range.");
                }
                else
                {
                    ShowOrdersTable(orders);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task GetOrderByNo()
        {
            Console.Clear();
            Console.WriteLine("=== SHOW ORDER ===\n");

            try
            {
                Console.Write("Enter order number: ");
                if (!int.TryParse(Console.ReadLine(), out int orderId))
                {
                    Console.WriteLine("\nInvalid number format.");
                    Console.ReadKey();
                    return;
                }

                var order = await _orderService.GetOrderByIdAsync(orderId);
                if (order == null)
                {
                    Console.WriteLine("\nOrder not found.");
                }
                else
                {
                    Console.WriteLine($"\nOrder Number: {order.Id}");
                    Console.WriteLine($"Date: {order.Date:yyyy-MM-dd HH:mm:ss}");
                    Console.WriteLine($"Total: {order.TotalPrice:F2}");
                    Console.WriteLine("\nOrder Items:");
                    Console.WriteLine("Item | Quantity | Price");
                    Console.WriteLine("----------------------------");
                    if (order.OrderItems != null)
                    {
                        foreach (var item in order.OrderItems)
                        {
                            Console.WriteLine($"{item.MenuItem.Name} | {item.Count} | {item.MenuItem.Price:F2}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }

        static void ShowOrdersTable(IEnumerable<Order> orders)
        {
            Console.WriteLine("Order | Date | Total");
            Console.WriteLine("----------------------------");
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.Id} | {order.Date:yyyy-MM-dd HH:mm} | {order.TotalPrice:F2}");
            }
        }
    }
}
