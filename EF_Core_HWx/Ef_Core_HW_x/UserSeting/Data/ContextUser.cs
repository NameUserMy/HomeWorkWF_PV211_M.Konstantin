using Ef_Core_HW_x.UserSeting.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_HW_x.UserSeting.Data
{
    internal class ContextUser:DbContext
    {



       public DbSet<User> Users { get; set; }
       public DbSet<SettingUser> SettingUsers { get; set; }
       public ContextUser (DbContextOptions options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(e => e.Setting)
                .WithOne(e => e.User).
                HasForeignKey<SettingUser>(e => e.UserId).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
