﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_4
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
            /*------------------1-----------------*/
              Application.Run(new BestOil());
            /*------------------2-------------------*/
            //Application.Run(new QuantityMatches());
            /*--------------------------------------*/
            /*------------------3-------------------*/
            //Application.Run(new Pay());
            /*--------------------------------------*/
        }
    }
}
