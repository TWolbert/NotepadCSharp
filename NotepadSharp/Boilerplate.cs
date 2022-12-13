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
    public partial class Boilerplate : Form
    {
        public Boilerplate()
        {
            InitializeComponent();
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1 f1 = (Form1)Application.OpenForms["Form1"];
            RichTextBox tb = (RichTextBox)f1.Controls["MainTextField"];

            string textofselect = listBox1.Items[listBox1.SelectedIndex].ToString();

            if (Cb1.Checked)
            {
                switch (textofselect)
                {
                    case "HTML":
                        tb.Text = "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Notepad#</title>\r\n</head>\r\n<body>\r\n    \r\n</body>\r\n</html>";
                        break;

                    case "C#":
                        tb.Text = "using System;\r\nnamespace NotepadSharp\r\n{\r\n    internal class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            Console.WriteLine(\"Hello, Notepad# user\");\r\n        }\r\n    }\r\n}";
                        break;

                    case "Java":
                        tb.Text = "public class NotepadSharp {\r\n    System.out.println(\"Welcome Notepad# user!\");\r\n}";
                        break;


                }
            }

            else
            {
                switch (textofselect)
                {
                    case "HTML":
                        tb.Text += "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Notepad#</title>\r\n</head>\r\n<body>\r\n    \r\n</body>\r\n</html>";
                        break;

                    case "C#":
                        tb.Text += "using System;\r\nnamespace NotepadSharp\r\n{\r\n    internal class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            Console.WriteLine(\"Hello, Notepad# user\");\r\n        }\r\n    }\r\n}";
                        break;

                    case "Java":
                        tb.Text += "public class NotepadSharp {\r\n    System.out.println(\"Welcome Notepad# user!\");\r\n}";
                        break;


                }
            }

        }


        private void Cb1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
