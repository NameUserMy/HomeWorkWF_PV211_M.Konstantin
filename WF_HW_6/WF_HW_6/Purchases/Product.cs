using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_HW_6
{
    public class Product
    {
        public string Title { get; set; }
        public string About { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set;}
        public Product() { }
        public Product(string title, string about,string category, decimal price)
        {
            Title = title;
            About = about;
            Category = category;
            Price = price;
        }
        public override string ToString()
        {
           return $"{Title},  Price: {Price}";
        }
    }
}
