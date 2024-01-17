using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using ADO.NET_HW_1.carsInclass;
using ADO.NET_HW_1.MountainsHW_1;
using ADO.NET_HW_1.Additional_tasks_1;
using ADO.NET_HW_1.Additional_tasks_3;
using System.Runtime.InteropServices;


namespace ADO.NET_HW_1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            DBManipulation db = new DBManipulation();
            var connection = db.GetConnectionServer();//Only servver
            #region In class room

            List<Car> Allcars = new List<Car>();
            List<Car> cars2018 = new List<Car>();
            CarDb DB = new CarDb();
            using (connection)
            {
                connection.Open();
                DB.CreateAndUseDBCars(connection);// Create and select DB
                DB.CreateTableCar(connection);
                Console.WriteLine("normal");
                DB.FillTableCar(connection);
                //SqlCommand sql = new SqlCommand("USE Cars", connection);
                //sql.ExecuteNonQuery();
                DB.ReadAllCars(connection, Allcars);
                DB.ReadCars2018(connection, cars2018);

                foreach (var item in Allcars)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("----------------------");
                foreach (var item in cars2018)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            #endregion

            #region HW_1 Mountains 
            string tableMountains = """
                    CREATE TABLE Mountain
                    (
                    [Id] INT PRIMARY KEY IDENTITY NOT NULL,
                    [Name] NVARCHAR (120) CHECK ([Name]<>'') NOT NULL,
                    [Height] DECIMAL (10,2) CHECK ([Height]>0.0) NOT NULL,
                    [Country] NVARCHAR (120) CHECK ([Country]<>'') NOT NULL,
                    );
                    """;



            Mountains mountains = new Mountains("Some name", 45666, "Any place");
            MountainsDB mountainsDB = new MountainsDB();
            Mountains mountainByid = new Mountains();
            List<Mountains> AllMountains = new List<Mountains>();


            using (connection)
            {
                connection.Open();
                db.CreateAndUseDB(connection, "Mountains");
                db.CreateTable(connection, tableMountains);
                //SqlCommand sqluse = new SqlCommand("USE Mountains", connection);
                //sqluse.ExecuteNonQuery();
                mountainsDB.AddMountain(connection, mountains);
                mountainsDB.AddMountains(connection, new List<Mountains> {
                        new Mountains("ANY", 556654, "ANY"), new Mountains("ANY 1",2500, "ANY 1"),
                        new Mountains("ANY 2", 3800, "ANY 2"),new Mountains("ANY 3", 88000, "ANY 3"),
                        new Mountains("ANY 3",990000, "ANY 3")
                    });
                mountainsDB.GetAllMountains(connection, AllMountains);
                foreach (var item in AllMountains)
                {
                    Console.WriteLine($"{item.Id} , {item.Name},{item.Height} , {item.Country}");
                }

                mountainsDB.GetmountainBYId(connection, 3, mountainByid);
                Console.WriteLine($"ID : {mountainByid.Id} Name : {mountainByid.Name}");
                mountainsDB.DeleteMountainByMaxHeight(connection);
                mountainsDB.DeleteMountainByCountry(connection, "ANY 3");
            }
            #endregion

            #region Additional tasks 1


            BookDB bookDB = new BookDB(connection);
            string tableBook = """
                CREATE TABLE Book
                (
                [Id] INT PRIMARY KEY IDENTITY NOT NULL,
                [Name] NVARCHAR (120) CHECK ([Name]<>'') NOT NULL,
                [Price] DECIMAL (10,2) CHECK ([Price]>0.0) NOT NULL,
                [CountPage] INT CHECK ([CountPage]<>'') NOT NULL,
                );
                """;


            using (connection)
            {
                connection.Open();
                db.CreateAndUseDB(connection, "Books");
                db.CreateTable(connection, tableBook);
                bookDB.InsertBooks(new List<Book> { new Book("Top book", 85, 33), new Book("Midle book", 120, 88), new Book("Low book", 22, 12) });

                SqlCommand sqluse = new SqlCommand("USE Books", connection);
                sqluse.ExecuteNonQuery();
                Console.WriteLine($"Sum price all books : {bookDB.GetSumPrice()}");
                connection.Open();
                sqluse.CommandText = "USE Books";
                sqluse.ExecuteNonQuery();
                Console.WriteLine($"Sum page all books : {bookDB.GetSumPage()}");
                connection.Close();

            }

            #endregion

            #region Additional tasks 2

            int answer;
            using (connection)
            {
                try
                {
                    connection.Open();
                    db.CreateAndUseDB(connection, "VegetablesAndFruits");
                    Console.WriteLine("Enter 1 for connect database");
                    answer = Convert.ToInt32(Console.ReadLine());
                    if (answer == 1)
                    {
                        try
                        {
                            SqlCommand sqlCommand = new SqlCommand("USE VegetablesAndFruits", connection);
                            sqlCommand.ExecuteNonQuery();
                            Console.WriteLine("Connect");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Failed to connect to the database");

                        }

                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Failed to connect to the server");
                }
            }
            #endregion

            #region Additional tasks 3
            UserDB userDB = new UserDB(connection);
            List<User> users = new List<User>() { new User("Harison",17,"SOME country",true),
            new User("Pitter", 19, "SOME country", true),
            new User("Gretta", 15, "SOME country", true)};
            string tableUser = """
                CREATE TABLE [dbo].[User]
                (

                [Id] INT PRIMARY KEY IDENTITY NOT NULL,
                [Name] NVARCHAR (120) CHECK ([Name]<>'') NOT NULL,
                [Age] INT CHECK ([Age]>0) NOT NULL,
                [Country] NVARCHAR(50) CHECK ([Country]<>'') NOT NULL,
                [IsAdult] BIT Default 1 NOT NULL,

                );
                """;


            using (connection)
            {
                connection.Open();
                db.CreateAndUseDB(connection, "Users");
                db.CreateTable(connection, tableUser);

                //SqlCommand sqluse = new SqlCommand("USE Users", connection);
                //sqluse.ExecuteNonQuery();

                userDB.insertIntable(users);
                userDB.GetAllUsers(users);
                foreach (var item in users)
                {
                    Console.WriteLine($"Id :{item.Id} Age : {item.Age} IS : {item.IsAdult}");
                }
                Console.WriteLine($"-----------_Aster redaction_----------------");
                userDB.changeIsAdult();
                userDB.GetAllUsers(users);
                foreach (var item in users)
                {
                    Console.WriteLine($"Id :{item.Id} Age : {item.Age} IS : {item.IsAdult}");
                }

            }


            #endregion


        }
    }
}
