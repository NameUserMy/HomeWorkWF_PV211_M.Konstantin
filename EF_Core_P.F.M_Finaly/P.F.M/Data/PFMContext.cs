using P.F.M.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using P.F.M.Model;

namespace P.F.M.Data
{
    internal class PFMContext:DbContext
    {

        
        public DbSet<User> Users { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<PFMTransaction> PFMTransactions { get; set; }
        public DbSet<UserOperation> Operations { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public PFMContext(DbContextOptions optionNote) : base(optionNote)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(e => e.Settings)
            .WithOne(e => e.User)
            .HasForeignKey<Settings>(e => e.UserId).IsRequired();
            modelBuilder.Entity<Settings>().Property(e => e.About).HasMaxLength(50);
            modelBuilder.Entity<Settings>().Property(e => e.login).HasMaxLength(25);
            modelBuilder.Entity<Settings>().Property(e => e.Pass).HasMaxLength(50);

            modelBuilder.Entity<User>()
            .HasMany(t => t.PFMTransactions)
            .WithOne(u => u.Users).HasForeignKey(e => e.UserId).IsRequired();

            modelBuilder.Entity<PFMTransaction>()
            .HasOne(e => e.UOperation)
            .WithOne(e => e.PFMTransaction)
            .HasForeignKey<UserOperation>(e => e.PFMTransactionId).IsRequired();
            modelBuilder.Entity<PFMTransaction>().Property(e => e.DateTransaction).HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<User>()
           .HasMany(t => t.BankAccounts)
           .WithOne(u => u.Users).HasForeignKey(e => e.UserId).IsRequired();


        }
            
    }
}
