using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_HW_x.PublishingHouse.Model
{
    internal class Publisher
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Adress { get; set; }
        public string? Description { get; set; }
       
    }
}
