using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;
using Pustok.Services.Implementations;
using Pustok.Services.Interfaces;

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

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
   {
       options.Password.RequiredLength = 8;
       options.Password.RequireNonAlphanumeric = false;
       options.Password.RequireDigit = true;
       options.Password.RequireLowercase = true;
       options.Password.RequireUppercase = true;
       options.User.RequireUniqueEmail = true;
       options.Lockout.MaxFailedAccessAttempts = 5;
       options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
   })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
                   {
                       options.LoginPath = "/Account/Login";
                       options.LogoutPath = "/Account/Logout";
                       options.AccessDeniedPath = "/Account/AccessDenied";
                       options.ExpireTimeSpan = TimeSpan.FromDays(7);
                       options.SlidingExpiration = true;
                   });
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IFileService, FileService>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
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
