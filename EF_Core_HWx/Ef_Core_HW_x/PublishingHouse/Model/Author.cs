using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_HW_x.PublishingHouse.Model
{
    internal class Author
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lname { get; set; }
        public string? Description { get; set; }
    }
}
