using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW_2.Library
{
    internal class Reader
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lname { get; set; }
        public string? Phone { get; set; }
        public Reader() { }
        public Reader( string? name, string? lname, string? phone)
        {
            Name = name;
            Lname = lname;
            Phone = phone;
        }
    }
}
