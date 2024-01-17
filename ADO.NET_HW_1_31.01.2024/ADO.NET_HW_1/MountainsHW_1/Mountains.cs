using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW_1.MountainsHW_1
{
    internal class Mountains
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Height { get; set; }
        public string? Country { get; set; }
        public Mountains(string name, decimal height, string country)
        {
            Name = name;
            Height = height;
            Country = country;
        }
        public Mountains() { }
    }
}
