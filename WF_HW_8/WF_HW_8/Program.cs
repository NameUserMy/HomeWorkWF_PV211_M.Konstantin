using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_HW_8.Line;

namespace WF_HW_8
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

            /*--------------1-------------*/
            Application.Run(new WaterMark());
            /*-----------------------------*/
           
            /*--------------3-------------*/
          //  Application.Run(new LinePaint());
            /*-----------------------------*/
            /*--------------4-------------*/
            //Application.Run(new RandomElips.RandomElips());
            /*-----------------------------*/
        }
    }
}
