using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NintendoSharp.Constants;
using NintendoSharp.UI;

namespace NintendoSharp
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
            AppController.AppBegin();
            Application.Run(new FormMain());
        }
    }
}
