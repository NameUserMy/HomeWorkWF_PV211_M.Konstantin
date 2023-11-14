using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_6
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
            /*-------------------1----------------------*/
             Application.Run(new Purchases());
            /*-------------------------------------------*/
            /*-------------------2----------------------*/
            //Application.Run(new MainText());
            /*--------------------------------------------*/

            /*--------------------3----------------------*/
            //Application.Run(new Millionaire());
            /*----------------------------------------*/
        }
    }
}
