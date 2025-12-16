using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pustok.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.OldPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Weight)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Rating)
                .HasColumnType("decimal(3,2)");

            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Book>()
                .Property(b => b.OldPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Book>()
                .Property(b => b.Weight)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Book>()
                .Property(b => b.Rating)
                .HasColumnType("decimal(3,2)");

            modelBuilder.Entity<Slider>()
                .Property(s => s.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany()
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductImage>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Arts & Photography", IsActive = true },
                new Category { Id = 2, Name = "Biographies", IsActive = true },
                new Category { Id = 3, Name = "Business & Money", IsActive = true },
                new Category { Id = 4, Name = "Children's Books", IsActive = true },
                new Category { Id = 5, Name = "Comics", IsActive = true },
                new Category { Id = 6, Name = "Cookbooks", IsActive = true },
                new Category { Id = 7, Name = "Education", IsActive = true }
            );
            for (int i = 1; i <= 20; i++)
            {
                modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = i,
                        Name = $"Book Title {i}",
                        Description = $"This is a great book about topic {i}. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.",
                        Price = 30m + (i * 5),
                        OldPrice = 50m + (i * 7),
                        DiscountPercentage = 20 + (i % 5),
                        Author = $"Author {i}",
                        MainImagePath = $"product-{(i % 13) + 1}.jpg",
                        HoverImagePath = $"product-{((i + 1) % 13) + 1}.jpg",
                        StockQuantity = 50 + i,
                        SKU = $"BK{1000 + i}",
                        ISBN = $"978-{i}-{1000 + i}-{100 + i}-{i}",
                        PageCount = 200 + (i * 10),
                        Publisher = $"Publisher {i}",
                        PublishDate = DateTime.Now.AddYears(-i),
                        Language = "English",
                        Weight = 0.5m + (i * 0.1m),
                        Dimensions = "8.5 x 0.5 x 11 inches",
                        IsFeatured = i <= 12,
                        IsNew = i % 3 == 0,
                        IsOnSale = i <= 7,
                        ViewCount = i * 10,
                        SalesCount = i * 2,
                        Rating = 4.0m + (i % 10) * 0.1m,
                        ReviewCount = i * 5,
                        SaleEndDate = i <= 7 ? DateTime.Now.AddDays(30) : null,
                        CategoryId = (i % 7) + 1,
                        IsActive = true
                    }
                );
            }
        }
    }
}
