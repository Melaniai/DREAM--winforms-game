using System;
using System.Windows.Forms;

namespace Dream
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1()); // <-- Startar spelet i Form1
        }
    }
}
