

using EF_Core_HW_7.BookFastPrice.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_HW_7.BookFastPrice.Data
{
    internal class BookContext : DbContext
    {
        
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public BookContext(DbContextOptions optionNote) : base(optionNote)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Author>()
            .HasMany(e => e.Books)
            .WithMany(e => e.Authors)
            .UsingEntity("AythorsBooks");

            modelBuilder.Entity<Customer>()
            .HasMany(e => e.Orders)
            .WithOne(e => e.Customer).HasForeignKey(e => e.CustomerId).IsRequired();

        }
            
    }
}
