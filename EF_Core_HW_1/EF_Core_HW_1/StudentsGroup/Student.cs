using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_1.StudentsGroup
{
    internal class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Group>? Group { get; set;}
    }
}
