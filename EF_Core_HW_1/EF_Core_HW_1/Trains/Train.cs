using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_1.Trains
{
    internal class Train
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public int QuantitySeats { get; set; }
        public float speed { get; set; }
        public Train() { }
        public Train( string? name, string? number, int quantitySeats, float speed)
        {
            
            Name = name;
            Number = number;
            QuantitySeats = quantitySeats;
            this.speed = speed;
        }
    }
}
