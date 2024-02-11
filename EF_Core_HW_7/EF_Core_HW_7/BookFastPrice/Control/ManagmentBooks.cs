using EF_Core_HW_7.BookFastPrice.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_7.BookFastPrice.Control
{
    internal class ManagmentBooks
    {
        private readonly BookContext _db;

        public void ChangePriceByAuthor(int authorId,decimal price)
        {

            var param1 = new SqlParameter("@id", authorId);
            var param2 = new SqlParameter("@price", price);
            _db.Database.ExecuteSqlRaw("sp_changePriceByAuthor @id, @price", param1, param2);
        }

        public  ManagmentBooks(BookContext db)=> _db = db;
        
    }
}
