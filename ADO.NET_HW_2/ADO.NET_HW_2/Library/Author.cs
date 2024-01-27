using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW_2.Library
{
    internal class Author
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lname { get; set; }
        public Author() { }
        public Author(string? name, string? lname)
        {
            Name = name;
            Lname = lname;
        }
    }
}
