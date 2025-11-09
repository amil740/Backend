using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.BLL.Extensions;
using RestaurantApp.DLL.Data;
using RestaurantApp.DLL.Extensions;

namespace RestaurantApp.PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            string connectionString = "Server=Amil;Database=RestaurantApp;Trusted_Connection=true;Encrypt=false;TrustServerCertificate=true;";

            services.AddDataLayerServices(connectionString);
            services.AddBusinessLogicServices();

            var serviceProvider = services.BuildServiceProvider();

            using (var context = serviceProvider.GetRequiredService<RestaurantDbContext>())
            {
                try
                {
                    context.Database.Migrate();
                    Console.WriteLine("✓ Database connection successful!");
                    Console.WriteLine("✓ Migrations applied successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"✗ Database connection failed: {ex.Message}");
                }
            }
        }
    }
}
