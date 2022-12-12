using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NotepadSharp
{
    internal static class Program
    {
        public class Args0
        {
            public static string Argspub
            {
                get
                {
                    return argspriv;
                }
                set
                {
                    argspriv = value;
                }
            }
            private static string argspriv;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                Args0.Argspub = args[0];
            }
            Application.Run(new Form1());
        }
    }
}
