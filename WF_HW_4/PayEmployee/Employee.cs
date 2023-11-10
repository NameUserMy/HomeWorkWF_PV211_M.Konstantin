using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_HW_4
{
    class Employee
    {
        public Employee(string name, string sureName, string lastName, int hoursPerMonth, double payPerHour)
        {
            Name = name;
            SureName = sureName;
            LastName = lastName;
            HoursPerMonth = hoursPerMonth;
            PayPerHour = payPerHour;
        }
        public Employee() { }
        public string Name { get; set; }
        public string SureName { get; set; }
        public string LastName { get; set; }
        public int HoursPerMonth { get; set; }
        public double PayPerHour { get; set; }

    }
}
