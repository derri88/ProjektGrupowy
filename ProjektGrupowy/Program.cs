using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjektGrupowy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static Start Start1;
        [STAThread]
        public static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Start1 = new Start();
            Application.Run(Start1);
        }
    }
}
