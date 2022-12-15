using Microsoft.Win32;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NotepadSharp.Form1;

namespace NotepadSharp
{
    // Handles all the scripts used on load
    internal class StartupScripts
    {

        // Gets the current user theme from the registry, can be light, dark, or custom
        // I robbed this off the internet so I'm not sure why this works, but it does ¯\_(ツ)_/¯
        public string GetTheme()
        {
            // Try catch voor zekerheid (Bijv. oudere versies van Windows, of Linux gebruikers idk lmao)
            try
            {
                string RegistryKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes";
                string theme;
                theme = (string)Registry.GetValue(RegistryKey, "CurrentTheme", string.Empty);
                theme = theme.Split('\\').Last().Split('.').First().ToString();
                return theme;
            }
            catch
            {
                return "Failed";
            }
        }
        public static void cursorpos(Scintilla MainTextField)
        {
            UserSettings settings = new UserSettings();
            if (settings.Cursorpos != 0)
            {
                MainTextField.SelectionStart = settings.Cursorpos;
            }
        }
        public static void firsttime(Scintilla MainTextField)
        {
            UserSettings settings = new UserSettings();
            if (settings.firstloadflag == "yes")
            {
                MessageBox.Show("Hello, welcome to your first time using Notepad#");
                settings.firstloadflag = "no";
            }
        }
        public static void zoomfactor(Scintilla MainTextField)
        {
            //UserSettings settings = new UserSettings();
            //if (settings.Zoomfactor != 0)
                //MainTextField.ZoomFactor = settings.Zoomfactor;
        }
        public static void loadprev(Scintilla MainTextField, Form Form1)
        {
            UserSettings settings = new UserSettings();
            if (Program.Args0.Argspub != null)
            {
                string loaded = File.ReadAllText(Program.Args0.Argspub);
                MainTextField.Text = loaded;
                Form1.Text = Program.Args0.Argspub;
            }
            else
            {
            try
            {
                string text = settings.Prevfile;
                string lastfile = File.ReadAllText(text);
                MainTextField.Text = lastfile;
                Form1.Text = text;
            }
            catch
            {
                if (settings.Prevfile.Length != 0) 
                    {
                        MessageBox.Show($"Couldn't show previous file.");
                    }
                }

            }
        }
        public void openwithargs(string[] args)
        {
            Form1 f1 = (Form1)Application.OpenForms["Form1"];
            RichTextBox tb = (RichTextBox)f1.Controls["MainTextField"];
            tb.Text = File.ReadAllText(args[0]);
            f1.Text = args[0];
        }
    }
}
