using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADO.NET_HW_2.Library
{
    internal class LibraryDB
    {
        private SqlConnection _connection;

        #region Reader Method
        public void AddReader(Reader reader)
        {

            SqlCommand use_sp = new SqlCommand("sp_insertReader", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.AddRange(new SqlParameter[] {
            new SqlParameter("@name", SqlDbType.NVarChar,20){Value=reader.Name},
            new SqlParameter("@lName", SqlDbType.NVarChar,20){Value=reader.Lname},
            new SqlParameter("@phone", SqlDbType.NVarChar,30){Value=reader.Phone}
            });
            use_sp.ExecuteNonQuery();

        }

        public void UpdateReader(Reader reader)
        {

            SqlCommand use_sp = new SqlCommand("sp_updateReader", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.AddRange(new SqlParameter[] {
            new SqlParameter("@name", SqlDbType.NVarChar,20){Value=reader.Name},
            new SqlParameter("@lName", SqlDbType.NVarChar,20){Value=reader.Lname},
            new SqlParameter("@phone", SqlDbType.NChar,30){Value=reader.Phone},
            new SqlParameter("@id", SqlDbType.Int){Value=reader.Id}
            });
            use_sp.ExecuteNonQuery();
        }

        public void GetListReader()
        {
            SqlCommand use_sp = new SqlCommand("sp_getReader", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.ExecuteNonQuery();
            using (SqlDataReader reader = use_sp.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Reader\nName : {reader.GetString(0)}\n" +
                            $"Lname : {reader.GetString(1)}\nPhone : {reader.GetString(2)}\n\n ");

                    }
                }

            }

        }
        #endregion

        #region Author  metod
        public void AddAuthor(Author author)
        {

            SqlCommand use_sp = new SqlCommand("sp_insertAuthor", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.AddRange(new SqlParameter[] {
            new SqlParameter("@name", SqlDbType.NVarChar,20){Value=author.Name},
            new SqlParameter("@lName", SqlDbType.NVarChar,20){Value=author.Lname},
            
            });
            use_sp.ExecuteNonQuery();

        }

        public void GetListAuthor()
        {
            SqlCommand use_sp = new SqlCommand("sp_getAUthors", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.ExecuteNonQuery();
            using (SqlDataReader reader = use_sp.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Autor\nName : {reader.GetString(0)}\nLname : {reader.GetString(1)}\n\n ");
                            
                    }
                }

            }

        }
        #endregion

        #region Book method
        public void AddABook(Book book)
        {

            SqlCommand use_sp = new SqlCommand("sp_insertBook", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.AddRange(new SqlParameter[] {
            new SqlParameter("@title", SqlDbType.NVarChar,20){Value=book.Title},
            new SqlParameter("@publication", SqlDbType.Date){Value=book.Publications},
            new SqlParameter("@copies", SqlDbType.Int){Value=book.Copies},
            new SqlParameter("@author", SqlDbType.Int){Value=book.AuthorID},

            });
            use_sp.ExecuteNonQuery();

        }
        public void RantABook(int bookId,int rentId)
        {

            SqlCommand use_sp = new SqlCommand("sp_rentBook", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.AddRange(new SqlParameter[] {
            new SqlParameter("@bookId", SqlDbType.Int){Value=bookId},
            new SqlParameter("@readerId", SqlDbType.Int){Value=rentId},

            });
            use_sp.ExecuteNonQuery();

        }
        public void RefundBook(int bookId, int rentId)
        {

            SqlCommand use_sp = new SqlCommand("sp_refundBook", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.AddRange(new SqlParameter[] {
            new SqlParameter("@bookId", SqlDbType.Int){Value=bookId},
            new SqlParameter("@readerId", SqlDbType.Int){Value=rentId},

            });
            use_sp.ExecuteNonQuery();

        }
        public void GetListBook()
        {
            SqlCommand use_sp = new SqlCommand("sp_getBook", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.ExecuteNonQuery();
            using (SqlDataReader reader = use_sp.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($" Title : {reader.GetString(0)} \n " +
                            $"Autor\n" +
                            $"Name : {reader.GetString(1)}\n  " +
                            $"Lname : {reader.GetString(2)}\n " +
                            $"Publication : {reader.GetDateTime(3)} \n\n");
                    }
                }

            }

        }
      
        #endregion


        public LibraryDB(SqlConnection connection)=> _connection = connection;
        
        
    }
}
