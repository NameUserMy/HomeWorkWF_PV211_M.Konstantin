using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_1.Note
{
    internal class User
    {
        public int Id { get; set;}
        public string? Name { get; set; }
        public List<Task>? Note { get; set; } = new List<Task>();
    }
}
