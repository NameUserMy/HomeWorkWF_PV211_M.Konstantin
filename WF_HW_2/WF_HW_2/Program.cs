using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_2
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
            //Application.Run(new Deposit());
            //Application.Run(new CountingLetters());
            //Application.Run(new EvenOdd());
            //Application.Run(new SaveText());
            Application.Run(new NotIdenticalLetters());


        }
    }
}
