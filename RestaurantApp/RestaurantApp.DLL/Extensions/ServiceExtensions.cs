using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.DLL.Data;
using RestaurantApp.DLL.Repositories;

namespace RestaurantApp.DLL.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDataLayerServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RestaurantDbContext>(options =>
              options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
