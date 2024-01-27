using ADO.NET_HW_2.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW_2.Library
{
    internal class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Publications { get; set; }
        public int Copies { get; set; }
        public int AuthorID { get; set; }

        public Book() { }
        public Book( string? title, string? publications, int copies, int authorID)
        {
           
            Title = title;
            Publications = publications;
            Copies = copies;
            AuthorID = authorID;
        }
    }
}


