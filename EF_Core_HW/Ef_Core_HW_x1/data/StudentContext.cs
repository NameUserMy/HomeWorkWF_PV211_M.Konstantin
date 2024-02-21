using Ef_Core_HW_x1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_HW_x1.data
{
    internal class StudentContext:DbContext
    {
       
         public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set;}
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set;}

        public StudentContext(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
        .HasMany(e => e.Courses)
        .WithMany(e => e.Students)
        .UsingEntity<Enrollment>(
            c => c.HasOne<Course>().WithMany().HasForeignKey(e => e.CourseId),
            s => s.HasOne<Student>().WithMany().HasForeignKey(e => e.StudentId));
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Enrollment>().Property(d => d.EnrollmentDate).HasDefaultValue(DateOnly.Parse(DateTime.Now.ToShortDateString()));
        }
    }
}
