using InsuranceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceProject.Data
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure decimal precision
            modelBuilder.Entity<Policy>()
                .Property(p => p.Premium)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Policy>()
                .Property(p => p.CoverageAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Claim>()
                .Property(c => c.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Quote>()
                .Property(q => q.EstimatedPremium)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Quote>()
                .Property(q => q.CoverageAmount)
                .HasPrecision(18, 2);

            // Configure relationships
            modelBuilder.Entity<Policy>()
                .HasOne(p => p.Customer)
                .WithMany(c => c.Policies)
                .HasForeignKey(p => p.CustomerId);

            modelBuilder.Entity<Claim>()
                .HasOne(c => c.Customer)
                .WithMany(cu => cu.Claims)
                .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<Claim>()
                .HasOne(c => c.Policy)
                .WithMany(p => p.Claims)
                .HasForeignKey(c => c.PolicyId);

            modelBuilder.Entity<Quote>()
                .HasOne(q => q.Customer)
                .WithMany(c => c.Quotes)
                .HasForeignKey(q => q.CustomerId);

            // Add unique constraints
            modelBuilder.Entity<Policy>()
                .HasIndex(p => p.PolicyNumber)
                .IsUnique();

            modelBuilder.Entity<Claim>()
                .HasIndex(c => c.ClaimNumber)
                .IsUnique();

            modelBuilder.Entity<Quote>()
                .HasIndex(q => q.QuoteNumber)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}