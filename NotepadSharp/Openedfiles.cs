using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NotepadSharp.Form1;

namespace NotepadSharp
{
    public partial class Openedfiles : Form
    {
        public object lb_item = null;
        public Openedfiles()
        {
            InitializeComponent();
            Task.Factory.StartNew(() => { checktheme(); });
        }
        void checktheme()
        {
            string themeLoad = File.ReadAllText("Theme.txt");
            if (themeLoad == "1")
            {
                lbFiles.BackColor = ColorTranslator.FromHtml("#212121");
                lbFiles.ForeColor = Color.White;
                BackColor = ColorTranslator.FromHtml("#212121");
                ForeColor = Color.White;
            }
            else
            {
                lbFiles.BackColor = Color.White;
                lbFiles.ForeColor = Color.Black;
            }
        }
        private void Openedfiles_Shown(object sender, EventArgs e)
        {
            CommonOpenFileDialog folderpicker = new CommonOpenFileDialog();
            folderpicker.InitialDirectory = "C:\\Users";
            folderpicker.IsFolderPicker = true;
            if (folderpicker.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Text = folderpicker.FileName;
                lbFiles.Items.Clear();
                string[] filesinfolder = Directory.GetFiles(folderpicker.FileName);
                foreach (var file in filesinfolder)
                {
                    lbFiles.Items.Add(file.ToString());
                }
                TopMost = true;
            }
            if (!File.Exists("Firsttimefolderpicker"))
            {
                File.Create("Firsttimefolderpicker");
                MessageBox.Show("Quick explainer of what this is, when you load a folder in our app, you get access to all the files in that folder, quicker, couple caviats, when you change files the file you were editing will be auto-saved, the files you access here will not go into your 'recents' tab, good luck!");
            }
        }

        private void lbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string textofselect = lbFiles.Items[lbFiles.SelectedIndex].ToString();
            Form1 f1 = (Form1)Application.OpenForms["Form1"];
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            f1.savefile();
            tb.Text = File.ReadAllText(textofselect);
            f1.Text = textofselect;
            currenttab.selectedtabpage.Text = f1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
