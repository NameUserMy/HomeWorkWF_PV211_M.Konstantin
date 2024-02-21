using Ef_Core_HW_x.UserSeting.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_HW_x.PublishingHouse.Data
{
    internal class IFactoriContext : IDesignTimeDbContextFactory<PublishContext>
    {

        private static IConfigurationRoot config;
        static IFactoriContext()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("ConnectionServer.json");
            config = builder.Build();
        }
        public PublishContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PublishContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ForPublish"));
            return new PublishContext(optionsBuilder.Options);
        }
    }
}
