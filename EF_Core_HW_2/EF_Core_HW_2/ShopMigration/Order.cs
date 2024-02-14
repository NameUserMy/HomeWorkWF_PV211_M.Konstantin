using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_2.ShopMigration
{
    internal class Order
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int ProductId { get; set; }
        public List<Product>? Products { get; set; }

    }
}
