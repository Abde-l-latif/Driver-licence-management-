using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvldProject
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

            Form1 loginForm = new Form1();
            DialogResult result = loginForm.ShowDialog();

            if (result == DialogResult.OK)
            {

                Application.Run(new Form2());

            }
        }
    }
}
