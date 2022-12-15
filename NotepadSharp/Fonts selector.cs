using IWshRuntimeLibrary;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NotepadSharp.Form1;

namespace NotepadSharp
{
    public partial class Font_selector : Form
    {
        public Font_selector()
        {
            InitializeComponent();
        }
        List<string> fonts = new List<string>();
        private void Font_selector_Shown(object sender, EventArgs e)
        {
            using (InstalledFontCollection col = new InstalledFontCollection())
            {
 
                foreach (FontFamily fa in col.Families)
                {
                    fonts.Add(fa.Name.ToString());
                    listBox1.Items.Add(fa.Name.ToString()); 
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Temp out of use, will reimplement later.
            /*string textofselect = listBox1.Items[listBox1.SelectedIndex].ToString();

            Scintilla tb = (Scintilla)currenttab.selectedtabpage.Controls["MainTextField"];
            Form1 f1 = (Form1)Application.OpenForms["Form1"];
            tb.Styles[Style.Cpp.Default].Font = textofselect;*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (string str in fonts)
            {
                if (str.StartsWith(textBox1.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    listBox1.Items.Add(str);
                }
            }
        }
    }
}
