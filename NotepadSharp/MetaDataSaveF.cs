using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using DSOFile;
using static NotepadSharp.Form1;

namespace NotepadSharp
{
    public partial class MetaDataSaveF : Form
    {
        class maintext
        {
            public static RichTextBox textbox;
        }
        public MetaDataSaveF()
        {
            InitializeComponent();
        }
        public static void swm(RichTextBox MainTextField)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            maintext.textbox = tb;
            Form newthis = new MetaDataSaveF();
            newthis.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int passes = 0;
            TextBox[] alltxt = { txtFN, txtAuth, txtCreate, txtModif, txtLoc };
            foreach (var tb in alltxt)
            {
                if (tb.Text.Length != 0)
                {
                    passes++;
                }
            }
            if (txtFN.Text.EndsWith(".txt"))
            {
                txtFN.Text = txtFN.Text.Replace(".txt", "");
            }
            if (passes == 5)
            {
                string text = maintext.textbox.Text;
                string name = txtFN.Text;
                string auth = txtAuth.Text;
                string datecreate = txtCreate.Text;
                string datemodif = txtModif.Text;
                string location = txtLoc.Text;
                File.WriteAllText(name + ".txt", text);
                if (File.Exists(name + ".txt"))
                {
                    string newfilename = name + ".txt";
                    string location1 = System.Reflection.Assembly.GetEntryAssembly().Location;
                    location1 = location1.Replace("NotepadSharp.exe", newfilename);
                    OleDocumentProperties myFile = new DSOFile.OleDocumentProperties();
                    myFile.Open(location1, false, DSOFile.dsoFileOpenOptions.dsoOptionDefault);
                    object objName = name;
                    object objAuth = auth;
                    object objDatecreate = datecreate;
                    object objDatemodif = txtModif.Text;
                    object objLocation = txtLoc.Text;
                    foreach (DSOFile.CustomProperty property in myFile.CustomProperties)
                    {
                        if (property.Name == "Name")
                        {
                            //Property exists
                            //End the task here (return;) oder edit the property
                            property.set_Value(objName);
                        }
                    }
                    myFile.CustomProperties.Add("Name", ref objName);
                    foreach (DSOFile.CustomProperty property in myFile.CustomProperties)
                    {
                        if (property.Name == "Author")
                        {
                            //Property exists
                            //End the task here (return;) oder edit the property
                            property.set_Value(objAuth);
                        }
                    }
                    myFile.CustomProperties.Add("Author", ref objAuth);
                    foreach (DSOFile.CustomProperty property in myFile.CustomProperties)
                    {
                        if (property.Name == "Date Created")
                        {
                            //Property exists
                            //End the task here (return;) oder edit the property
                            property.set_Value(objDatecreate);
                        }
                    }
                    myFile.CustomProperties.Add("Date Created", ref objDatecreate);
                    foreach (DSOFile.CustomProperty property in myFile.CustomProperties)
                    {
                        if (property.Name == "Date Modified")
                        {
                            //Property exists
                            //End the task here (return;) oder edit the property
                            property.set_Value(objDatemodif);
                        }
                    }
                    myFile.CustomProperties.Add("Date Modified", ref objDatemodif);
                    foreach (DSOFile.CustomProperty property in myFile.CustomProperties)
                    {
                        if (property.Name == "Version")
                        {
                            //Property exists
                            //End the task here (return;) oder edit the property
                            property.set_Value(objLocation);
                        }
                    }
                    myFile.CustomProperties.Add("Version", ref objLocation);
                    myFile.Save();
                    myFile.Close(true);
                    string fileloc = Interaction.InputBox("Please enter the exact string of where the file has to go", "Pick location", "C:\\Users\\");
                    File.Move(newfilename, fileloc);
                    if (File.Exists(fileloc))
                    {
                        MessageBox.Show($"Saved file with properties {name}, {auth}, {datecreate}, {datemodif}, {location} to {fileloc}");
                        File.Delete(name + ".txt");
                        Hide();
                    }
                }
            }
        }
    }
}
