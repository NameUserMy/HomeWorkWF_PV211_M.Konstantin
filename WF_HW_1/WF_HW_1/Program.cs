using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_1
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

            /*======================_1_=============*/
            //Application.Run(new TimeFormat());
            /*-------------------------------------*/
            /*======================_2_=============*/
            //Application.Run(new AddUser());
            /*-------------------------------------*/
            /*======================_3_=============*/
            Application.Run(new Miner());
            /*-----------------------------------------*/
        }
    }
}
