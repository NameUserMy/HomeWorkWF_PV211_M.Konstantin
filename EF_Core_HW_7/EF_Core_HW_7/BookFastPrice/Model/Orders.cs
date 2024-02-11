using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_7.BookFastPrice.Model
{
    internal class Orders
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Decimal TotalCount { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
