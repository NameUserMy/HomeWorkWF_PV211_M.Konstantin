using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW_1.carsInclass
{


    internal class CarDb
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
        public void CreateAndUseDBCars(SqlConnection sqlCon)
        {
            SqlCommand sqlCommand = new SqlCommand("CREATE DATABASE Cars", sqlCon);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = "USE Cars";
            sqlCommand.ExecuteNonQuery();

        }
        public void CreateTableCar(SqlConnection sqlCon)
        {
            string sql = """
                CREATE TABLE [dbo].[Car] (
                    [Id] INT  PRIMARY KEY  IDENTITY (1, 1) NOT NULL,
                    [Model] NVARCHAR (100) NOT NULL,
                    [Year] Date  NOT NULL,
                );               
                """;
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            sqlCommand.ExecuteNonQuery();
        }
        public void FillTableCar(SqlConnection sqlCon)
        {
            string sql = """
                INSERT INTO [Car] ([Model],[Year])VALUES('Frod','2024-01-16'),('Mazda','1999-01-16'),('Toyota','2005-01-16'),
                ('Fiat','2023-01-16'),('Fiat','2010-01-16');               
                """;
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            sqlCommand.ExecuteNonQuery();


        }
        public void ReadAllCars(SqlConnection sqlCon, List<Car> allCars)
        {
            string sql = """ SELECT Id,Model,Year FROM [Car] """;
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        allCars.Add(new Car
                        {
                            Id = reader.GetInt32(0),
                            Model = reader.GetString(1),
                            Year = reader.GetDateTime(2).ToString()
                        });
                    }
                }
            }
        }
        public void ReadCars2018(SqlConnection sqlCon, List<Car> Cars2018)
        {
            string sql = """ SELECT Id,Model,Year FROM [Car] WHERE Year<='2018-01-16' """;
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Cars2018.Add(new Car
                        {
                            Id = reader.GetInt32(0),
                            Model = reader.GetString(1),
                            Year = reader.GetDateTime(2).ToString()
                        });
                    }
                }
            }
        }

    }
}
