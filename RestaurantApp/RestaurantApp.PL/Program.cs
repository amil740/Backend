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

            try
            {
                var context = _serviceProvider.GetRequiredService<RestaurantDbContext>();
                context.Database.Migrate();
                Console.WriteLine("Baza ugurlu baglanidi!");
                Console.WriteLine("Migrasyonlar tatbiq edildi!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Baza baglanmadi: {ex.Message}");
                return;
            }

            _categoryService = _serviceProvider.GetRequiredService<ICategoryService>();
            _menuItemService = _serviceProvider.GetRequiredService<IMenuItemService>();
            _orderService = _serviceProvider.GetRequiredService<IOrderService>();

            await AnaMenusu();
        }

        static async Task AnaMenusu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== RESTORAN SIFARIS SISTEMI ===");
                Console.WriteLine();
                Console.WriteLine("1. Menu islemleri");
                Console.WriteLine("2. Sifaris islemleri");
                Console.WriteLine("0. Cixis");
                Console.Write(Environment.NewLine + "Secim: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        await MenuIslemleri();
                        break;
                    case "2":
                        await SifarisIslemleri();
                        break;
                    case "0":
                        Console.WriteLine(Environment.NewLine + "Hosca qalin!");
                        return;
                    default:
                        Console.WriteLine(Environment.NewLine + "Yanlis secim!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static async Task MenuIslemleri()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MENU ISLEMLERI ===");
                Console.WriteLine();
                Console.WriteLine("1. Yeni elave et");
                Console.WriteLine("2. Duzelt");
                Console.WriteLine("3. Sil");
                Console.WriteLine("4. Hamisini goster");
                Console.WriteLine("5. Kategoriya boyu goster");
                Console.WriteLine("6. Qiymet boyu goster");
                Console.WriteLine("7. Axtar");
                Console.WriteLine("0. Geri");
                Console.Write(Environment.NewLine + "Secim: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        await YeniItemElave();
                        break;
                    case "2":
                        await ItemDuzelt();
                        break;
                    case "3":
                        await ItemSil();
                        break;
                    case "4":
                        await ButunItemleriGoster();
                        break;
                    case "5":
                        await KategoriyaBoyu();
                        break;
                    case "6":
                        await QiymetBoyu();
                        break;
                    case "7":
                        await AxtatItem();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine(Environment.NewLine + "Yanlis secim!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static async Task SifarisIslemleri()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SIFARIS ISLEMLERI ===");
                Console.WriteLine();
                Console.WriteLine("1. Yeni sifaris elave et");
                Console.WriteLine("2. Sifarisisi iptal et");
                Console.WriteLine("3. Tarix araligi boyu goster");
                Console.WriteLine("4. Mueyyen tarixde goster");
                Console.WriteLine("5. Qiymet araligi boyu goster");
                Console.WriteLine("6. Sifaris nomresine gore goster");
                Console.WriteLine("0. Geri");
                Console.Write(Environment.NewLine + "Secim: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        await YeniSifarisElave();
                        break;
                    case "2":
                        await SifarisIptalEt();
                        break;
                    case "3":
                        await TarixAraligindaGoster();
                        break;
                    case "4":
                        await MueyeyenTarixde();
                        break;
                    case "5":
                        await QiymetAraliginda();
                        break;
                    case "6":
                        await SifarisNomresi();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine(Environment.NewLine + "Yanlis secim!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static async Task YeniItemElave()
        {
            Console.Clear();
            Console.WriteLine("=== YENI ITEM ELAVE ET ===");
            Console.WriteLine();

            try
            {
                Console.Write("Item adi: ");
                string ad = Console.ReadLine();

                Console.Write("Qiymet: ");
                if (!double.TryParse(Console.ReadLine(), out double qiymet) || qiymet < 0)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlis qiymet!");
                    Console.ReadKey();
                    return;
                }

                var kategoriyalar = await _categoryService.GetAllCategoriesAsync();
                if (!kategoriyalar.Any())
                {
                    Console.WriteLine(Environment.NewLine + "Heç bir kategoriya yoxdur!");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine(Environment.NewLine + "Kategoriyalar:");
                var katList = kategoriyalar.ToList();
                for (int i = 0; i < katList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {katList[i].Name}");
                }

                Console.Write(Environment.NewLine + "Kategoriya sec: ");
                if (!int.TryParse(Console.ReadLine(), out int katIndex) || katIndex < 1 || katIndex > katList.Count)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlis secim!");
                    Console.ReadKey();
                    return;
                }

                var seciliKat = katList[katIndex - 1];
                await _menuItemService.AddAsync(ad, qiymet, seciliKat.Id);
                Console.WriteLine(Environment.NewLine + "Item elave edildi!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Environment.NewLine}Xeta: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task ItemDuzelt()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM DUZELT ===");
            Console.WriteLine();

            try
            {
                Console.Write("Item nomresi: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine(Environment.NewLine + "Yanlis nomre!");
                    Console.ReadKey();
                    return;
                }

                var bütunItemler = await _menuItemService.GetAllMenuItemsAsync();
                var item = bütunItemler.FirstOrDefault(m => m.Id == id);
                if (item == null)
                {
                    Console.WriteLine(Environment.NewLine + "Item tapilmadi!");
                    Console.ReadKey();
                    return;
                }

                Console.Write($"Yeni ad (hazirki: {item.Name}): ");
                string yeniAd = Console.ReadLine();

                Console.Write($"Yeni qiymet (hazirki: {item.Price}): ");
                if (!double.TryParse(Console.ReadLine(), out double yeniQiymet) || yeniQiymet < 0)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlis fiyat!");
                    Console.ReadKey();
                    return;
                }

                await _menuItemService.UpdateAsync(id, yeniAd, yeniQiymet);
                Console.WriteLine(Environment.NewLine + "Item duzeltildi!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Environment.NewLine}Xeta: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task ItemSil()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM SIL ===");
            Console.WriteLine();

            try
            {
                Console.Write("Item nomresi: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine(Environment.NewLine + "Yanlis nomre!");
                    Console.ReadKey();
                    return;
                }

                await _menuItemService.RemoveAsync(id);
                Console.WriteLine(Environment.NewLine + "Item silindi!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Environment.NewLine}Xeta: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task ButunItemleriGoster()
        {
            Console.Clear();
            Console.WriteLine("=== BUTUN ITEMLER ===");
            Console.WriteLine();

            try
            {
                var itemler = await _menuItemService.GetAllMenuItemsAsync();
                if (!itemler.Any())
                {
                    Console.WriteLine("Heç bir item yoxdur!");
                }
                else
                {
                    ItemleriGoster(itemler);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xeta: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task KategoriyaBoyu()
        {
            Console.Clear();
            Console.WriteLine("=== KATEGORIYA BOYU ===");
            Console.WriteLine();

            try
            {
                var kategoriyalar = await _categoryService.GetAllCategoriesAsync();
                if (!kategoriyalar.Any())
                {
                    Console.WriteLine("Heç bir kategoriya yoxdur!");
                    Console.ReadKey();
                    return;
                }

                var katList = kategoriyalar.ToList();
                Console.WriteLine("Kategoriyalar:");
                for (int i = 0; i < katList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {katList[i].Name}");
                }

                Console.Write(Environment.NewLine + "Kategoriya sec: ");
                if (!int.TryParse(Console.ReadLine(), out int katIndex) || katIndex < 1 || katIndex > katList.Count)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlis secim!");
                    Console.ReadKey();
                    return;
                }

                var seciliKat = katList[katIndex - 1];
                var itemler = await _menuItemService.GetMenuItemsByCategoryAsync(seciliKat.Id);

                Console.WriteLine($"{Environment.NewLine}'{seciliKat.Name}' kategoriyasinda itemler:");
                Console.WriteLine();
                if (!itemler.Any())
                {
                    Console.WriteLine("Heç bir item yoxdur!");
                }
                else
                {
                    ItemleriGoster(itemler);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xeta: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task QiymetBoyu()
        {
            Console.Clear();
            Console.WriteLine("=== QIYMET BOYU ===");
            Console.WriteLine();

            try
            {
                Console.Write("Min qiymet: ");
                if (!double.TryParse(Console.ReadLine(), out double minQiymet) || minQiymet < 0)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlis qiymet!");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Max qiymet: ");
                if (!double.TryParse(Console.ReadLine(), out double maxQiymet) || maxQiymet < minQiymet)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlis qiymet!");
                    Console.ReadKey();
                    return;
                }

                var itemler = await _menuItemService.GetByPriceIntervalAsync(minQiymet, maxQiymet);
                Console.WriteLine($"{Environment.NewLine}{minQiymet} - {maxQiymet} araligi:");
                Console.WriteLine();
                if (!itemler.Any())
                {
                    Console.WriteLine("Heç bir item yoxdur!");
                }
                else
                {
                    ItemleriGoster(itemler);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xeta: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task AxtatItem()
        {
            Console.Clear();
            Console.WriteLine("=== ITEM AXTAR ===");
            Console.WriteLine();

            try
            {
                Console.Write("Axtar: ");
                string axtar = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(axtar))
                {
                    Console.WriteLine(Environment.NewLine + "Bos ola bilmez!");
                    Console.ReadKey();
                    return;
                }

                var itemler = await _menuItemService.SearchAsync(axtar);
                Console.WriteLine($"{Environment.NewLine}'{axtar}' ucun neticeler:");
                Console.WriteLine();
                if (!itemler.Any())
                {
                    Console.WriteLine("Heç bir netice yoxdur!");
                }
                else
                {
                    ItemleriGoster(itemler);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xeta: {ex.Message}");
            }

            Console.ReadKey();
        }

        static void ItemleriGoster(IEnumerable<MenuItem> itemler)
        {
            Console.WriteLine("ID | Ad | Kategoria | Qiymet");
            Console.WriteLine("-------------------------------------------");
            foreach (var item in itemler)
            {
                Console.WriteLine($"{item.Id} | {item.Name} | {item.Category?.Name} | {item.Price:F2}");
            }
        }

        static async Task YeniSifarisElave()
        {
            Console.Clear();
            Console.WriteLine("=== YENI SIFARIS ELAVE ET ===");
            Console.WriteLine();

            try
            {
                var menuItemler = await _menuItemService.GetAllMenuItemsAsync();
                if (!menuItemler.Any())
                {
                    Console.WriteLine("Heç bir item yoxdur!");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Itemler:");
                ItemleriGoster(menuItemler);
                Console.WriteLine();

                var sifarisItemleri = new List<OrderItem>();

                while (true)
                {
                    Console.Write(Environment.NewLine + "Item nomresi (0-cix): ");
                    if (!int.TryParse(Console.ReadLine(), out int itemId) || itemId < 0)
                    {
                        Console.WriteLine("Yanlis nomre!");
                        continue;
                    }

                    if (itemId == 0)
                        break;

                    var seciliItem = menuItemler.FirstOrDefault(m => m.Id == itemId);
                    if (seciliItem == null)
                    {
                        Console.WriteLine("Item tapilmadi!");
                        continue;
                    }

                    Console.Write("Sayi: ");
                    if (!int.TryParse(Console.ReadLine(), out int sayi) || sayi <= 0)
                    {
                        Console.WriteLine("Yanlis sayi!");
                        continue;
                    }

                    sifarisItemleri.Add(new OrderItem
                    {
                        MenuItemId = itemId,
                        Count = sayi
                    });

                    Console.WriteLine("Sifaris-e elave edildi!");
                }

                if (sifarisItemleri.Any())
                {
                    var sifaris = new Order
                    {
                        OrderItems = sifarisItemleri,
                        Date = DateTime.Now
                    };

                    _orderService.AddOrder(sifaris);
                    Console.WriteLine(Environment.NewLine + "Sifaris elave edildi!");
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "Heç bir item secilmedi!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Environment.NewLine}Xeta: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task SifarisIptalEt()
        {
            Console.Clear();
            Console.WriteLine("=== SIFARIS IPTAL ET ===");
            Console.WriteLine();

            try
            {
                Console.Write("Sifaris nomresi: ");
                if (!int.TryParse(Console.ReadLine(), out int sifarisId))
                {
                    Console.WriteLine(Environment.NewLine + "Yanlis nomre!");
                    Console.ReadKey();
                    return;
                }

                _orderService.RemoveOrder(sifarisId);
                Console.WriteLine(Environment.NewLine + "Sifaris iptal edildi!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Environment.NewLine}Xeta: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task TarixAraligindaGoster()
        {
            Console.Clear();
            Console.WriteLine("=== TARIX ARALIGI ===");
            Console.WriteLine();

            try
            {
                Console.Write("Baslangic tarixi (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime baslangic))
                {
                    Console.WriteLine(Environment.NewLine + "Yanlis tarix!");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Son tarixi (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime son) || son < baslangic)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlis tarix!");
                    Console.ReadKey();
                    return;
                }

                var sifarisler = await _orderService.GetOrderByDateIntervalAsync(baslangic, son);
                Console.WriteLine($"{Environment.NewLine}{baslangic:yyyy-MM-dd} - {son:yyyy-MM-dd} araligi:");
                Console.WriteLine();
                if (!sifarisler.Any())
                {
                    Console.WriteLine("Heç bir sifaris yoxdur!");
                }
                else
                {
                    SifarisleriGoster(sifarisler);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xeta: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task MueyeyenTarixde()
        {
            Console.Clear();
            Console.WriteLine("=== MUEYYEN TARIXDE ===");
            Console.WriteLine();

            try
            {
                Console.Write("Tarix (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime tarix))
                {
                    Console.WriteLine(Environment.NewLine + "Yanlis tarix!");
                    Console.ReadKey();
                    return;
                }

                var butunSifarisler = await _orderService.GetAllOrdersAsync();
                var sifarisler = butunSifarisler.Where(o => o.Date.Date == tarix.Date).ToList();

                Console.WriteLine($"{Environment.NewLine}{tarix:yyyy-MM-dd}:");
                Console.WriteLine();
                if (!sifarisler.Any())
                {
                    Console.WriteLine("Heç bir sifaris yoxdur!");
                }
                else
                {
                    SifarisleriGoster(sifarisler);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xeta: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task QiymetAraliginda()
        {
            Console.Clear();
            Console.WriteLine("=== QIYMET ARALIGI ===");
            Console.WriteLine();

            try
            {
                Console.Write("Min: ");
                if (!double.TryParse(Console.ReadLine(), out double min) || min < 0)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlis meblagh!");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Max: ");
                if (!double.TryParse(Console.ReadLine(), out double max) || max < min)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlis meblagh!");
                    Console.ReadKey();
                    return;
                }

                var sifarisler = await _orderService.GetOrdersByPriceIntervalAsync(min, max);
                Console.WriteLine($"{Environment.NewLine}{min:F2} - {max:F2} araligi:");
                Console.WriteLine();
                if (!sifarisler.Any())
                {
                    Console.WriteLine("Heç bir sifaris yoxdur!");
                }
                else
                {
                    SifarisleriGoster(sifarisler);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xeta: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task SifarisNomresi()
        {
            Console.Clear();
            Console.WriteLine("=== SIFARIS GOSTER ===");
            Console.WriteLine();

            try
            {
                Console.Write("Sifaris nomresi: ");
                if (!int.TryParse(Console.ReadLine(), out int sifarisId))
                {
                    Console.WriteLine(Environment.NewLine + "Yanlis nomre!");
                    Console.ReadKey();
                    return;
                }

                var sifaris = await _orderService.GetOrderByIdAsync(sifarisId);
                if (sifaris == null)
                {
                    Console.WriteLine(Environment.NewLine + "Sifaris tapilmadi!");
                }
                else
                {
                    Console.WriteLine($"{Environment.NewLine}Sifaris: {sifaris.Id}");
                    Console.WriteLine($"Tarix: {sifaris.Date:yyyy-MM-dd HH:mm:ss}");
                    Console.WriteLine($"Cemi: {sifaris.TotalPrice:F2}");
                    Console.WriteLine(Environment.NewLine + "Itemler:");
                    Console.WriteLine("Item | Sayi | Qiymet");
                    Console.WriteLine("----------------------------");
                    if (sifaris.OrderItems != null)
                    {
                        foreach (var item in sifaris.OrderItems)
                        {
                            Console.WriteLine($"{item.MenuItem.Name} | {item.Count} | {item.MenuItem.Price:F2}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xeta: {ex.Message}");
            }

            Console.ReadKey();
        }

        static void SifarisleriGoster(IEnumerable<Order> sifarisler)
        {
            Console.WriteLine("Sifaris | Tarix | Cemi");
            Console.WriteLine("----------------------------");
            foreach (var sifaris in sifarisler)
            {
                Console.WriteLine($"{sifaris.Id} | {sifaris.Date:yyyy-MM-dd HH:mm} | {sifaris.TotalPrice:F2}");
            }
        }
    }
}
