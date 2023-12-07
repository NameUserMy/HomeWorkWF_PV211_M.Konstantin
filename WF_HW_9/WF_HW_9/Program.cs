using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_9
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*--------------------1-----------------------*/
             Application.Run(new Labirinte.Labirinte()); 
            /*--------------------------------------------*/
            /*--------------------2-----------------------*/
            // Application.Run(new Diagram.Diagram());
            /*-------------------------------------------*/
            
        }
    }
}
