﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TranslatorApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new frmLogin());
            //Application.Run(new frmSignup());
            Application.Run(new frmTranslate(4));
            //Application.Run(new frmHistory(4));
            //Application.Run(new frmFavorite(4));


        }
    }
}
