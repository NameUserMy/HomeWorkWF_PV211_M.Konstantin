using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW_1.Additional_tasks_3
{
    internal class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Country { get; set; }
        public bool IsAdult { get; set; }

        public User (string? name, int age, string? country, bool isAdult)
        {
            
            Name = name;
            Age = age;
            Country = country;
            IsAdult = isAdult;
        }
        public User() { }
    }
}

 