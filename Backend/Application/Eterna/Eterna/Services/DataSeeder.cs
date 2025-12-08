using Eterna.Data;
using Eterna.Models;

namespace Eterna.Services
{
    public class DataSeeder
    {
        public static void SeedData(IApplicationBuilder app)
        {
            try
            {
                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<PustokDbContext>();
                    
                    // Check if sliders already exist
                    if (!context.Sliders.Any())
                    {
                        var sliders = new List<Sliders>
                        {
                            new Sliders
                            {
                                Title = "H.G. Wells",
                                Description = "De Vengeance - Cover Up Front Of Books and Leave Summary",
                                ImageUrl = "/image/bg-images/home-slider-2-ai.png"
                            },
                            new Sliders
                            {
                                Title = "Fiction Collection",
                                Description = "Explore the best fiction books from around the world",
                                ImageUrl = "/image/bg-images/home-slider-2-ai.png"
                            },
                            new Sliders
                            {
                                Title = "Mystery & Thriller",
                                Description = "Discover thrilling stories that keep you on the edge of your seat",
                                ImageUrl = "/image/bg-images/home-slider-2-ai.png"
                            }
                        };

                        context.Sliders.AddRange(sliders);
                        context.SaveChanges();
                        Console.WriteLine("Database seeded successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Seeding error: {ex.Message}");
            }
        }
    }
}
