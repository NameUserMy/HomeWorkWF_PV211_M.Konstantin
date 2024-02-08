using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_1.Note
{
    internal class ContexDBNote:DbContext
    {
        public DbSet<Task> Task { get; set; }
        public DbSet<User> User { get; set; }


        public  ContexDBNote(DbContextOptions optionNote) : base(optionNote)
        {
            Database.EnsureCreated();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasMany(e => e.Note).WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);
            modelBuilder.Entity<User>().Property(u => u.Name).HasMaxLength(20);
            modelBuilder.Entity<User>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<Task>().Property(t => t.Title).HasMaxLength(50);
            modelBuilder.Entity<Task>().Property(t => t.CreateDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Task>().Property(t => t.Status).HasDefaultValue(false);
        }
    }
}
