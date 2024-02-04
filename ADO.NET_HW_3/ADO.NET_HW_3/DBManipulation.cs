using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace ADO.NET_HW_3
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

    }
}
