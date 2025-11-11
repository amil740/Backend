using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.BLL.Extensions;
using RestaurantApp.BLL.Interfaces;
using RestaurantApp.Core.Models;
using RestaurantApp.Core.DTOs;
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
                Console.WriteLine("Baza ugurla baglandi!");
                Console.WriteLine("Migrasyonlar tetbiq edildi!");
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
                Console.WriteLine("1. Menu uzerinde emeliyyat aparmaq");
                Console.WriteLine("2. Sifarisler uzerinde emeliyyat aparmaq");
                Console.WriteLine("0. Sistemden cixmaq");
                Console.Write(Environment.NewLine + "Seciminiz: ");

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
                        Console.WriteLine(Environment.NewLine + "Sagolun!");
                        return;
                    default:
                        Console.WriteLine(Environment.NewLine + "Yanlish secim!");
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
                Console.WriteLine("=== MENU UZERINDE EMELIYYATLAR ===");
                Console.WriteLine();
                Console.WriteLine("1. Yeni item elave et");
                Console.WriteLine("2. Item uzerinde duzelis et");
                Console.WriteLine("3. Item sil");
                Console.WriteLine("4. Butun itemlari goster");
                Console.WriteLine("5. Kateqoriyasina gore menu itemlari goster");
                Console.WriteLine("6. Qiymet araligina gore menu itemlar goster");
                Console.WriteLine("7. Menu itemlar arasinda ada gore axtar");
                Console.WriteLine("0. Evvelki menuya qayit");
                Console.Write(Environment.NewLine + "Secininiz: ");

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
                        Console.WriteLine(Environment.NewLine + "Yanlish secim!");
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
                Console.WriteLine("=== SIFARISLER UZERINDE EMELIYYATLAR ===");
                Console.WriteLine();
                Console.WriteLine("1. Yeni sifaris elave et");
                Console.WriteLine("2. Sifarishin legvi");
                Console.WriteLine("3. Butun sifarishleri goster");
                Console.WriteLine("4. Tarix araligina gore sifarishleri goster");
                Console.WriteLine("5. Mebleg araligina gore sifarishleri goster");
                Console.WriteLine("6. Verilmish tarixde olan sifarishleri goster");
                Console.WriteLine("7. Sifaris nomresine gore goster");
                Console.WriteLine("0. Evvelki menuya qayit");
                Console.Write(Environment.NewLine + "Secininiz: ");

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
                        await ButunSifarisleriGoster();
                        break;
                    case "4":
                        await TarixAraligindaGoster();
                        break;
                    case "5":
                        await QiymetAraliginda();
                        break;
                    case "6":
                        await MueyeyenTarixde();
                        break;
                    case "7":
                        await SifarisNomresi();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine(Environment.NewLine + "Yanlish secim!");
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

                if (string.IsNullOrWhiteSpace(ad))
                {
                    Console.WriteLine(Environment.NewLine + "Item adi bosh ola bilmez!");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Qiymet: ");
                if (!double.TryParse(Console.ReadLine(), out double qiymet) || qiymet < 0)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlish qiymet!");
                    Console.ReadKey();
                    return;
                }

                var kategoriyalar = await _categoryService.GetAllCategoriesAsync();
                if (!kategoriyalar.Any())
                {
                    Console.WriteLine(Environment.NewLine + "Hec bir kateqoriya yoxdur!");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine(Environment.NewLine + "Kateqoriyalar:");
                var katList = kategoriyalar.ToList();
                for (int i = 0; i < katList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {katList[i].Name}");
                }

                Console.Write(Environment.NewLine + "Kateqoriya sec: ");
                if (!int.TryParse(Console.ReadLine(), out int katIndex) || katIndex < 1 || katIndex > katList.Count)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlish secim!");
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
            Console.WriteLine("=== ITEM UZERINDE DUZELIS ET ===");
            Console.WriteLine();

            try
            {
                Console.Write("Duzelis edilecek item nomresi: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine(Environment.NewLine + "Yanlish nomre!");
                    Console.ReadKey();
                    return;
                }

                var butunItemler = await _menuItemService.GetAllMenuItemsAsync();
                var item = butunItemler.FirstOrDefault(m => m.Id == id);
                if (item == null)
                {
                    Console.WriteLine(Environment.NewLine + "Item tapilmadi!");
                    Console.ReadKey();
                    return;
                }

                Console.Write($"Yeni ad (hazirki: {item.Name}): ");
                string yeniAd = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(yeniAd))
                {
                    Console.WriteLine(Environment.NewLine + "Yeni ad bosh ola bilmez!");
                    Console.ReadKey();
                    return;
                }

                Console.Write($"Yeni qiymet (hazirki: {item.Price}): ");
                if (!double.TryParse(Console.ReadLine(), out double yeniQiymet) || yeniQiymet < 0)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlish qiymet!");
                    Console.ReadKey();
                    return;
                }

                await _menuItemService.UpdateAsync(id, yeniAd, yeniQiymet);
                Console.WriteLine(Environment.NewLine + "Item duzeldildi!");
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
                Console.Write("Silinecek item nomresi: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine(Environment.NewLine + "Yanlish nomre!");
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
            Console.WriteLine("=== BUTUN ITEMLAR ===");
            Console.WriteLine();

            try
            {
                var itemler = await _menuItemService.GetAllMenuItemsAsync();
                if (!itemler.Any())
                {
                    Console.WriteLine("Hec bir item yoxdur!");
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
            Console.WriteLine("=== KATEQORIYASINA GORE MENU ITEMLARI ===");
            Console.WriteLine();

            try
            {
                var kategoriyalar = await _categoryService.GetAllCategoriesAsync();
                if (!kategoriyalar.Any())
                {
                    Console.WriteLine("Hec bir kateqoriya yoxdur!");
                    Console.ReadKey();
                    return;
                }

                var katList = kategoriyalar.ToList();
                Console.WriteLine("Kateqoriyalar:");
                for (int i = 0; i < katList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {katList[i].Name}");
                }

                Console.Write(Environment.NewLine + "Kateqoriya sec: ");
                if (!int.TryParse(Console.ReadLine(), out int katIndex) || katIndex < 1 || katIndex > katList.Count)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlish secim!");
                    Console.ReadKey();
                    return;
                }

                var seciliKat = katList[katIndex - 1];
                var itemler = await _menuItemService.GetMenuItemsByCategoryAsync(seciliKat.Id);

                Console.WriteLine($"{Environment.NewLine}'{seciliKat.Name}' kateqoriyasinda itemler:");
                Console.WriteLine();
                if (!itemler.Any())
                {
                    Console.WriteLine("Hec bir item yoxdur!");
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
            Console.WriteLine("=== QIYMET ARALIGINA GORE MENU ITEMLAR ===");
            Console.WriteLine();

            try
            {
                Console.Write("Minimum qiymet: ");
                if (!double.TryParse(Console.ReadLine(), out double minQiymet) || minQiymet < 0)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlish qiymet!");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Maximum qiymet: ");
                if (!double.TryParse(Console.ReadLine(), out double maxQiymet) || maxQiymet < minQiymet)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlish qiymet!");
                    Console.ReadKey();
                    return;
                }

                var itemler = await _menuItemService.GetByPriceIntervalAsync(minQiymet, maxQiymet);
                Console.WriteLine($"{Environment.NewLine}{minQiymet:F2} - {maxQiymet:F2} araligi:");
                Console.WriteLine();
                if (!itemler.Any())
                {
                    Console.WriteLine("Hec bir item yoxdur!");
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
            Console.WriteLine("=== MENU ITEMLAR ARASINDA ADA GORE AXTAR ===");
            Console.WriteLine();

            try
            {
                Console.Write("Axtarish metni: ");
                string axtar = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(axtar))
                {
                    Console.WriteLine(Environment.NewLine + "Axtarish metni bosh ola bilmez!");
                    Console.ReadKey();
                    return;
                }

                var itemler = await _menuItemService.SearchAsync(axtar);
                Console.WriteLine($"{Environment.NewLine}'{axtar}' ucun neticeler:");
                Console.WriteLine();
                if (!itemler.Any())
                {
                    Console.WriteLine("Hec bir netice tapilmadi!");
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

        static void ItemleriGoster(IEnumerable<MenuItemDto> itemler)
        {
            Console.WriteLine("Nomre | Ad | Kateqoriya | Qiymet");
            Console.WriteLine("-------------------------------------------");
            foreach (var item in itemler)
            {
                Console.WriteLine($"{item.Id} | {item.Name} | {item.CategoryName} | {item.Price:F2}");
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
                    Console.WriteLine("Hec bir item yoxdur!");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Movcud itemler:");
                ItemleriGoster(menuItemler);
                Console.WriteLine();

                var sifarisItemleri = new List<OrderItem>();

                while (true)
                {
                    Console.Write(Environment.NewLine + "Item nomresi (0 - sifarishi tamamla): ");
                    if (!int.TryParse(Console.ReadLine(), out int itemId) || itemId < 0)
                    {
                        Console.WriteLine("Yanlish nomre!");
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
                        Console.WriteLine("Yanlish sayi!");
                        continue;
                    }

                    sifarisItemleri.Add(new OrderItem
                    {
                        MenuItemId = itemId,
                        MenuItem = new MenuItem
                        {
                            Id = seciliItem.Id,
                            Name = seciliItem.Name,
                            Price = seciliItem.Price,
                            CategoryId = seciliItem.CategoryId
                        },
                        Count = sayi
                    });

                    Console.WriteLine("Sifarishe elave edildi!");
                }

                if (sifarisItemleri.Any())
                {
                    var sifaris = new Order
                    {
                        OrderItems = sifarisItemleri,
                        Date = DateTime.Now
                    };

                    _orderService.AddOrder(sifaris);
                    Console.WriteLine(Environment.NewLine + "Sifaris ugurla elave edildi!");
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "Hec bir item secilmedi!");
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
            Console.WriteLine("=== SIFARISHIN LEGVI ===");
            Console.WriteLine();

            try
            {
                Console.Write("Legv edilecek sifaris nomresi: ");
                if (!int.TryParse(Console.ReadLine(), out int sifarisId))
                {
                    Console.WriteLine(Environment.NewLine + "Yanlish nomre!");
                    Console.ReadKey();
                    return;
                }

                _orderService.RemoveOrder(sifarisId);
                Console.WriteLine(Environment.NewLine + "Sifaris legv edildi!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Environment.NewLine}Xeta: {ex.Message}");
            }

            Console.ReadKey();
        }

        static async Task ButunSifarisleriGoster()
        {
            Console.Clear();
            Console.WriteLine("=== BUTUN SIFARISHLER ===");
            Console.WriteLine();

            try
            {
                var sifarisler = await _orderService.GetAllOrdersAsync();
                if (!sifarisler.Any())
                {
                    Console.WriteLine("Hec bir sifaris yoxdur!");
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

        static async Task TarixAraligindaGoster()
        {
            Console.Clear();
            Console.WriteLine("=== TARIX ARALIGINA GORE SIFARISHLER ===");
            Console.WriteLine();

            try
            {
                Console.Write("Bashlangic tarixi (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime baslangic))
                {
                    Console.WriteLine(Environment.NewLine + "Yanlish tarix formati!");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Son tarix (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime son) || son < baslangic)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlish tarix formati!");
                    Console.ReadKey();
                    return;
                }

                var sifarisler = await _orderService.GetOrderByDateIntervalAsync(baslangic, son);
                Console.WriteLine($"{Environment.NewLine}{baslangic:yyyy-MM-dd} - {son:yyyy-MM-dd} araligindaki sifarishler:");
                Console.WriteLine();
                if (!sifarisler.Any())
                {
                    Console.WriteLine("Hec bir sifaris yoxdur!");
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
            Console.WriteLine("=== VERILMISH TARIXDE OLAN SIFARISHLER ===");
            Console.WriteLine();

            try
            {
                Console.Write("Tarix (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime tarix))
                {
                    Console.WriteLine(Environment.NewLine + "Yanlish tarix formati!");
                    Console.ReadKey();
                    return;
                }

                var butunSifarisler = await _orderService.GetAllOrdersAsync();
                var sifarisler = butunSifarisler.Where(o => o.Date.Date == tarix.Date).ToList();

                Console.WriteLine($"{Environment.NewLine}{tarix:yyyy-MM-dd} tarixindeki sifarishler:");
                Console.WriteLine();
                if (!sifarisler.Any())
                {
                    Console.WriteLine("Hec bir sifaris yoxdur!");
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
            Console.WriteLine("=== MEBLEG ARALIGINA GORE SIFARISHLER ===");
            Console.WriteLine();

            try
            {
                Console.Write("Minimum mebleg: ");
                if (!double.TryParse(Console.ReadLine(), out double min) || min < 0)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlish mebleg!");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Maximum mebleg: ");
                if (!double.TryParse(Console.ReadLine(), out double max) || max < min)
                {
                    Console.WriteLine(Environment.NewLine + "Yanlish mebleg!");
                    Console.ReadKey();
                    return;
                }

                var sifarisler = await _orderService.GetOrdersByPriceIntervalAsync(min, max);
                Console.WriteLine($"{Environment.NewLine}{min:F2} - {max:F2} araligindaki sifarishler:");
                Console.WriteLine();
                if (!sifarisler.Any())
                {
                    Console.WriteLine("Hec bir sifaris yoxdur!");
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
            Console.WriteLine("=== SIFARIS NOMRESINE GORE GOSTER ===");
            Console.WriteLine();

            try
            {
                Console.Write("Sifaris nomresi: ");
                if (!int.TryParse(Console.ReadLine(), out int sifarisId))
                {
                    Console.WriteLine(Environment.NewLine + "Yanlish nomre!");
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
                    Console.WriteLine($"{Environment.NewLine}Sifaris nomresi: {sifaris.Id}");
                    Console.WriteLine($"Tarix: {sifaris.Date:yyyy-MM-dd HH:mm:ss}");
                    Console.WriteLine($"Mebleg: {sifaris.TotalPrice:F2}");
                    Console.WriteLine($"Menu item sayi: {sifaris.TotalItemCount}");
                    Console.WriteLine(Environment.NewLine + "Sifaris itemleri:");
                    Console.WriteLine("Nomre | Ad | Sayi | Qiymet");
                    Console.WriteLine("-----------------------------------");
                    if (sifaris.OrderItems != null)
                    {
                        foreach (var item in sifaris.OrderItems)
                        {
                            Console.WriteLine($"{item.MenuItemId} | {item.MenuItemName} | {item.Count} | {item.MenuItemPrice:F2}");
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

        static void SifarisleriGoster(IEnumerable<OrderDto> sifarisler)
        {
            Console.WriteLine("Nomre | Mebleg | Menu Item Sayi | Tarix");
            Console.WriteLine("-----------------------------------------------");
            foreach (var sifaris in sifarisler)
            {
                Console.WriteLine($"{sifaris.Id} | {sifaris.TotalPrice:F2} | {sifaris.TotalItemCount} | {sifaris.Date:yyyy-MM-dd HH:mm}");
            }
        }
    }
}
