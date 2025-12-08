using Microsoft.EntityFrameworkCore;
using Eterna.Data;
using Eterna.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PustokDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") 
      ?? "Server=.;Database=PustokDb;Trusted_Connection=true;TrustServerCertificate=true;"));

var app = builder.Build();

// Apply migrations and seed data
try
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<PustokDbContext>();
        context.Database.Migrate();
    }

    // Seed initial data
    DataSeeder.SeedData(app);
}
catch (Exception ex)
{
    Console.WriteLine($"Database initialization error: {ex.Message}");
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
