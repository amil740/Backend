using Microsoft.EntityFrameworkCore;
using Eterna.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PustokDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") 
        ?? "Server=Amil;Database=PustokDb;Trusted_Connection=true;TrustServerCertificate=true;"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapGet("/", context =>
{
    context.Response.ContentType = "text/html";
    return context.Response.SendFileAsync(Path.Combine(app.Environment.WebRootPath, "html/index.html"));
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
