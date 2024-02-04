using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW_3.WareHouse
{
    internal class Menu
    {
        private SqlConnection _connection;
        private string[] _menu;
        private int _choice=0;
        private ManagementWH management;
        private void RendertMenu()
        {
            

            for (int i = 0; i < _menu.Length; i++)
            {
                if (_choice == i)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else { Console.ForegroundColor = ConsoleColor.Green;}
                    
                Console.SetCursorPosition(50,1+i);
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
                        if(_choice!=0)
                        _choice--;
                break;
                case ConsoleKey.DownArrow:
                        if (_choice != _menu.Length-1)
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

        public void UseMenu(int some)
        {
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                switch (some)
                {
                    case 0:
                        Console.Clear();
                        management.GetAllProduct();
                        break;
                    case 1:
                        Console.Clear();
                        int id;
                        Console.WriteLine("Enter id product");
                        id =Convert.ToInt32( Console.ReadLine());
                        Console.Clear();
                        management.GetProduct(id);
                        break;
                    case 2:
                        Console.Clear();
                        management.GetAllContractor();
                        break;
                    case 3:
                        Console.Clear();
                        management.GetMaxCountProduct();
                        break;
                    case 4:
                        Console.Clear();
                        management.GetMinCountProduct();
                        break;
                    default:
                        return;
                }

            } while (Console.ReadKey().Key != ConsoleKey.Backspace);
            Console.Clear();

        }
        public Menu(SqlConnection connection)  {
            _connection = connection;

            _menu =   new string[] {"All products info", "Product ifo", "AllContractor", "MaxCountProduct", "MinCountProduct" };
            management = new ManagementWH(_connection);
        
        }
	
    }


}

