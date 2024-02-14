using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_2.Education.Menu
{
    internal class Menu
    {
        private string[] _menu;
        private int _choice = 0;
        private ManagementEducation _management;
        string _title, _description,_date;
        int _id,_count;
        bool _isProgress;
        private void RendertMenu()
        {


            for (int i = 0; i < _menu.Length; i++)
            {
                if (_choice == i)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else { Console.ForegroundColor = ConsoleColor.Green; }

                Console.SetCursorPosition(50, 1 + i);
                Console.WriteLine(_menu[i]);
            }


        }
        public void choice()
        {

            while (true)
            {

                RendertMenu();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if (_choice != 0)
                            _choice--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (_choice != _menu.Length - 1)
                            _choice++;
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.Enter:
                        UseMenu(_choice);
                        break;
                    default:
                        return;
                }
            }




        }

        private void UseMenu(int some)
        {
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                switch (some)
                {
                    case 0://Add course
                        Console.Clear();
                        Console.WriteLine("Enter title course");
                        _title = Console.ReadLine();
                        Console.WriteLine("Enter Description course");
                        _description = Console.ReadLine();
                        _management.AddCourse(new Course {Title=_title,Description=_description});
                        Console.Clear();
                        return;
                    case 1://add lecture
                        Console.Clear();
                        Console.WriteLine("Enter title Lecture");
                        _title = Console.ReadLine();
                        Console.WriteLine("Enter Description Lecture");
                        _description = Console.ReadLine();
                        Console.WriteLine("Enter Date yyyy-mm-dd");
                        _date = Console.ReadLine();
                        Console.WriteLine("Enter Course Id for add lecture");
                        _id = Convert.ToInt32(Console.ReadLine());
                        _management.AddLecture(new Lecture { Title = _title, Description = _description,
                        Date=DateTime.Parse(_date) ,course= _management.GetCoursById(_id)
                        });
                        Console.Clear();
                        return;
                    case 2://Add student
                        Console.Clear();
                        Console.WriteLine("Enter first name");
                        _title = Console.ReadLine();
                        Console.WriteLine("Enter lastst name");
                        _description = Console.ReadLine();
                        _management.AddStudent(new Student {FirstName=_title,LastName=_description});
                        Console.Clear();
                        return;
                    case 3://Add workshop
                        Console.Clear();
                        Console.WriteLine("Enter title workshop");
                        _title = Console.ReadLine();
                        Console.WriteLine("Enter Description workshop");
                        _description = Console.ReadLine();
                        Console.WriteLine("Enter Date yyyy-mm-dd");
                        _date = Console.ReadLine();
                        Console.WriteLine("Enter count participants");
                        _id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Course Id for add workshop");
                        _id = Convert.ToInt32(Console.ReadLine());
                        _management.AddWorkshop(new Workshop
                        {
                            Title = _title,
                            Description = _description,
                            MaxParticipants = _count,
                            Date = DateTime.Parse(_date),
                            course = _management.GetCoursById(_id)
                        });
                        Console.Clear();
                        return;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter Course Id ");
                        _id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter student Id ");
                        _count = Convert.ToInt32(Console.ReadLine());
                        _management.CourseRegistration(new CourseRegistration {CourseId= _id,StudentId= _count});
                        Console.Clear();
                        return;
                    case 5:// Add lecture progres
                        Console.Clear();
                        Console.WriteLine("Enter Course Id ");
                        _id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter student Id ");
                        _count = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Progress true , false");
                        _isProgress = Convert.ToBoolean(Console.ReadLine());
                        _management.AddLectureProgress(new LectureProgress { LectureId = _id, StudentId = _count,IsProgress=_isProgress });
                        Console.Clear();
                        return;
                    default:
                        return;
                }

            } while (Console.ReadKey().Key != ConsoleKey.Backspace);
            Console.Clear();

        }
        public Menu(ManagementEducation management)
        {
            _management = management;
            _menu = new string[] { "Add Course", "Add  Lecture", "Add sdudent", 
                "Add workshop", "CourseRegistration","AddLectureProgress"};
        }
    }
}
