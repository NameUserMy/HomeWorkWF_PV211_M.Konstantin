using Azure;
using EF_Core_HW_1.Note;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EF_Core_HW_1.StudentsGroup
{
    internal class ContextGroup:DbContext
    {

        public DbSet<Student> Student { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }

        public ContextGroup(DbContextOptions optionNote) : base(optionNote)
        {
           // Database.EnsureDeleted();
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
        .HasMany(g => g.Group).
        WithMany(s => s.Student)
        .UsingEntity<StudentGroup>();
        }
    }
}
