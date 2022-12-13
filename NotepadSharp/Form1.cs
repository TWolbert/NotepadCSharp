using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel;
using System.Diagnostics;

namespace NotepadSharp
{
    public partial class Form1 : Form
    {
        UserSettings settings = new UserSettings();
        ToolStripMenuItem[] tsm;
        public Form1()
        {
            InitializeComponent();
            tsm = new ToolStripMenuItem[] { tsmR1, tsmR2, tsmR3, tsmR4, tsmR5 };
        }
        private void ImportKey_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        Task.Factory.StartNew(() => writefiletotb(fileContent));
                    }
                }
            }

            if (filePath.Length != 0)
            {
                this.Text = filePath;
                if (isPhoto())
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = @"C:\windows\system32\cmd.exe";
                    proc.Arguments = "/k" + this.Text;
                    proc.UseShellExecute = false;
                    proc.CreateNoWindow = true;
                    Process.Start(proc);
                    wait(200);
                    MainTextField.Text = "";
                    Text = "Untitled";
                }
                else
                {
                    if (!File.Exists("Recents.txt"))
                    {
                        File.WriteAllText("Recents.txt", filePath);
                    }
                    else
                    {
                        File.AppendAllText("Recents.txt", filePath + '\n');
                        int recLength = File.ReadLines("Recents.txt").Count();
                        if (recLength > 5)
                        {
                            var lines = File.ReadAllLines("Recents.txt");
                            File.WriteAllLines("Recents.txt", lines.Skip(1).ToArray());
                            var lines2 = File.ReadAllLines("Recents.txt");
                            for (int i = 0; i < tsm.Length; i++)
                            {
                                tsm[i].Text = lines2[i];
                            }
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("No file was imported.");
                this.Text = "Untitled";
            }
        }
        void writefiletotb(string fileContent)
        {
            MainTextField.Text = fileContent;
            Text = Text.Replace(" - Unsaved", "");
        }
        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // The form itself handles the file loading
            Form openedfolder = new Openedfiles();
            openedfolder.Show();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savefile();
        }
        public void changetextforfolder(string path)
        {
            edittextforfolder(path);
        }
        private void edittextforfolder(string path)
        {
            MessageBox.Show(path);
            MainTextField.Text = File.ReadAllText(path);
            this.Text = path;
            MessageBox.Show($"Vars {MainTextField.Text}, {Text}");
        }
        public void savefile()
        {
            if (this.Text.Length != 0 && this.Text.Contains("\\"))
            {
                this.Text = this.Text.Replace(" - Unsaved", "");
                bool possiblePath = this.Text.IndexOfAny(Path.GetInvalidPathChars()) == -1;
                if (possiblePath || this.Text.Contains("\\"))
                {
                    File.WriteAllText(this.Text, MainTextField.Text);
                }
                else
                {
                    Stream myStream;
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                    saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if ((myStream = saveFileDialog1.OpenFile()) != null)
                        {
                            myStream.Close();
                            File.WriteAllText(saveFileDialog1.FileName, MainTextField.Text);
                        }
                    }
                    this.Text = saveFileDialog1.FileName;
                }
            }
            else
            {
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        myStream.Close();
                        File.WriteAllText(saveFileDialog1.FileName, MainTextField.Text);
                    }
                }
                this.Text = saveFileDialog1.FileName;
            }
        }
        private void saveAsThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savefile();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    myStream.Close();
                    File.WriteAllText(saveFileDialog1.FileName, MainTextField.Text);
                }
            }
            this.Text = saveFileDialog1.FileName;
        }
        void changefontsize(int value)
        {
            MainTextField.Font = new Font("Arial", value, FontStyle.Regular);
        }
        private void pxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 16px
            changefontsize(16);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // 18px
            changefontsize(18);
        }

        private void pxToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // 20px
            changefontsize(20);
        }

        private void pxToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // 22px
            changefontsize(22);
        }

        private void pxToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // 24px
            changefontsize(24);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // 8px
            changefontsize(8);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                MainTextField.Text += clipboardText;
                MainTextField.SelectionStart = MainTextField.Text.Length;
                MainTextField.SelectionLength = 0;
            }
        }

        private void gotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findtextstring();
        }
        void findtextstring()
        {
            string search = Microsoft.VisualBasic.Interaction.InputBox("Please enter the string you are looking for.", "Find", "");
            int index = MainTextField.Text.IndexOf(search);
            MainTextField.SelectionStart = index + search.Length;
            MainTextField.Select(index, search.Length);
            MainTextField.SelectionBackColor = Color.Red;
            wait(2000);
            MainTextField.SelectionBackColor = MainTextField.BackColor;
            MainTextField.DeselectAll();
        }
        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        private void asPythonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = @"C:\windows\system32\cmd.exe";
            proc.Arguments = "/k py " + this.Text;
            Process.Start(proc);
        }

        private void timeAndDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            Clipboard.SetText(now.ToString());
            MainTextField.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfile = this.Text;
            File.Delete(sfile);
            MainTextField.Text = "";
            this.Text = "Untitled";
            MessageBox.Show("File removed!");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Text.Contains(" - Unsaved"))
            {
                Text = this.Text.Replace(" - Unsaved", "");
            }
            settings.Prevfile = this.Text;
            settings.Theme = themes.ToString();
            settings.Zoomfactor = MainTextField.ZoomFactor;
            settings.Cursorpos = MainTextField.SelectionStart;
            settings.firstloadflag = "no";
            settings.Save();
            File.WriteAllText("Recents.txt", "");
            foreach (var stripitem in tsm)
            {
                File.AppendAllText("Recents.txt", stripitem.Text + '\n');
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MainTextField.AllowDrop = true;
            MainTextField.DragDrop += MainTextField_DragDrop;
            StartupScripts.firsttime(MainTextField);
            // Init code 
            StartupScripts startupScripts = new StartupScripts();
            // Code for getting and setting the theme
            StartupScripts.zoomfactor(MainTextField);
            if (settings.Theme == "1" || settings.Theme == "2")
            {
                string themeLoad = settings.Theme;
                if (themeLoad == "1")
                {
                    darkToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    lightToolStripMenuItem_Click(sender, e);
                }
            }
            else
            {
                if (startupScripts.GetTheme() == "dark")
                {
                    darkToolStripMenuItem_Click(sender, e);
                }
                else if (startupScripts.GetTheme() == "light")
                {
                    lightToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    // Theme undetected, just ignore it
                }
            }
            // Code for reloading the previous closed file
            StartupScripts.loadprev(MainTextField, this);
            settings.Save();
            wait(1000);
            if (isPhoto())
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.FileName = @"C:\windows\system32\cmd.exe";
                proc.Arguments = "/k" + this.Text;
                proc.UseShellExecute = false;
                proc.CreateNoWindow = true;
                Process.Start(proc);
                MainTextField.Text = "";
                Text = "Untitled";
            }
            Refresh();
        }

        private void replaceInSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // New code written by evil twin and definitely not written by an AI
            string title = Text;
            string search = Interaction.InputBox("What words do you want to replace?", "Replace selection", "");
            string replace = Interaction.InputBox("What do you want to replace those with?", "Replace selection", "");
            MainTextField.SelectedText = MainTextField.SelectedText.Replace(search, replace);
            this.Text = title;
        }

        private void replaceAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = Text;
            string search = Microsoft.VisualBasic.Interaction.InputBox("What words do you want to replace?", "Replace all", "");
            string replace = Microsoft.VisualBasic.Interaction.InputBox("What do you want to replace those with?", "Replace all", "");
            MainTextField.Text = MainTextField.Text.Replace(search, replace);
            this.Text = title;
        }
        // Sets themes
        // 2 is light mode
        // 1 is dark mode
        int themes = 2;
        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTextField.BackColor = ColorTranslator.FromHtml("#212121");
            MainTextField.ForeColor = Color.White;
            panel1.BackColor = MainTextField.BackColor;
            panel1.ForeColor = MainTextField.BackColor;
            this.BackColor = Color.Black;
            MenuStrip.BackColor = Color.Black;
            MenuStrip.ForeColor = Color.White;
            lblLength.BackColor = ColorTranslator.FromHtml("#212121");
            lblLength.ForeColor = Color.White;
            lblWords.BackColor = lblLength.BackColor;
            lblWords.ForeColor = lblLength.ForeColor;
            lblZoom.BackColor = lblLength.BackColor;
            lblZoom.ForeColor = lblLength.ForeColor;
            lblPos.BackColor = lblLength.BackColor;
            lblPos.ForeColor = lblLength.ForeColor;

            themes = 1;
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTextField.BackColor = Color.White;
            MainTextField.ForeColor = Color.Black;
            panel1.BackColor = MainTextField.BackColor;
            panel1.ForeColor = MainTextField.BackColor;
            this.BackColor = Color.White;
            MenuStrip.BackColor = SystemColors.Control;
            MenuStrip.ForeColor = Color.Black;
            lblLength.BackColor = Color.White;
            lblLength.ForeColor = Color.Black;
            lblWords.BackColor = lblLength.BackColor;
            lblWords.ForeColor = lblLength.ForeColor;
            lblZoom.BackColor = lblLength.BackColor;
            lblZoom.ForeColor = lblLength.ForeColor;
            lblPos.BackColor = lblLength.BackColor;
            lblPos.ForeColor = lblLength.ForeColor;
            themes = 2;
        }

        private void asHTMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.Text);
        }

        private void MainTextField_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void wordwrapoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainTextField.WordWrap)
            {
                MainTextField.WordWrap = false;
                wordwrapoffToolStripMenuItem.Text = "Wordwrap (off)";
            }
            else
            {
                MainTextField.WordWrap = true;
                wordwrapoffToolStripMenuItem.Text = "Wordwrap (on)";
            }
        }
        private void alwaysOnTopoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!TopMost)
            {
                TopMost = true;
                alwaysOnTopoffToolStripMenuItem.Text = "Always on top (on)";
            }
            else
            {
                TopMost = false;
                alwaysOnTopoffToolStripMenuItem.Text = "Always on top (off)";
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //nvm
        }
        private void MainTextField_DragDrop(object sender, DragEventArgs e)
        {
            int i;
            String s;

            // Get start position to drop the text.  
            i = MainTextField.SelectionStart;
            s = MainTextField.Text.Substring(i);
            MainTextField.Text = MainTextField.Text.Substring(0, i);

            // Drop the text on to the RichTextBox.  
            MainTextField.Text += e.Data.GetData(DataFormats.Text).ToString();
            MainTextField.Text += s;
        }

        private void MainTextField_TextChanged_1(object sender, EventArgs e)
        {
            lblLength.Text = "Length: " + MainTextField.Text.Length.ToString();
            string[] textboxw = MainTextField.Text.Split(' ');
            lblWords.Text = "Words:" + textboxw.Length.ToString();
            if (!Text.Contains(" - Unsaved"))
                Text += " - Unsaved";
        }

        private void insertRegexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string inputs = Microsoft.VisualBasic.Interaction.InputBox("Please enter your desired regex string", "Regex", "");
            if (MainTextField.Text.Length > 10000)
            {
                MessageBox.Show("You are trying to perform Regex on a really big amount of text, please keep in mind that this will take a while", "Warning!");
            }
            Task.Factory.StartNew(() => { regexexecute(inputs); });

            // Test regex ^.(.*)$
        }
        private void regexexecute(string regexinput)
        {
            if (regexinput.Length != 0)
            {
                // Dit werkt maar t was niet leuk ngl
                string[] inpwords = MainTextField.Text.Split(' ');
                MainTextField.Text = "";
                foreach (var word in inpwords)
                {
                    string result = Regex.Replace(word, regexinput, "$1");
                    MainTextField.Text += result + " ";
                }
            }
        }

        private void Zoomfactorchange_Tick(object sender, EventArgs e)
        {
            lblZoom.Text = "Zoomfactor: " + MainTextField.ZoomFactor.ToString() + "x";
            if (Text.Contains(".py"))
            {
                asPythonToolStripMenuItem.Visible = true;
                asHTMLFileToolStripMenuItem.Visible = false;
            }
            else if (Text.Contains(".html"))
            {
                asPythonToolStripMenuItem.Visible = false;
                asHTMLFileToolStripMenuItem.Visible = true;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Text.Contains(" - Unsaved"))
            {
                DialogResult dialogResult = MessageBox.Show("You have unsaved changes, do you wish to save them and create a new file?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Text = Text.Replace(" - Unsaved", "");
                    if (!Text.StartsWith("Untitled"))
                    {
                        File.WriteAllText(Text, MainTextField.Text);
                    }
                    else
                    {
                        saveAsToolStripMenuItem_Click(sender, e);
                        Text = "Untitled";
                    }
                }
                else
                {
                    MainTextField.Text = "";
                    Text = "Untitled";
                }
            }
            else
            {
                MainTextField.Text = "";
                Text = "Untitled";
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Text.Contains(" - Unsaved"))
            {
                DialogResult dialogResult = MessageBox.Show("You have unsaved changes, do you wish to save and exit?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Text = Text.Replace(" - Unsaved", "");
                    File.WriteAllText(Text, MainTextField.Text);
                    Environment.Exit(0);
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            StartupScripts.cursorpos(MainTextField);
            var labels = this.Controls.OfType<Label>()
                          .Where(c => c.Name.StartsWith("lbl"))
                          .ToList();
            foreach (var label in labels)
            {
                label.Font = new Font("Arial", label.Font.Size, FontStyle.Regular);
            }
            if (File.Exists("Recents.txt"))
            {
                var lines = File.ReadAllLines("Recents.txt");
                for (int i = 0; i < tsm.Length; i++)
                {
                    tsm[i].Text = lines[i];
                }
            }
        }

        private void MainTextField_SelectionChanged(object sender, EventArgs e)
        {
            if (MainTextField.SelectionStart == MainTextField.SelectionStart + MainTextField.SelectionLength)
            {
                lblPos.Text = "Pos: " + MainTextField.SelectionStart.ToString();
            }
            else
            {
                int end = MainTextField.SelectionStart + MainTextField.SelectionLength;
                string sEnd = end.ToString();
                lblPos.Text = "Pos: " + MainTextField.SelectionStart.ToString() + " | " + sEnd;
            }
        }
        private void openrecentfile(object sender, EventArgs e)
        {
            if (Text.Contains(" - Unsaved"))
            {
                DialogResult dialogResult = MessageBox.Show("You have unsaved changes, do you wish to save and open a new file?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Text = Text.Replace(" - Unsaved", "");
                    savefile();
                }
            }
            string s = (sender as ToolStripMenuItem).Text;
            MainTextField.Text = File.ReadAllText(s);
            Text = s;
            File.AppendAllText("Recents.txt", Text + '\n');
            int recLength = File.ReadLines("Recents.txt").Count();
            if (recLength > 5)
            {
                var lines = File.ReadAllLines("Recents.txt");
                File.WriteAllLines("Recents.txt", lines.Skip(1).ToArray());
                var lines2 = File.ReadAllLines("Recents.txt");
                for (int i = 0; i < tsm.Length; i++)
                {
                    tsm[i].Text = lines2[i];
                }
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTextField.SelectAll();
        }

        private void MenuStrip_BackColorChanged(object sender, EventArgs e)
        {
            foreach (var stripitem in Controls.OfType<ToolStripMenuItem>())
            {
                stripitem.BackColor = MenuStrip.BackColor;
                stripitem.ForeColor = MainTextField.ForeColor;
            }
        }

        private void saveWithMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MetaDataSaveF.swm(MainTextField);
        }

        private void reloadAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTextField.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTextField.Redo();
        }

        private void addToStartMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddShortcut.AddShortcutfile();
        }

        private void addShortcutToStartMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddShortcut.AddShortcuttoStart();
        }
        private bool isPhoto()
        {
            if (Text.EndsWith(".png") || Text.EndsWith(".jpg") || Text.EndsWith(".jpeg") || Text.EndsWith(".webp"))
            {
                return true;
            }
            return false;
        }

        private void specialCharactersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpecialCharacters sc = new SpecialCharacters();
            sc.TopMost = true;
            sc.Show();
        }
    }
}   
