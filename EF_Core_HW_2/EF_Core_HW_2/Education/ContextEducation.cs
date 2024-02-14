using EF_Core_HW_2.ShopMigration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_2.Education
{
    internal class ContextEducation:DbContext
    {


        public DbSet<Course> Courses { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations { get; set; }
        public DbSet<LectureProgress> LectureProgresses { get; set; }
        public DbSet<WorkshopProgress> WorkshopProgresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-B4N5F81;Database=Education;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
            .HasMany(e => e.students)
            .WithMany(e => e.Courses)
            .UsingEntity<CourseRegistration>(
            s => s.HasOne<Student>().WithMany().HasForeignKey(e => e.StudentId),
            c => c.HasOne<Course>().WithMany().HasForeignKey(e => e.CourseId));

            modelBuilder.Entity<Workshop>()
           .HasMany(e => e.students)
           .WithMany(e => e.Workshops)
           .UsingEntity<WorkshopProgress>(
           s => s.HasOne<Student>().WithMany().HasForeignKey(e => e.StudentId),
           c => c.HasOne<Workshop>().WithMany().HasForeignKey(e => e.WorkshopId));

            modelBuilder.Entity<Lecture>()
           .HasMany(e => e.students)
           .WithMany(e => e.Lectures)
           .UsingEntity<LectureProgress>(
           s => s.HasOne<Student>().WithMany().HasForeignKey(e => e.StudentId),
           c => c.HasOne<Lecture>().WithMany().HasForeignKey(e => e.LectureId));
        }
    }
}
