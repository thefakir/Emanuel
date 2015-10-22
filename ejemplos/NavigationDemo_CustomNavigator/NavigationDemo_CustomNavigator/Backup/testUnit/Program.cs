using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Reflection;
using System.IO;

namespace testUnit
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

            //Load remote assembly
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Assembly.LoadFile(path + @"\NavigationDemo.exe");

            Application.Run(new TestForm());
        }
    }
}
