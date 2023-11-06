using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_HW_1
{
    class User
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public User() { }
        public User(string Name,string Country,int Age,int Weight) {

            this.Name = Name;
            this.Country = Country;
            this.Age = Age;
            this.Weight = Weight;
        }
        public override string ToString()
        {
            return $"Name {Name} Country {Country} Age {Age} Weight {Weight}";
        }

    }
}
