using Dapper;
using EF_Core_dapper_HW_8.Web.Model;
using Microsoft.VisualBasic;
using System.Data;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EF_Core_dapper_HW_8.Web
{
    internal class ControlTask
    {
        private readonly IDbConnection _db;


        public void AddTask(MyTask task)
        {
            using (_db)
            {
                _db.Open();
                string insert = """
                    INSERT INTO Task ([Title],[Description],[DueDate],[IsCompleted])VALUES
                    (@title,@description,@dueDate,@isCompleted)
                    """;
                 _db.Query(insert,task);
                _db.Close();
            }
        }
        public void GetTask()
        {
            using (_db)
            {
                _db.Open();
                string select = """
                    SELECT [Id],[Title],[Description],[DueDate],[IsCompleted] 
                    FROM Task;
                    """;
                var test= _db.Query(select, new MyTask()).ToList();

                foreach (var item in test)
                {
                    Console.WriteLine(item);
                }
                _db.Close();
            }
        }
        public void DeleteTaskById(int idTask)
        {
            using (_db)
            {
                _db.Open();
                string delete = "DELETE FROM Task  WHERE Id = @TaskId;";

                if (_db.Execute(delete, new { TaskId = idTask }) > 0)
                {
                    Console.WriteLine("Success");
                }
                else { Console.WriteLine("Something wron"); }


                _db.Close();
            }
        }

        public void UpdateTaskById(MyTask newTask)
        {
            //[DueDate] = @newDate
            // newDate=newTask.DueDate,

            using (_db)
            {
                _db.Open();
                string update = "UPDATE Task SET [Title]=@newTitle,[Description]=@newDescription," +
                    "[DueDate] =@dueDate,[IsCompleted]=@newCompleted   WHERE Id = @TaskId;";

                if (_db.Execute(update, new { 
                    newTitle=newTask.Title, 
                    newDescription=newTask.Description, 
                    newCompleted=newTask.IsCompleted,
                    dueDate = newTask.DueDate, 
                    TaskId=newTask.Id}) > 0)
                {
                    Console.WriteLine("Success");
                }
                else { Console.WriteLine("Something wron"); }


                _db.Close();
            }
        }
            public  ControlTask(IDbConnection db)=>_db=db;
    }
}
