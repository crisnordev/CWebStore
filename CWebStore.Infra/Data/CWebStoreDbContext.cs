using CWebStore.Domain.Entities;
using CWebStore.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CWebStore.Infra.Data;

public class CWebStoreDbContext : DbContext
{
    
        public CWebStoreDbContext(DbContextOptions<CWebStoreDbContext> options) : base(options) { }

        public DbSet<Category>? Categories { get; set; }

        public DbSet<Product>? Products { get; set; }      
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
            options.UseSqlServer("Server=localhost,1433;Database=CwebStore;User ID=sa;Password=1q2w3e4r@#$");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            base.OnModelCreating(modelBuilder);
        }
}