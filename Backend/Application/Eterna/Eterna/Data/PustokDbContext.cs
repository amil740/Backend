using Microsoft.EntityFrameworkCore;
using Eterna.Models;

namespace Eterna.Data
{
    public class PustokDbContext : DbContext
    {
        public PustokDbContext(DbContextOptions<PustokDbContext> options) : base(options)
        {
           
        }
        public DbSet<Sliders> Sliders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=Amil;Database=PustokDb;Trusted_Connection=true;TrustServerCertificate=true;");
            }
        }
    }
}
