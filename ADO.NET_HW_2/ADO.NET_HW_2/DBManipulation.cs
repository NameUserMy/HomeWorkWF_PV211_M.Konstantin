using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;

namespace ADO.NET_HW_2
{
    internal class DBManipulation
    {
        public string? GetConnectionString { get; private set; }
        public SqlConnection GetConnectionServer()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json");
            IConfiguration configuration = builder.Build();
            GetConnectionString = configuration.GetConnectionString("DefaultConnection");
            SqlConnection connection = new SqlConnection(GetConnectionString);
            return connection;
        }
        public void CreateAndUseDB(SqlConnection sqlCon,string nameDB)
        {
            SqlCommand sqlCommand = new SqlCommand($"CREATE DATABASE {nameDB}", sqlCon);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = $"USE {nameDB}";
            sqlCommand.ExecuteNonQuery();

        }
        public void CreateTable(SqlConnection sqlCon,string sqlCreateTable)
        {

           SqlCommand sqlCommand = new SqlCommand(sqlCreateTable, sqlCon);
           sqlCommand.ExecuteNonQuery();
        }
        public void ExecutQuery(string query,string tableName, Action<SqlDataReader> action, SqlConnection connection)
        {
                SqlCommand sqlCommand = new SqlCommand($"{tableName}", connection);
                sqlCommand.ExecuteNonQuery();
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    action(reader);
                }
        }





        //static void ExecuteQuery(string query, Action<SqlDataReader> action)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionStr))
        //    {
        //        connection.Open();
        //        SqlCommand sqlCommand = new SqlCommand($"USE Office", connection);
        //        sqlCommand.ExecuteNonQuery();

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            action(reader);
        //        }
        //    }
        //}





    }
}
