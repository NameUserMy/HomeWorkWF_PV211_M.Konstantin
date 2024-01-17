using ADO.NET_HW_1.Additional_tasks_1;
using ADO.NET_HW_1.carsInclass;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW_1.Additional_tasks_3
{
    internal class UserDB
    {
        private SqlConnection? _connect;

        public void insertIntable(IEnumerable<User> users)
        {

            StringBuilder sqlQ = new StringBuilder();
            foreach (var item in users)
            {
                sqlQ.Append($"('{item.Name}','{item.Age}','{item.Country}','{item.IsAdult}'),");
            }
            sqlQ.Remove(sqlQ.Length - 1, 1);

            string sql = $"""
                INSERT INTO [User] ([Name],[Age],[Country],[IsAdult]) VALUES {sqlQ}
                """;
            SqlCommand sqlCommand = new SqlCommand(sql, _connect);
            sqlCommand.ExecuteNonQuery();
        }
        public void changeIsAdult()
        {
            string sql = """
                UPDATE  [User] SET [IsAdult]=0 WHERE [Age]<18 
                """;
            SqlCommand sqlCommand = new SqlCommand(sql, _connect);
            sqlCommand.ExecuteNonQuery();

        }
        public void GetAllUsers(List<User> users)
        {
            string sql = """ SELECT [Id],[Name],[Age],[Country],[IsAdult] FROM [User] """;
            SqlCommand sqlCommand = new SqlCommand(sql, _connect);
            users.Clear();
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Age = reader.GetInt32(2),
                            Country=reader.GetString(3),
                            IsAdult=reader.GetBoolean(4)
                        });
                    }
                }
            }
        }
        public UserDB(SqlConnection? connection)
        {
            this._connect = connection;
        }

    }
}
