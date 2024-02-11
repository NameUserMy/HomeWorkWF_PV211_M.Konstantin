using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.F.M.Data
{
    internal class ApplicationContextFactory : IDesignTimeDbContextFactory<PFMContext>
    {
        private static IConfigurationRoot config;
        static ApplicationContextFactory()
        {
            
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("uplicationConfig.json");
            config = builder.Build();
        }
        public PFMContext CreateDbContext(string[] args  = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PFMContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            return new PFMContext(optionsBuilder.Options);
        }
       
    }
}
