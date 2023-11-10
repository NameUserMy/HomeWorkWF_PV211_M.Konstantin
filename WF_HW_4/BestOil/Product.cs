using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_HW_4
{
    class Product
    {
        double _price;
        public double Price { get { return _price; }
            set { _ =(value > 0) ? _price = value : throw new ArgumentException("Error (value < 0) ");}
        }
        public int Count { get; set; }
        public string Title { get; set; }
        public Product(double price, string title)
        {

            Price = price;
            Title = title;
        }
        public Product() { }
        public override string ToString()
        {
            return $"{Title}  {Price}";
        }
    }
}
