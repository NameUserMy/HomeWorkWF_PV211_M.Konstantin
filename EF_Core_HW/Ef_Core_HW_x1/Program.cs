using Ef_Core_HW_x1.data;
using Ef_Core_HW_x1.Model;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;

namespace Ef_Core_HW_x1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentContext ConnectDb() => new ApplicationsFactory().CreateDbContext();
            using (StudentContext db = ConnectDb())
            {

                #region add info
                //List<Student> disignStudents = new List<Student>
                //{
                //    new Student{Name="Lera",LName="Ivanova",DOB=DateOnly.Parse("2020,03,15")},
                //    new Student{Name="Martin",LName="Takolbary",DOB=DateOnly.Parse("2015,03,15")},
                //    new Student{Name="Julya",LName="Verna",DOB=DateOnly.Parse("2003,03,15")},
                //};
                //List<Student> ItStudents = new List<Student>
                //{
                //    new Student{Name="Petr",LName="Ivanov",DOB=DateOnly.Parse("2020,03,15")},
                //    new Student{Name="Helen",LName="Linkov",DOB=DateOnly.Parse("2015,03,15")},
                //    new Student{Name="Bob",LName="Martin",DOB=DateOnly.Parse("2003,03,15")},
                //};
                //List<Course> courses = new List<Course>
                //{
                //    new Course{ Title = "IT", Description = "Super",Students=ItStudents},
                //    new Course { Title = "Disign", Description = "Super", Students = disignStudents },
                //};


                //Instructor instructor = new Instructor { Name = "Instructor", LName = "Instructor", Courses = courses };

                //db.AddRange(instructor);
                //db.SaveChanges();

                //List<Student> ItStudents = new List<Student>
                //{
                //    new Student{Name="Entony",LName="Any",DOB=DateOnly.Parse("2020,03,15")},
                //    new Student{Name="Vasya",LName="Linkov",DOB=DateOnly.Parse("2015,03,15")},
                //    new Student{Name="John",LName="Martin",DOB=DateOnly.Parse("2003,03,15")},
                //};
                //List<Course> courses = new List<Course>
                //{
                //    new Course{ Title = "Programming", Description = "Super",Students=ItStudents},
                //};


                //Instructor instructor = new Instructor { Name = "Programming", LName = "Instructor", Courses = courses };

                //db.AddRange(instructor);
                //db.SaveChanges();



                //List<Student> ItStudents = new List<Student>
                //{
                //    new Student{Name="Entony",LName="Any",DOB=DateOnly.Parse("2020,03,15")},
                //    new Student{Name="Vasya",LName="Linkov",DOB=DateOnly.Parse("2015,03,15")},
                //    new Student{Name="John",LName="Martin",DOB=DateOnly.Parse("2003,03,15")},
                //    new Student{Name="Entony",LName="Any",DOB=DateOnly.Parse("2020,03,15")},
                //    new Student{Name="Vasya",LName="Linkov",DOB=DateOnly.Parse("2015,03,15")},
                //    new Student{Name="John",LName="Martin",DOB=DateOnly.Parse("2003,03,15")},
                //     new Student{Name="Lera",LName="Ivanova",DOB=DateOnly.Parse("2020,03,15")},
                //    new Student{Name="Martin",LName="Takolbary",DOB=DateOnly.Parse("2015,03,15")},
                //    new Student{Name="Julya",LName="Verna",DOB=DateOnly.Parse("2003,03,15")},
                //};
                //List<Course> courses = new List<Course>
                //{
                //    new Course{ Title = "SystemProgramming", Description = "Super",Students=ItStudents},
                //};


                //Instructor instructor = new Instructor { Name = "SystemProgramming", LName = "Instructor", Courses = courses };

                //db.AddRange(instructor);
                //db.SaveChanges();
                #endregion


                var stu = db.Students.Where(e => e.Courses.Any(e => e.Id == 3));
                var course = db.Courses.Where(e => e.Instructor.Id == 1);

                var course1 = db.Courses.Where(e => e.InstructorId == 1).Join(db.Enrollments, e => e.Id, e => e.CourseId, (c, s) => new
                {
                    TitleCourse = c.Title,
                    Studentsid = s,

                }).Join(db.Students, e => e.Studentsid.StudentId, e => e.Id, (s, c) => new
                {
                    CourseT = s.TitleCourse,
                    StudentName = c.Name,
                });

                var courseTitle = db.Courses.Include(e => e.Students).Where(e => e.Students.Count() > 8);

                var studentYearOld = db.Students.Where(e => EF.Functions.DateDiffYear(e.DOB, DateOnly.FromDateTime(DateTime.Now)) > 20);

                var studentAVGOld = db.Students.Average(e => EF.Functions.DateDiffYear(e.DOB, DateOnly.FromDateTime(DateTime.Now)));

                var countCourse = db.Students.Include(e => e.Courses).Where(e => e.Id == 1).Count();

                var nameStudent = db.Students.Select(e => e.Name);

                var studentOrderYear = db.Students.OrderBy(e => EF.Functions.DateDiffYear(e.DOB, DateOnly.FromDateTime(DateTime.Now)));

                var studentLname = db.Students.OrderBy(e => e.LName);

                var countCourseStudent = db.Students.Include(e => e.Courses).Where(e => e.Courses.Count() == 1);

                var countStudent = db.Courses.Include(e => e.Students).Select(e => e.Students.Count()).ToList();



            }
        }
    }
}
