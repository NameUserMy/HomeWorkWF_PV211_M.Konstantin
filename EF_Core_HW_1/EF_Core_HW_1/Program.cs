namespace EF_Core_HW_1
{
    using EF_Core_HW_1.Note;
    using EF_Core_HW_1.Note.Menu;
    using EF_Core_HW_1.SQlite;
    using EF_Core_HW_1.StudentsGroup;
    using EF_Core_HW_1.Trains;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
  
    internal class Program
    {
        static void Main(string[] args)
        {
            ConectionServer conectionServer = new   ConectionServer();

            #region First task train
            using (ContextDB db = new ContextDB(conectionServer.GetConnectionServerSql()))
            {
                db.Add(new Train("name", "558-8856", 120, 230));
                db.AddRange(new Train("name", "558-8856", 120, 230), new Train("name 1", "658-8956", 70, 270),
                new Train("name 2", "2050-8856", 250, 100500));
                db.SaveChanges();

                var train = db.MyTrain.ToList();
                if (train is not null)
                {
                    foreach (var item in train)
                    {

                        Console.WriteLine($"Name {item.Name} Number {item.Number}");

                    }


                }
                db.Remove(train.FirstOrDefault(tr => tr.Id == 1));
                db.SaveChanges();
                var changeTrain = train.FirstOrDefault(tr => tr.speed == 100500);
                if (changeTrain is not null)
                {
                    changeTrain.speed = 150;
                    db.SaveChanges();

                }
            }
            #endregion

            #region Second task note
            using (ContexDBNote db = new ContexDBNote(conectionServer.GetConnectionServerSqlNote()))
            {
                DbСontrol dbСontrol = new DbСontrol(db);
                Menu menu = new Menu(dbСontrol);
                menu.checkUser();
                menu.choice();
            }
            #endregion

            #region Third task SQlite
            using (SQliteContext db = new SQliteContext(conectionServer.GetConnectionSQlite()))
            {

                db.Add(new First { Name = "blah" });
                db.Add(new Second { City = "City" });
                db.Add(new Third { Cord = 255.0 });
                db.SaveChanges();
                var f = db.First.ToList();
                foreach (var item in f)
                {
                    Console.WriteLine(item.Name);
                }


            }
            #endregion

            #region Fourth task 
            using (ContextGroup db = new ContextGroup(conectionServer.GetConnectionServerSqlGroup()))
            {
                ControlDB controlDB = new ControlDB(db);
                List<Student> students = new List<Student>() {
                new Student{Name="Olive"},
                new Student{Name="Kate"},
                new Student{Name="Jack"},
                new Student{Name="Bob"},
                new Student{Name="Mark"},
                new Student{Name="An"}
                };
                db.AddRange(students);

                List<StudentsGroup.Group> groups = new List<StudentsGroup.Group>() {
                new StudentsGroup.Group{Title="Internet technology"},
                new StudentsGroup.Group{Title="Programming"},
                new StudentsGroup.Group{Title="Any"},
                };
                db.AddRange(groups);

                List<StudentGroup> studentGroups = new List<StudentGroup>() {

                new StudentGroup { GroupId = 1, StudentId = 1 },
                new StudentGroup { GroupId = 1, StudentId = 2 },
                new StudentGroup { GroupId = 1, StudentId = 3 },
                new StudentGroup { GroupId = 2, StudentId = 4 },
                new StudentGroup { GroupId = 2, StudentId = 5 },
                new StudentGroup { GroupId = 3, StudentId = 6 },
                new StudentGroup { GroupId = 3, StudentId = 1 },

                };
                db.AddRange(studentGroups);
                db.SaveChanges();

                controlDB.GetGroupByStudent("Olive");
                controlDB.GetStudentByGroup("Any");

                controlDB.DeleteStudentById(4);
                controlDB.UpdateStudentById(new Student { Id = 5, Name = "Tanya" });
               
                


                






            }
            #endregion
        }
    }
}
