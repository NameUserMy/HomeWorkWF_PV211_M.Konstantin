using EF_Core_HW_1.Note;
using EF_Core_HW_1.SQlite;
using EF_Core_HW_1.StudentsGroup;
using EF_Core_HW_1.Trains;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_1
{
    internal class ConectionServer
    {

        public DbContextOptions GetConnectionServerSql()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json");
            var configuration = builder.Build();
            var getOption = new DbContextOptionsBuilder<ContextDB>();
            var option = getOption.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).Options;
            return option;
        }

        public DbContextOptions GetConnectionServerSqlNote ()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json");
            var configuration = builder.Build();
            var getOption = new DbContextOptionsBuilder<ContexDBNote>();
            var optionNote = getOption.UseSqlServer(configuration.GetConnectionString("NoteConnection")).Options;
            return optionNote;
        }

        public DbContextOptions GetConnectionSQlite()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json");
            var configuration = builder.Build();
            var getOption = new DbContextOptionsBuilder<SQliteContext>();
            var optionsqlite = getOption.UseSqlite(configuration.GetConnectionString("SQLiteConnection")).Options;
            return optionsqlite;
        }

        public DbContextOptions GetConnectionServerSqlGroup()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json");
            var configuration = builder.Build();
            var getOption = new DbContextOptionsBuilder<ContextGroup>();
            var optiongroup = getOption.UseSqlServer(configuration.GetConnectionString("GroupConnection")).Options;
            return optiongroup;
        }
    }
}
