using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW_1.carsInclass
{
    internal class Car
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Year { get; set; }

        public override string ToString()
        {
            return $"Id : {Id} Model : {Model}, Year : {Year} ";
        }
    }
}
