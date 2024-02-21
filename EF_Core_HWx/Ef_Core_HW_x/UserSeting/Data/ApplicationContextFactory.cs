using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_HW_x.UserSeting.Data
{
    internal class ApplicationContextFactory: IDesignTimeDbContextFactory<ContextUser>
    {

        private static IConfigurationRoot config;
        static ApplicationContextFactory()
        {

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("ConnectionServer.json");
            config = builder.Build();
        }
        public ContextUser CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextUser>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ForUser"));
            return new ContextUser(optionsBuilder.Options);
        }
    }
}
