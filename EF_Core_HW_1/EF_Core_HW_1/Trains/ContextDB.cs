
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_1.Trains
{
    internal class ContextDB:DbContext
    {


        public DbSet<Train> MyTrain { get; set; }
        public  ContextDB(DbContextOptions option):base(option) {
            Database.EnsureCreated();
        }
    }
}
