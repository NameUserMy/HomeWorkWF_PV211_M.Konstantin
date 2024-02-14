using Dapper;
using EF_Core_dapper_HW_8.Web;
using EF_Core_dapper_HW_8.Web.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EF_Core_dapper_HW_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDbConnection db = new SqlConnection("Server=DESKTOP-B4N5F81;Database=Task;Trusted_Connection=True;TrustServerCertificate=True;");
            #region Task



            #region Create Table
            //string createTable = """
            //                        CREATE TABLE Task(
            //    [Id] int PRIMARY KEY IDENTITY,
            //    [Title] NVARCHAR(50) NOT NULL,
            //    [Description] NVARCHAR(150) NOT NULL,
            //    [DueDate] DATETIME,
            //    [IsCompleted] BIT DEFAULT 0 NOT NULL
            //    )

            //    """;

            //db.Execute(createTable);
            #endregion
            ControlTask task = new ControlTask(db);
                //task.AddTask(new MyTask
                //{
                //    Title = "First task",
                //    Description = "Super description",
                //    DueDate = DateTime.Now,
                //    IsCompleted = false
                //});

                //task.GetTask();
                //task.DeleteTaskById(1);
                //task.UpdateTaskById(new MyTask
                //{
                //    Title = "Update title",
                //    Description = "Update desc",
                //    DueDate = DateTime.Now,
                //    IsCompleted = true,
                //    Id = 1
                //});
            
            #endregion
        }
    }
}
