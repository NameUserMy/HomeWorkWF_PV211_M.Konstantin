using ADO.NET_HW_1.MountainsHW_1;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW_1.Additional_tasks_1
{
    internal class BookDB
    {
       private SqlConnection? connection;
        public decimal GetSumPrice()
        {
               decimal sum = 0;
               string sql = """ SELECT SUM([Price])  FROM Book """;
               SqlCommand sqlCommand = new SqlCommand(sql, connection);
               sum= (decimal)sqlCommand.ExecuteScalar();
               connection?.Close();
               return sum;
        }
        public decimal GetSumPage()
        {
            int page = 0;
            string sql = """ SELECT SUM([CountPage])  FROM Book """;
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            page = (int)sqlCommand.ExecuteScalar();
            connection?.Close();
            return page;
        }
        public void InsertBooks(IEnumerable<Book> books)
        {
            StringBuilder sqlQ = new StringBuilder();
            foreach (var item in books)
            {
                sqlQ.Append($"('{item.Name}','{item.Price}','{item.CountPage}'),");
            }
            sqlQ.Remove(sqlQ.Length - 1, 1);

            string sql = $"""
                INSERT INTO Book ([Name],[Price],[CountPage]) VALUES {sqlQ}
                """;
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.ExecuteNonQuery();
        }
       public BookDB(SqlConnection? connection)
        {
            this.connection = connection;
        }
    }
}
