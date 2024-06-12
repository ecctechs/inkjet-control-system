using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Deksomboon_Inkjet.Class;

namespace Deksomboon_Inkjet
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string programs = LocalStorage.GetPrograms();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (programs == "1")
            {
                Application.Run(new frmMain());
            }
            else if(programs == "2")
            {
                Application.Run(new frmPlan());
            }
        }
    }
}
