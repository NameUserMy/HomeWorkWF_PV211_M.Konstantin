using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_HW_x1.Model
{
    internal class Course
    {
        public int Id { get; set;}
        public string? Title { get; set;}
        public string? Description { get; set;}
        public List<Student>? Students { get; set; } = new();
        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
    }
}
