using Microsoft.EntityFrameworkCore;
using Pustok.Models;

namespace Pustok
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews()
             .AddNewtonsoftJson(options =>
           {
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
               options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
           });

            builder.Services.AddDbContext<AppDbContext>(options =>
                     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
           name: "admin",
             pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(
           name: "default",
             pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
