using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_7.BookFastPrice.Model
{
    internal class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Orders>? Orders { get; set; }
    }
}
