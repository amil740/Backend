using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.BLL.Interfaces;
using RestaurantApp.BLL.Services;

namespace RestaurantApp.BLL.Extensions
{
    public static class ServiceExtensions
    {
     public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
      {
            services.AddScoped<IMenuItemService, MenuItemService>();
            services.AddScoped<ICategoryService, CategoryService>();
          services.AddScoped<IOrderService, OrderService>();

         return services;
        }
    }
}
