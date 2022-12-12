using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadSharp
{
    internal class AddShortcut
    {
        public static void AddShortcutfile()
        {
            try
            {
                object shDesktop = (object)"Desktop";
                WshShell shell = new WshShell();
                string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Notepad#.lnk";
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                shortcut.Description = "Notepad#";
                shortcut.TargetPath = System.Reflection.Assembly.GetEntryAssembly().Location;
                shortcut.IconLocation = System.Reflection.Assembly.GetEntryAssembly().Location.Replace("NotepadSharp.exe", "ic.ico");
                shortcut.WorkingDirectory = System.Reflection.Assembly.GetEntryAssembly().Location.Replace("NotepadSharp.exe", "");
                shortcut.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning!");
            }
        }
        public static void AddShortcuttoStart()
        {

            try
            {
            string commonStartMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
            string appStartMenuPath = Path.Combine(commonStartMenuPath, "Programs", "Notepad#");

            if (!Directory.Exists(appStartMenuPath))
                Directory.CreateDirectory(appStartMenuPath);

            string shortcutLocation = Path.Combine(appStartMenuPath, "Notepad#" + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "Notepad#";
            shortcut.IconLocation = System.Reflection.Assembly.GetEntryAssembly().Location.Replace("NotepadSharp.exe", "ic.ico");
            shortcut.WorkingDirectory = System.Reflection.Assembly.GetEntryAssembly().Location.Replace("NotepadSharp.exe", "");
            shortcut.TargetPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            shortcut.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("That didn't work, most like due to you not running the current session as administrator, Error: \n" + ex.ToString());
            }
        }
    }
}
