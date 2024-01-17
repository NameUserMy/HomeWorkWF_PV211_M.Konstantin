using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW_1.Additional_tasks_1
{
    internal class Book
    {
        public string? Name { get; set; }
        public decimal Price  { get; set; }
        public int CountPage { get; set; }

        public Book() { }
        public  Book (string name,decimal price,int countPage)
        {
            Name = name;
            Price = price;
            CountPage = countPage;    
        }

    }
}
