using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadSharp
{
    public partial class SpecialCharacters : Form
    {
        public SpecialCharacters()
        {
            InitializeComponent();
        }

        private void typechar(object sender, EventArgs e)
        {
            Control clicked = sender as Control;
            char typedchar = char.Parse(clicked.Text);
            Form1 f1 = (Form1)Application.OpenForms["Form1"];
            RichTextBox tb = (RichTextBox)f1.Controls["MainTextField"];
            var start = tb.SelectionStart; // use this if you want to keep cursor where it was
            start += 1;   // use this if want to move cursor to the end of pasted text
            tb.Text = tb.Text.Insert(tb.SelectionStart, typedchar.ToString());
            tb.SelectionStart = start;
            Hide();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void SpecialCharacters_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
