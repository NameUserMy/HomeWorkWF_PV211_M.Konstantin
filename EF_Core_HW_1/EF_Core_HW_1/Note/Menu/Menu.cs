using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_1.Note.Menu
{
    internal class Menu
    {
        private string[] _menu;
        private int _choice;
        private int _id;
        private DbСontrol _management;
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
        private void UseMenu(int some)
        {
            Console.ForegroundColor = ConsoleColor.White;
            do
            {

                
                switch (some)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Enter title");
                        string? title=Console.ReadLine();
                        Console.WriteLine("Enter description");
                        string? description=Console.ReadLine();
                        _management.AddTask(new Task{Title=title,Description=description,UserId=_id});
                        break;
                    case 1:
                        Console.Clear();
                        _management.GetTasks(_id);
                        break;
                    default:
                        return;
                }

            } while (Console.ReadKey().Key != ConsoleKey.Backspace);
            Console.Clear();

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
        public bool checkUser()
        {

            Console.SetCursorPosition(50,1);
            Console.WriteLine("Enter name");
            Console.SetCursorPosition(50, 3);
            string name= Console.ReadLine();
           
            if (_management.IsUser(name)!=0)
            {
                _id = _management.IsUser(name);
                Console.Clear();
                return true;

            }
            return false;
        }  
        public Menu(DbСontrol control)
        {
            _choice = 0;
            _menu = new string[] {"Add task", "Read task" };
            _management=control;


        }

    }






    

}

