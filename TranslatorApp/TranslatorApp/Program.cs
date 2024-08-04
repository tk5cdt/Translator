using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TranslatorApp
{
    internal static class Program
    {
        public static frmMain mainForm = null;
        public static frmLogin loginForm = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new frmMain();
            Application.Run(mainForm);
            //Application.Run(new frmMain());
            //Application.Run(new frmLogin());
            //Application.Run(new frmSignup());
            //Application.Run(new frmTranslate());
            //Application.Run(new frmHistory(2));
            //Application.Run(new frmFavorite(4));


        }
    }
}
