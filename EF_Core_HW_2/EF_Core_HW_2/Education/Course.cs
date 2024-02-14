using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EF_Core_HW_2.Education
{
    internal class Course
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<Lecture>? Lectures { get; set; } = new();
        public List<Workshop>? Workshops { get; set; } = new();
        public List<Student>? students { get; set; } = new();
        public override string ToString()
        {
            return $"Title : {Title} Description : {Description}";
        }
    }
}
