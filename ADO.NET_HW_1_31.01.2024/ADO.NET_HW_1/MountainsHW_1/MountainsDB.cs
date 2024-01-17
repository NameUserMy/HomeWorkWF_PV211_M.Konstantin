using ADO.NET_HW_1.carsInclass;
using ADO.NET_HW_1.MountainsHW_1;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ADO.NET_HW_1.MountainsHW_1
{
    internal class MountainsDB
    {
        public void AddMountain(SqlConnection sqlCon, Mountains mountain)
        {
            
            string sql = $"""
                INSERT INTO Mountain ([Name],[Height],[Country]) VALUES ('{mountain.Name}','{mountain.Height}','{mountain.Country}')
                """;
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            sqlCommand.ExecuteNonQuery();
        }
        public void AddMountains(SqlConnection sqlCon, List<Mountains> mountains)
        {

            StringBuilder sqlQ = new StringBuilder();
            foreach (var item in mountains)
            {
                sqlQ.Append($"('{item.Name}','{item.Height}','{item.Country}'),");
            }
            sqlQ.Remove(sqlQ.Length - 1, 1);
            
            string sql = $"""
                INSERT INTO Mountain ([Name],[Height],[Country]) VALUES {sqlQ}
                """;
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            sqlCommand.ExecuteNonQuery();
        }
        public void GetAllMountains(SqlConnection sqlCon, List<Mountains> mountains)
        {
            string sql = """ SELECT [Id],[Name],[Height],[Country] FROM Mountain """;
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        mountains.Add(new Mountains{
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Height = reader.GetDecimal(2),
                            Country = reader.GetString(3),
                        });
                    }
                }
            }
        }
        public void GetmountainBYId(SqlConnection sqlCon,int id, Mountains mountain)
        {


            string sql = $""" SELECT [Id],[Name],[Height],[Country] FROM Mountain WHERE [Id]='{id}' """;
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        mountain.Id = reader.GetInt32(0);
                        mountain.Name = reader.GetString(1);
                        mountain.Height = reader.GetDecimal(2);
                        mountain.Country = reader.GetString(3);
                        
                    }
                }
            }

        }
        public void DeleteMountainByMaxHeight(SqlConnection sqlCon)
        {
            string sql = """
                DELETE FROM Mountain WHERE Mountain.[Height] = (SELECT MAX(Mountain.[Height]) FROM Mountain)
                """;
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            sqlCommand.ExecuteNonQuery();
        }
        public void DeleteMountainByCountry(SqlConnection sqlCon,string country)
        {
            string sql = $"""
                DELETE FROM Mountain WHERE Mountain.[Height]=(SELECT MAX(Mountain.[Height]) FROM Mountain)
                AND
                Mountain.[Country] = '{country}'
                """;
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            sqlCommand.ExecuteNonQuery();
        }
    }
}

//