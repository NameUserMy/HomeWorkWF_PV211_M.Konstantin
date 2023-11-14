using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_HW_6
{
    class Total
    {
        decimal bill;
        public decimal test(List<Product> product)
        {
            bill=product.Sum(x => x.Price);
            return bill;
        }
    }
}
