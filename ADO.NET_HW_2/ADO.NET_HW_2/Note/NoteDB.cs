using ADO.NET_HW_2.Library;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET_HW_2.ChroniclesOfAscents;
using Microsoft.Identity.Client;

namespace ADO.NET_HW_2.Note
{
    internal class NoteDB
    {
        private readonly SqlConnection _connection;
        public void AddnewNote(params Note[] note)
        {

            foreach (var item in note)
            {
                SqlCommand use_sp = new SqlCommand("sp_insertNote", _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                use_sp.Parameters.AddRange(new SqlParameter[] {
            new SqlParameter("@title", SqlDbType.NVarChar,20){Value=item.Title},
            new SqlParameter("@description", SqlDbType.NVarChar,200){Value=item.Description},
            new SqlParameter("@userId", SqlDbType.Int){Value=item.UserId}
            });
                use_sp.ExecuteScalar();
            }
        }
        public void AddUser(User user)
        {
            SqlCommand use_sp = new SqlCommand("sp_insertUser", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar,20){Value=user.Name});
            use_sp.ExecuteScalar();


        }
        public void DeleteListNote(int userId)
        {
            SqlCommand use_sp = new SqlCommand("sp_deleteNote", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = userId });
            use_sp.ExecuteScalar();
        }
        public void GetListNote(int userId)
        {
            SqlCommand use_sp = new SqlCommand("sp_selectNote", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            use_sp.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = userId });
            use_sp.ExecuteNonQuery();
            using (SqlDataReader reader = use_sp.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Title : {reader.GetString(0)}\n" +
                            $"Description : {reader.GetString(1)}\n\n ");

                    }
                }

            }

        }

        public void UpdateNote(params Note[] note)
        {

            foreach (var item in note)
            {
                SqlCommand use_sp = new SqlCommand("sp_UpdateNote", _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                use_sp.Parameters.AddRange(new SqlParameter[] {
            new SqlParameter("@title", SqlDbType.NVarChar,20){Value=item.Title},
            new SqlParameter("@description", SqlDbType.NVarChar,200){Value=item.Description},
            new SqlParameter("@userId", SqlDbType.Int){Value=item.UserId},
            new SqlParameter("@noteId", SqlDbType.Int){Value=item.Id}
            });
                use_sp.ExecuteScalar();
            }
        }

        public NoteDB(SqlConnection connectServer) => _connection = connectServer;
    }
}
