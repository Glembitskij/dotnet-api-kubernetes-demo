using Microsoft.EntityFrameworkCore;
using ProductApi.Api.Models;

namespace ProductApi.Api.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2); 
        }
    }
}
