using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_HW_x1.data
{
    internal class ApplicationsFactory: IDesignTimeDbContextFactory<StudentContext>
    {

        private static IConfigurationRoot config;
        static ApplicationsFactory()
        {

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("connectionApp.json");
            config = builder.Build();
        }
        public StudentContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            return new StudentContext(optionsBuilder.Options);
        }

    }
}
