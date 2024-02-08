using EF_Core_HW_1.Note;
using Microsoft.EntityFrameworkCore;



namespace EF_Core_HW_1.SQlite
{
    internal class SQliteContext:DbContext
    {
        public DbSet<First> First { get; set; }
        public DbSet<Second> Second { get; set; }
        public DbSet<Third> Third { get; set; }


        public SQliteContext(DbContextOptions optionNote) : base(optionNote)
        {
            Database.EnsureCreated();

        }
    }
}
