using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_1.StudentsGroup
{
    internal class Group
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<Student>? Student { get; set;}
    }
}
