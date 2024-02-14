using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_2.ShopMigration
{
    internal class MigrationContext: DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-B4N5F81;Database=Shop;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasMany(e => e.Products)
            .WithMany();
        }
    }
}
