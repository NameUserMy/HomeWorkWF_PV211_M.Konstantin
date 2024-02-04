namespace ADO.NET_HW_3
{
    using ADO.NET_HW_3.WareHouse;
    using Microsoft.Data.SqlClient;
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            DBManipulation dBManipulation = new DBManipulation();
            var connectionserver =dBManipulation.GetConnectionServer();
            #region additional task 1
            using (connectionserver)
            {
                connectionserver.Open();
                SqlCommand sqlCommand = new SqlCommand("USE Storage", connectionserver);
                sqlCommand.ExecuteNonQuery();
                Menu menu = new Menu(connectionserver);
                menu.choice();
                /* To-do-*/
                //managementWH.GetProductByCategory(1);
                //managementWH.GetProductByContractor(2);
                //managementWH.GetOldProduct();
                //managementWH.GetOAVGProduct();

            }
            #endregion
        }
    }
}



//    try
//    {
//        connectionserver.Open();

//        Console.WriteLine("Enter 1 for connect database");
//        answer = Convert.ToInt32(Console.ReadLine());
//        if (answer == 1)
//        {
//            try
//            {
//               SqlCommand sqlCommand = new SqlCommand("USE Storage", connectionserver);
//                sqlCommand.ExecuteNonQuery();
//                Console.WriteLine("Connect");
//            }
//            catch (Exception)
//            {
//                Console.WriteLine("Failed to connect to the database");

//            }

//        }
//    }
//    catch (Exception)
//    {

//        Console.WriteLine("Failed to connect to the server");
//    }