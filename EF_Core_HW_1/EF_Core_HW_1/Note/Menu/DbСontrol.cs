using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_1.Note.Menu
{
    internal class DbСontrol
    {
        private ContexDBNote _contexDB;
        public int AddUser(string nameUser)
        {
            User user  = new User { Name = nameUser};

            _contexDB.Add(user);
            _contexDB.SaveChanges();
            return user.Id;

        }
        public int IsUser(string userNmae)
        {

            var userId=_contexDB.User.FirstOrDefault(u=>u.Name== userNmae);
            if (userId is not null)
                return userId.Id;
            else
                return AddUser(userNmae);
           

        }
        public void GetTasks(int userId)
        {
            var tasks = _contexDB.Task.Where(t => t.UserId == userId);
            if(tasks is not null)
            {
                foreach (var item in tasks)
                {
                    Console.WriteLine($"Title : {item.Title}\nDescription : {item.Description}\n" +
                        $"Status : {item.Status}\nDate : {item.CreateDate}");
                }

            }

        }
        public void AddTask(Task add)
        {
            _contexDB.Add(new Task {
                Title=add.Title,
                Description=add.Description,
                UserId=add.UserId,
            
            });
            _contexDB.SaveChanges();

        }
        public DbСontrol(ContexDBNote? db) => _contexDB = db;
    }
}
