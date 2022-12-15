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
using System.Text;

namespace NotepadSharp
{
    public partial class Form1 : Form
    {
        public class currenttab
        {
            public static TabPage selectedtabpage = new TabPage();
        }
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
            var backcolor = MainTextField.BackColor;
            var forecolor = MainTextField.ForeColor;
            TabPage tp = new TabPage();
            RichTextBox rtb = new RichTextBox();
            tabControl1.TabPages.Add(tp);
            tp.Controls.Add(rtb);
            rtb.Name = "MainTextField";
            rtb.BorderStyle = BorderStyle.None;
            rtb.Dock = DockStyle.Fill;
            rtb.AllowDrop = true;
            rtb.BackColor = backcolor; rtb.ForeColor = forecolor;
            rtb.TextChanged += MainTextField_TextChanged_1;
            rtb.DragDrop += MainTextField_DragDrop;
            rtb.SelectionChanged += MainTextField_SelectionChanged;
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tp);
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
                        Task.Factory.StartNew(() => writefiletotb(fileContent, rtb, tp));
                    }
                }
            }
            if (filePath.Length != 0)
            {
                this.Text = filePath;
                tp.Text = filePath;
                if (Text.Contains(".py"))
                {
                    rtb.TextChanged += syntaxhighlightpy;
                }
                if (Text.Contains(".c"))
                {
                    if (!Text.Contains(".cpp"))
                    {
                        if (!Text.Contains(".cs"))
                        {
                            rtb.TextChanged += syntaxhighlightc;
                        }
                    }

                }
                if (Text.Contains(".cs"))
                {
                    rtb.TextChanged += syntaxhighlightcs;
                }
                if (Text.Contains(".html"))
                {
                    rtb.TextChanged += syntaxhighlightHTML;
                }
                if (Text.Contains(".cpp"))
                {
                    rtb.TextChanged += syntaxhighlightcpp;
                }
                if (Text.Contains(".js"))
                {
                    rtb.TextChanged += syntaxhighlightjs;
                }
                if (Text.Contains(".asm"))
                {
                    rtb.TextChanged += syntaxhighlightasm;
                }
                if (isPhoto())
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = @"C:\windows\system32\cmd.exe";
                    proc.Arguments = "/k" + this.Text;
                    proc.UseShellExecute = false;
                    proc.CreateNoWindow = true;
                    Process.Start(proc);
                    wait(200);
                    rtb.Text = "";
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
            if (tabControl1.TabCount <= 2 && tabControl1.TabPages[0].Text.Contains("Untitled"))
            {
                tabControl1.TabPages.RemoveAt(0);
            }
        }
        void syntaxhighlightasm(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            // getting keywords/functions
            string keywords = @"\b(lds|les|lfs|lgs|lss|pop|push|in|ins|out|outs|lahf|sahf|popf|pushf|cmc|clc|stc|cli|sti|cld|std|add|adc|sub|sbb|cmp|inc|dec|test|sal|shl|sar|shr|shld|shrd|not|neg|bound|and|or|xor|imul|mul|div|idiv|cbtw|cwtl|cwtd|cltd|daa|das|aaa|aas|aam|aad|wait|fwait|movs|cmps|stos|lods|scas|xlat|rep|repnz|repz|lcall|call|ret|lret|enter|leave|jcxz|loop|loopnz|loopz|jmp|ljmp|int|into|iret|sldt|str|lldt|ltr|verr|verw|sgdt|sidt|lgdt|lidt|smsw|lmsw|lar|lsl|clts|arpl|bsf|bsr|bt|btc|btr|bts|cmpxchg|fsin|fcos|fsincos|fld|fldcw|fldenv|fprem|fucom|fucomp|fucompp|lea|mov|movw|movsx|movzb|popa|pusha|rcl|rcr|rol|ror|setcc|bswap|xadd|xchg|wbinvd|invd|invlpg|lock|nop|hlt|fld|fst|fstp|fxch|fild|fist|fistp|fbld|fbstp|fadd|faddp|fiadd|fsub|fsubp|fsubr|fsubrp|fisubrp|fisubr|fmul|fmulp|fimul|fdiv|fdivp|fdivr|fdivrp|fidiv|fidivr|fsqrt|fscale|fprem|frndint|fxtract|fabs|fchs|fcom|fcomp|fcompp|ficom|ficomp|fyl2x|fyl2xp1|fldl2e|fldl2t|fldlg2|fldln2|fldpi|fldz|finit|fnint|fnop|fsave|fnsave|fstew|fnstew|fstenv|fnstenv|fstsw|fnstsw|frstor|fwait|wait|fclex|fnclex|fdecstp|ffree|fincstp)\b";
            MatchCollection keywordMatches = Regex.Matches(tb.Text, keywords);

            // getting types/classes from the text 
            string types = @"\b(Suffering)\b";
            MatchCollection typeMatches = Regex.Matches(tb.Text, types);

            // getting comments (inline or multiline)
            string comments = @"(\/\/.+?$|\/\*.+?\*\/)";
            MatchCollection commentMatches = Regex.Matches(tb.Text, comments, RegexOptions.Multiline);
            
            // getting strings
            string strings = "\".+?\"";
            MatchCollection stringMatches = Regex.Matches(tb.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = tb.SelectionStart;
            int originalLength = tb.SelectionLength;
            Color originalColor = Color.Empty;


            // MANDATORY - focuses a label before highlighting (avoids blinking)
            MenuStrip.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            tb.SelectionStart = 0;
            tb.SelectionLength = tb.Text.Length;
            tb.SelectionColor = originalColor;

            // scanning...
            foreach (Match m in keywordMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Blue;
            }

            foreach (Match m in typeMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in commentMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Brown;
            }

            // restoring the original colors, for further writing
            tb.SelectionStart = originalIndex;
            tb.SelectionLength = originalLength;
            tb.SelectionColor = originalColor;

            // giving back the focus
            tb.Focus();
        }
        void syntaxhighlightc(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            // getting keywords/functions
            string keywords = @"\b(exit|fptr|fopen|fprintf|printf|scanf|fclose|auto|break|case|char|const|continue|default|do|double|else|enum|extern|float|for|goto|if|int|long|register|return|short|signed|sizeof|static|struct|switch|typedef|union|unsigned|void|volatile|while)\b";
            MatchCollection keywordMatches = Regex.Matches(tb.Text, keywords);

            // getting types/classes from the text 
            string types = @"\b(main|include|NULL)\b";
            MatchCollection typeMatches = Regex.Matches(tb.Text, types);

            // getting comments (inline or multiline)
            string comments = @"(\/\/.+?$|\/\*.+?\*\/)";
            MatchCollection commentMatches = Regex.Matches(tb.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            MatchCollection stringMatches = Regex.Matches(tb.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = tb.SelectionStart;
            int originalLength = tb.SelectionLength;
            Color originalColor = Color.Empty;


            // MANDATORY - focuses a label before highlighting (avoids blinking)
            MenuStrip.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            tb.SelectionStart = 0;
            tb.SelectionLength = tb.Text.Length;
            tb.SelectionColor = originalColor;

            // scanning...
            foreach (Match m in keywordMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Blue;
            }

            foreach (Match m in typeMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in commentMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Brown;
            }

            // restoring the original colors, for further writing
            tb.SelectionStart = originalIndex;
            tb.SelectionLength = originalLength;
            tb.SelectionColor = originalColor;

            // giving back the focus
            tb.Focus();
        }
        void syntaxhighlightcs(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            // getting keywords/functions
            string keywords = @"\b(public|private|partial|static|class|using|void|foreach|in|abstract|as|base|bool|break|byte|case|catch|char|checked|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|goto|if|implicit|in|int|interface|internal|is|lock|long|new|null|object|operator|out|override|params|protected|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while)\b";
            MatchCollection keywordMatches = Regex.Matches(tb.Text, keywords);

            string subtypes = @"\b(ReadLine|WriteLine|Write|ReadKey|Beep|Clear|Equals|MoveBufferArea|OpenStandardError|OpenStandardInput|OpenStandardOutput|Read|ReferenceEquals|ResetColor|SetBufferSize|SetCursorPosistion|SetError|SetIn|SetOut|SetWindowPosition|SetWindowSize)\b";
            MatchCollection subtypematches = Regex.Matches(tb.Text, subtypes);

            // getting types/classes from the text 
            string types = @"\b(Console|Form|namespace|Main)\b";
            MatchCollection typeMatches = Regex.Matches(tb.Text, types);

            // getting comments (inline or multiline)
            string comments = @"(\/\/.+?$|\/\*.+?\*\/)";
            MatchCollection commentMatches = Regex.Matches(tb.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            MatchCollection stringMatches = Regex.Matches(tb.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = tb.SelectionStart;
            int originalLength = tb.SelectionLength;
            Color originalColor = Color.Empty;
            // MANDATORY - focuses a label before highlighting (avoids blinking)
            MenuStrip.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            tb.SelectionStart = 0;
            tb.SelectionLength = tb.Text.Length;
            tb.SelectionColor = originalColor;

            // scanning...
            foreach (Match m in keywordMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Blue;
            }

            foreach (Match m in subtypematches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = ColorTranslator.FromHtml("#A6E22E");
            }

            foreach (Match m in typeMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = ColorTranslator.FromHtml("#66D9EF");
            }
            foreach (Match m in commentMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = ColorTranslator.FromHtml("#E6DB74");
            }

            // restoring the original colors, for further writing
            tb.SelectionStart = originalIndex;
            tb.SelectionLength = originalLength;
            tb.SelectionColor = originalColor;

            // giving back the focus
            tb.Focus();
        }
        void syntaxhighlightHTML(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            // getting keywords/functions
            string keywords = @"\b(!--|!DOCTYPE|a|abbr|acronym|address|applet|area|article|aside|audio|b|base|basefont|bdi|bdo|big|blockquote|body|br|button|canvas|caption|center|cite|code|col|colgroup|data|datalist|dd|del|details|dfn|dialog|dir|div|dl|dt|em|embed|fieldset|figcaption|figure|font|footer|form|frame|frameset|h1|h2|h3|h4|h5|h6|head|header|hr|html|i|iframe|img|input|ins|kbd|label|legend|li|link|main|map|mark|meta|meter|nav|noframes|noscript|object|ol|optgroup|option|output|p|param|picture|pre|progress|q|rp|rt|ruby|s|samp|script|section|select|small|source|span|strike|strong|style|sub|summary|sup|svg|table|tbody|td|template|textarea|tfoot|th|thead|time|title|tr|track|tt|u|ul|var|video|wbr|/a|/abbr|/acronym|/address|/applet|/area|/article|/aside|/audio|/b|/base|/basefont|/bdi|/bdo|/big|/blockquote|/body|/br|/button|/canvas|/caption|/center|/cite|/code|/col|/colgroup|/data|/datalist|/dd|/del|/details|/dfn|/dialog|/dir|/div|/dl|/dt|/em|/embed|/fieldset|/figcaption|/figure|/font|/footer|/form|/frame|/frameset|/h1|/h2|/h3|/h4|/h5|/h6|/head|/header|/hr|/html|/i|/iframe|/img|/input|/ins|/kbd|/label|/legend|/li|/link|/main|/map|/mark|/meta|/meter|/nav|/noframes|/noscript|/object|/ol|/optgroup|/option|/output|/p|/param|/picture|/pre|/progress|/q|/rp|/rt|/ruby|/s|/samp|/script|/section|/select|/small|/source|/span|/strike|/strong|/style|/sub|/summary|/sup|/svg|/table|/tbody|/td|/template|/textarea|/tfoot|/th|/thead|/time|/title|/tr|/track|/tt|/u|/ul|/var|/video|/wbr)\b";
            MatchCollection keywordMatches = Regex.Matches(tb.Text, keywords);

            // getting types/classes from the text 
            string types = @"\b(ugWEFIUGWEGFTUHUEWSRGUETRYEUTuitf)\b";
            MatchCollection typeMatches = Regex.Matches(tb.Text, types);

            // getting comments (inline or multiline)
            string comments = @"\b(hfjhlkuydsdfkljyt)\b";
            MatchCollection commentMatches = Regex.Matches(tb.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = @"\b(kuyguyrgKYUtfuy)\b";
            MatchCollection stringMatches = Regex.Matches(tb.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = tb.SelectionStart;
            int originalLength = tb.SelectionLength;
            Color originalColor = Color.Empty;


            // MANDATORY - focuses a label before highlighting (avoids blinking)
            MenuStrip.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            tb.SelectionStart = 0;
            tb.SelectionLength = tb.Text.Length;
            tb.SelectionColor = originalColor;

            // scanning...
            foreach (Match m in keywordMatches)
            {
                tb.SelectionStart = m.Index - 1;
                tb.SelectionLength = m.Length + 1;
                tb.SelectionColor = Color.Blue;
            }

            foreach (Match m in typeMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in commentMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Brown;
            }

            // restoring the original colors, for further writing
            tb.SelectionStart = originalIndex;
            tb.SelectionLength = originalLength;
            tb.SelectionColor = originalColor;

            // giving back the focus
            tb.Focus();
        }
        void syntaxhighlightpy(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            // getting keywords/functions
            string keywords = @"\b(print|input|and|as|assert|break|class|continue|def|del|except|False|finally|for|from|global|in|is|lambda|None|nonlocal|not|or|pass|raise|return|True|try|while|with|yield)\b";
            MatchCollection keywordMatches = Regex.Matches(tb.Text, keywords);

            // getting types/classes from the text 
            string types = @"\b(if|elif|else|import)\b";
            MatchCollection typeMatches = Regex.Matches(tb.Text, types);

            // getting comments (inline or multiline)
            string comments = @"(\/\/.+?$|\/\*.+?\*\/)";
            MatchCollection commentMatches = Regex.Matches(tb.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            MatchCollection stringMatches = Regex.Matches(tb.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = tb.SelectionStart;
            int originalLength = tb.SelectionLength;
            Color originalColor = Color.Empty;


            // MANDATORY - focuses a label before highlighting (avoids blinking)
            MenuStrip.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            tb.SelectionStart = 0;
            tb.SelectionLength = tb.Text.Length;
            tb.SelectionColor = originalColor;

            // scanning...
            foreach (Match m in keywordMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Blue;
            }

            foreach (Match m in typeMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in commentMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Brown;
            }

            // restoring the original colors, for further writing
            tb.SelectionStart = originalIndex;
            tb.SelectionLength = originalLength;
            tb.SelectionColor = originalColor;

            // giving back the focus
            tb.Focus();
        }
        void syntaxhighlightjs(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            // getting keywords/functions
            string keywords = @"\b(abstract|arguments|await|boolean|break|byte|case|catch|char|class|const|continue|debugger|default|delete|do|double|else|enum|eval|export|extends|false|final|finally|float|for|function|goto|if|implements|import|in|instanceof|int|interface|let|long|native|new|null|package|private|protected|public|return|short|static|super|switch|synchronized|this|throw|throws|transient|true|try|typeof|var|void|volatile|while|with|yield)\b";
            MatchCollection keywordMatches = Regex.Matches(tb.Text, keywords);

            // getting types/classes from the text 
            string types = @"\b(document|body|sessionStorage|localStorage|console|innerHTML|style|outerHTML|toString|Object|window|function|parseInt|Math)\b";
            MatchCollection typeMatches = Regex.Matches(tb.Text, types);

            //Getting type vals for js
            string var = @"\b(var|let|const)\b";
            MatchCollection varMatches = Regex.Matches(tb.Text, var);

            string subkeys = @"\b(setItem|getItem|removeItem|keys|onload|length|getElementById|replace|random|round|log|remove)\b";
            MatchCollection subKeysMatches = Regex.Matches(tb.Text, subkeys);

            // getting comments (inline or multiline)
            string comments = @"(\/\/.+?$|\/\*.+?\*\/)";
            MatchCollection commentMatches = Regex.Matches(tb.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            MatchCollection stringMatches = Regex.Matches(tb.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = tb.SelectionStart;
            int originalLength = tb.SelectionLength;
            Color originalColor = Color.Empty;


            // MANDATORY - focuses a label before highlighting (avoids blinking)
            MenuStrip.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            tb.SelectionStart = 0;
            tb.SelectionLength = tb.Text.Length;
            tb.SelectionColor = originalColor;

            // scanning...
            foreach (Match m in keywordMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Blue;
            }

            foreach (Match m in typeMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in varMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.DarkRed;
            }

            foreach (Match m in commentMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Green;
            }

            foreach (Match m in subKeysMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.DarkSlateBlue;
            }

            foreach (Match m in stringMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Brown;
            }

            // restoring the original colors, for further writing
            tb.SelectionStart = originalIndex;
            tb.SelectionLength = originalLength;
            tb.SelectionColor = originalColor;

            // giving back the focus
            tb.Focus();
        }
        void syntaxhighlightcpp(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            // getting keywords/functions
            string keywords = @"\b(alignas|alignof|and|and_eq|asm|atomic_cancel|atomic_commit|atomic_noexcept|auto|bitand|bool|break|case|catch|char|char8_t|char16_t|char32_t|class|compl|concept|const|consteval|constexpr|constinit|const_cast|continue|co_await|co_return|co_yield|decltype|default|delete|do|double|dynamic_cast|else|enum|explicit|export|extern|false|float|for|friend|goto|if|inline|int|long|mutable|namespace|new|noexcept|not|not_eq|nullptr|operator|or|or_eq|private|protected|public|reflexpr|register|reinterpret_cast|requires|return|short|signed|sizeof|static|static_assert|static_cast|struct|switch|synchronized|template|this|thread_local|throw|true|try|typedef|typeid|typename|union|unsigned|using||virtual|void|volatile|wchar_t|while|xor|xor_eq)\b";
            MatchCollection keywordMatches = Regex.Matches(tb.Text, keywords);

            // getting types/classes from the text 
            string types = @"\b(cout|std::|cin|include)\b";
            MatchCollection typeMatches = Regex.Matches(tb.Text, types);

            // getting comments (inline or multiline)
            string comments = @"(\/\/.+?$|\/\*.+?\*\/)";
            MatchCollection commentMatches = Regex.Matches(tb.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            MatchCollection stringMatches = Regex.Matches(tb.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = tb.SelectionStart;
            int originalLength = tb.SelectionLength;
            Color originalColor = Color.Empty;


            // MANDATORY - focuses a label before highlighting (avoids blinking)
            MenuStrip.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            tb.SelectionStart = 0;
            tb.SelectionLength = tb.Text.Length;
            tb.SelectionColor = originalColor;

            // scanning...
            foreach (Match m in keywordMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Blue;
            }

            foreach (Match m in typeMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in commentMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                tb.SelectionStart = m.Index;
                tb.SelectionLength = m.Length;
                tb.SelectionColor = Color.Brown;
            }

            // restoring the original colors, for further writing
            tb.SelectionStart = originalIndex;
            tb.SelectionLength = originalLength;
            tb.SelectionColor = originalColor;

            // giving back the focus
            tb.Focus();
        }
        void writefiletotb(string fileContent, RichTextBox rtb, TabPage tb)
        {
            rtb.Text = fileContent;
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
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            MessageBox.Show(path);
            tb.Text = File.ReadAllText(path);
            this.Text = path;
            MessageBox.Show($"Vars {tb.Text}, {Text}");
        }
        private static void saveEncoded(Encoding encoding, string filename)
        {
            Form1 f1 = (Form1)Application.OpenForms["Form1"];
            RichTextBox tb = (RichTextBox)f1.Controls["MainTextField"];
            StreamWriter streamWriter = new StreamWriter(filename, false, encoding);
            streamWriter.WriteLine(tb.Text);
            streamWriter.Close();
            f1.Text = filename;
        }
        public void savefile()
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            if (this.Text.Length != 0 && this.Text.Contains("\\"))
            {
                this.Text = this.Text.Replace(" - Unsaved", "");
                bool possiblePath = this.Text.IndexOfAny(Path.GetInvalidPathChars()) == -1;
                if (possiblePath || this.Text.Contains("\\"))
                {
                    File.WriteAllText(this.Text, tb.Text);
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
                            File.WriteAllText(saveFileDialog1.FileName, tb.Text);
                        }
                    }
                    this.Text = saveFileDialog1.FileName;
                    currenttab.selectedtabpage.Text = Text;
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
                        File.WriteAllText(saveFileDialog1.FileName, tb.Text);
                    }
                }
                this.Text = saveFileDialog1.FileName;
                currenttab.selectedtabpage.Text = Text;
            }
        }
        private void saveAsThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savefile();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
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
                    File.WriteAllText(saveFileDialog1.FileName, tb.Text);
                }
            }
            this.Text = saveFileDialog1.FileName;
            currenttab.selectedtabpage.Text = Text;
        }
        void changefontsize(int value)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            tb.Font = new Font("Arial", value, FontStyle.Regular);
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
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                tb.Text += clipboardText;
                tb.SelectionStart = tb.Text.Length;
                tb.SelectionLength = 0;
            }
        }

        private void gotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findtextstring();
        }
        void findtextstring()
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            string search = Microsoft.VisualBasic.Interaction.InputBox("Please enter the string you are looking for.", "Find", "");
            int index = tb.Text.IndexOf(search);
            tb.SelectionStart = index + search.Length;
            tb.Select(index, search.Length);
            tb.SelectionBackColor = Color.Red;
            wait(2000);
            tb.SelectionBackColor = tb.BackColor;
            tb.DeselectAll();
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
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            DateTime now = DateTime.Now;
            Clipboard.SetText(now.ToString());
            tb.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            var sfile = this.Text;
            File.Delete(sfile);
            tb.Text = "";
            this.Text = "Untitled";
            MessageBox.Show("File removed!");
            removeCurrentTabToolStripMenuItem_Click(sender, e);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            if (this.Text.Contains(" - Unsaved"))
            {
                Text = this.Text.Replace(" - Unsaved", "");
            }
            settings.Prevfile = this.Text;
            settings.Theme = themes.ToString();
            settings.Zoomfactor = tb.ZoomFactor;
            settings.Cursorpos = tb.SelectionStart;
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
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            currenttab.selectedtabpage = tabControl1.SelectedTab;
            // Init code 
            StartupScripts startupScripts = new StartupScripts();
            // Code for getting and setting the theme
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
                tb.Text = "";
                Text = "Untitled";
            }
            Refresh();
        }

        private void replaceInSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            // New code written by evil twin and definitely not written by an AI
            string title = Text;
            string search = Interaction.InputBox("What words do you want to replace?", "Replace selection", "");
            string replace = Interaction.InputBox("What do you want to replace those with?", "Replace selection", "");
            tb.SelectedText = tb.SelectedText.Replace(search, replace);
            this.Text = title;
        }

        private void replaceAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            string title = Text;
            string search = Microsoft.VisualBasic.Interaction.InputBox("What words do you want to replace?", "Replace all", "");
            string destroy = Microsoft.VisualBasic.Interaction.InputBox("What do you want to replace those with?", "Replace all", "");
            tb.Text = tb.Text.Replace(search, destroy);
            this.Text = title;
        }
        // Sets themes
        // 2 is light mode
        // 1 is dark mode
        int themes = 2;
        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            tb.BackColor = ColorTranslator.FromHtml("#212121");
            tb.ForeColor = Color.White;
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                tabControl1.TabPages[i].BackColor = Color.Black;
                tabControl1.TabPages[i].ForeColor = Color.White;
            }
            panel1.BackColor = tb.BackColor;
            panel1.ForeColor = tb.BackColor;
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
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            tb.BackColor = Color.White;
            tb.ForeColor = Color.Black;
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                tabControl1.TabPages[i].BackColor = Color.White;
                tabControl1.TabPages[i].ForeColor = Color.Black;
            }
            panel1.BackColor = tb.BackColor;
            panel1.ForeColor = tb.BackColor;
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
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            if (tb.WordWrap)
            {
                tb.WordWrap = false;
                wordwrapoffToolStripMenuItem.Text = "Wordwrap (off)";
            }
            else
            {
                tb.WordWrap = true;
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
            // Get the currently selected tab
            RichTextBox Main = (RichTextBox) currenttab.selectedtabpage.Controls["MainTextField"];
            // Get start position to drop the text.  
            i = Main.SelectionStart;
            s = Main.Text.Substring(i);
            Main.Text = Main.Text.Substring(0, i);

            // Drop the text on to the RichTextBox.  
            Main.Text += e.Data.GetData(DataFormats.Text).ToString();
            Main.Text += s;
        }

        private void MainTextField_TextChanged_1(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox) currenttab.selectedtabpage.Controls["MainTextField"];
            lblLength.Text = "Length: " + tb.Text.Length.ToString();
            string[] textboxw = tb.Text.Split(' ');
            lblWords.Text = "Words:" + textboxw.Length.ToString();
            if (!Text.Contains(" - Unsaved"))
                Text += " - Unsaved";
        }

        private void insertRegexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            string inputs = Microsoft.VisualBasic.Interaction.InputBox("Please enter your desired regex string", "Regex", "");
            if (tb.Text.Length > 10000)
            {
                MessageBox.Show("You are trying to perform Regex on a really big amount of text, please keep in mind that this will take a while", "Warning!");
            }
            Task.Factory.StartNew(() => { regexexecute(inputs); });

            // Test regex ^.(.*)$
        }
        private void regexexecute(string regexinput)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            if (regexinput.Length != 0)
            {
                // Dit werkt maar t was niet leuk ngl
                string[] inpwords = tb.Text.Split(' ');
                tb.Text = "";
                foreach (var word in inpwords)
                {
                    string result = Regex.Replace(word, regexinput, "$1");
                    tb.Text += result + " ";
                }
            }
        }

        private void Zoomfactorchange_Tick(object sender, EventArgs e)
        {
            currenttab.selectedtabpage = tabControl1.SelectedTab;
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            lblZoom.Text = "Zoomfactor: " + tb.ZoomFactor.ToString() + "x";
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
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            if (Text.Contains(" - Unsaved") && tb.Text.Length != 0)
            {
                DialogResult dialogResult = MessageBox.Show("You have unsaved changes, do you wish to save them and create a new file?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Text = Text.Replace(" - Unsaved", "");
                    if (!Text.StartsWith("Untitled"))
                    {
                        File.WriteAllText(Text, tb.Text);
                    }
                    else
                    {
                        saveAsToolStripMenuItem_Click(sender, e);
                        Text = "Untitled";
                    }
                }
                else
                {
                    tb.Text = "";
                    Text = "Untitled";
                }
            }
            else
            {
                tb.Text = "";
                Text = "Untitled";
            }
            var backcolor = MainTextField.BackColor;
            var forecolor = MainTextField.ForeColor;
            TabPage tp = new TabPage();
            RichTextBox rtb = new RichTextBox();
            tabControl1.TabPages.Add(tp);
            tp.Controls.Add(rtb);
            rtb.Name = "MainTextField";
            rtb.BorderStyle = BorderStyle.None;
            rtb.Dock = DockStyle.Fill;
            rtb.AllowDrop = true;
            rtb.BackColor = backcolor; rtb.ForeColor = forecolor;
            rtb.TextChanged += MainTextField_TextChanged_1;
            rtb.DragDrop += MainTextField_DragDrop;
            rtb.SelectionChanged += MainTextField_SelectionChanged;
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tp);
            tp.Text = "Untitled";
            Text = tp.Text;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            if (Text.Contains(" - Unsaved"))
            {
                DialogResult dialogResult = MessageBox.Show("You have unsaved changes, do you wish to save and exit?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Text = Text.Replace(" - Unsaved", "");
                    File.WriteAllText(Text, tb.Text);
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
            sctb.Enabled = true;
            sctb.LexerLanguage = "Python";
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            StartupScripts.firsttime(tb);
            StartupScripts.zoomfactor(tb);
            StartupScripts.loadprev(tb, this);
            tabControl1.SelectedTab.Text = Text.Replace(" - Unsaved", "");
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
            wait(50);
            var rtb = tb;
            if (currenttab.selectedtabpage.Text.Contains(".py"))
            {
                rtb.TextChanged += syntaxhighlightpy;
            }
            if (currenttab.selectedtabpage.Text.Contains(".cs"))
            {
                rtb.TextChanged += syntaxhighlightcs;
            }
            if (currenttab.selectedtabpage.Text.Contains(".html"))
            {
                rtb.TextChanged += syntaxhighlightHTML;
            }
            if (currenttab.selectedtabpage.Text.Contains(".cpp"))
            {
                rtb.TextChanged += syntaxhighlightcpp;
            }
            if (currenttab.selectedtabpage.Text.Contains(".js"))
            {
                rtb.TextChanged += syntaxhighlightjs;
            }
            if (currenttab.selectedtabpage.Text.Contains(".asm"))
            {
                rtb.TextChanged += syntaxhighlightasm;
            }
            if (currenttab.selectedtabpage.Text.Contains(".c") && !currenttab.selectedtabpage.Text.Contains(".cpp") && !currenttab.selectedtabpage.Text.Contains(".cs"))
            {
                rtb.TextChanged += syntaxhighlightc;
            }
            rtb.Text += "";
        }

        private void MainTextField_SelectionChanged(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            if (tb.SelectionStart == tb.SelectionStart + tb.SelectionLength)
            {
                lblPos.Text = "Pos: " + tb.SelectionStart.ToString();
            }
            else
            {
                int end = tb.SelectionStart + tb.SelectionLength;
                string sEnd = end.ToString();
                lblPos.Text = "Pos: " + tb.SelectionStart.ToString() + " | " + sEnd;
            }
        }
        private void openrecentfile(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
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
            tb.Text = File.ReadAllText(s);
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
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            tb.SelectAll();
        }

        private void MenuStrip_BackColorChanged(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            foreach (var stripitem in Controls.OfType<ToolStripMenuItem>())
            {
                stripitem.BackColor = MenuStrip.BackColor;
                stripitem.ForeColor = tb.ForeColor;
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
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            tb.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)currenttab.selectedtabpage.Controls["MainTextField"];
            tb.Redo();
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

        private void generateBoilerplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boilerplate bp = new Boilerplate();
            bp.TopMost = true;
            bp.Show();
        }

        private void uTF7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ans = Interaction.InputBox("Please specify the exact path to where you want to save the file (C:\\this.txt\\)", "Save with UTF7");
            saveEncoded(Encoding.UTF7, ans);
        }

        private void uTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ans = Interaction.InputBox("Please specify the exact path to where you want to save the file (C:\\this.txt\\)", "Save with UTF8");
            saveEncoded(Encoding.UTF8, ans);
        }

        private void unicodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ans = Interaction.InputBox("Please specify the exact path to where you want to save the file (C:\\this.txt\\)", "Save with Unicode");
            saveEncoded(Encoding.Unicode, ans);
        }

        private void uTF32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ans = Interaction.InputBox("Please specify the exact path to where you want to save the file (C:\\this.txt\\)", "Save with UTF32");
            saveEncoded(Encoding.UTF32, ans);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Text = tabControl1.SelectedTab.Text;
            currenttab.selectedtabpage = tabControl1.SelectedTab;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }

        private void removeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int selected = tabControl1.SelectedIndex;
                tabControl1.TabPages.RemoveAt(selected);
            }
            catch
            {

            }
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void setFontTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font_selector bp = new Font_selector();
            bp.TopMost = true;
            bp.Show();
        }
    }
}   
