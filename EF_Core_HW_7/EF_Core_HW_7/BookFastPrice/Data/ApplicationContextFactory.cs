using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EF_Core_HW_7.BookFastPrice.Data
{
    internal class ApplicationContextFactory : IDesignTimeDbContextFactory<BookContext>
    {
        private static IConfigurationRoot config;
        static ApplicationContextFactory()
        {
            
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("connectionServer.json");
            config = builder.Build();
        }
        public BookContext CreateDbContext(string[] args  = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            return new BookContext(optionsBuilder.Options);
        }
       
    }
}
