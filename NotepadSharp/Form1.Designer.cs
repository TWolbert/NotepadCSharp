namespace NotepadSharp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmR1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmR2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmR3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmR4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmR5 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeAndDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceInSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertRegexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToStartMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addShortcutToStartMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialCharactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateBoilerplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWithMetadataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWithEncodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uTF7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uTF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unicodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uTF32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontsizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.setFontTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordwrapoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCurrentTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asPythonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asHTMLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblWords = new System.Windows.Forms.Label();
            this.Zoomfactorchange = new System.Windows.Forms.Timer(this.components);
            this.lblZoom = new System.Windows.Forms.Label();
            this.lblPos = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.MainTextField = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.MenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.MenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MenuStrip.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.runToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MenuStrip.ShowItemToolTips = true;
            this.MenuStrip.Size = new System.Drawing.Size(1192, 24);
            this.MenuStrip.TabIndex = 2;
            this.MenuStrip.Text = "MenuStrip";
            this.MenuStrip.BackColorChanged += new System.EventHandler(this.MenuStrip_BackColorChanged);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.newToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.recentsToolStripMenuItem,
            this.openFolderToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importToolStripMenuItem.Image")));
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.ImportKey_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeToolStripMenuItem.Image")));
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // recentsToolStripMenuItem
            // 
            this.recentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmR1,
            this.tsmR2,
            this.tsmR3,
            this.tsmR4,
            this.tsmR5});
            this.recentsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("recentsToolStripMenuItem.Image")));
            this.recentsToolStripMenuItem.Name = "recentsToolStripMenuItem";
            this.recentsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.recentsToolStripMenuItem.Text = "Recents";
            // 
            // tsmR1
            // 
            this.tsmR1.Name = "tsmR1";
            this.tsmR1.Size = new System.Drawing.Size(80, 22);
            this.tsmR1.Text = "1";
            this.tsmR1.Click += new System.EventHandler(this.openrecentfile);
            // 
            // tsmR2
            // 
            this.tsmR2.Name = "tsmR2";
            this.tsmR2.Size = new System.Drawing.Size(80, 22);
            this.tsmR2.Text = "2";
            this.tsmR2.Click += new System.EventHandler(this.openrecentfile);
            // 
            // tsmR3
            // 
            this.tsmR3.Name = "tsmR3";
            this.tsmR3.Size = new System.Drawing.Size(80, 22);
            this.tsmR3.Text = "3";
            this.tsmR3.Click += new System.EventHandler(this.Form1_Shown);
            // 
            // tsmR4
            // 
            this.tsmR4.Name = "tsmR4";
            this.tsmR4.Size = new System.Drawing.Size(80, 22);
            this.tsmR4.Text = "4";
            this.tsmR4.Click += new System.EventHandler(this.openrecentfile);
            // 
            // tsmR5
            // 
            this.tsmR5.Name = "tsmR5";
            this.tsmR5.Size = new System.Drawing.Size(80, 22);
            this.tsmR5.Text = "5";
            this.tsmR5.Click += new System.EventHandler(this.openrecentfile);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFolderToolStripMenuItem.Image")));
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToolStripMenuItem,
            this.gotoToolStripMenuItem,
            this.timeAndDateToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.insertRegexToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.specialCharactersToolStripMenuItem,
            this.insertToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // gotoToolStripMenuItem
            // 
            this.gotoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("gotoToolStripMenuItem.Image")));
            this.gotoToolStripMenuItem.Name = "gotoToolStripMenuItem";
            this.gotoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.gotoToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.gotoToolStripMenuItem.Text = "Goto";
            this.gotoToolStripMenuItem.Click += new System.EventHandler(this.gotoToolStripMenuItem_Click);
            // 
            // timeAndDateToolStripMenuItem
            // 
            this.timeAndDateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("timeAndDateToolStripMenuItem.Image")));
            this.timeAndDateToolStripMenuItem.Name = "timeAndDateToolStripMenuItem";
            this.timeAndDateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.D)));
            this.timeAndDateToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.timeAndDateToolStripMenuItem.Text = "Time and Date";
            this.timeAndDateToolStripMenuItem.Click += new System.EventHandler(this.timeAndDateToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceInSelectionToolStripMenuItem,
            this.replaceAllToolStripMenuItem});
            this.replaceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("replaceToolStripMenuItem.Image")));
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.replaceToolStripMenuItem.Text = "Replace";
            // 
            // replaceInSelectionToolStripMenuItem
            // 
            this.replaceInSelectionToolStripMenuItem.Name = "replaceInSelectionToolStripMenuItem";
            this.replaceInSelectionToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.replaceInSelectionToolStripMenuItem.Text = "Replace in selection";
            this.replaceInSelectionToolStripMenuItem.Click += new System.EventHandler(this.replaceInSelectionToolStripMenuItem_Click);
            // 
            // replaceAllToolStripMenuItem
            // 
            this.replaceAllToolStripMenuItem.Name = "replaceAllToolStripMenuItem";
            this.replaceAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.replaceAllToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.replaceAllToolStripMenuItem.Text = "Replace all";
            this.replaceAllToolStripMenuItem.Click += new System.EventHandler(this.replaceAllToolStripMenuItem_Click);
            // 
            // insertRegexToolStripMenuItem
            // 
            this.insertRegexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("insertRegexToolStripMenuItem.Image")));
            this.insertRegexToolStripMenuItem.Name = "insertRegexToolStripMenuItem";
            this.insertRegexToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.insertRegexToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.insertRegexToolStripMenuItem.Text = "Insert regex";
            this.insertRegexToolStripMenuItem.Click += new System.EventHandler(this.insertRegexToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("selectAllToolStripMenuItem.Image")));
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.selectAllToolStripMenuItem.Text = "Select all";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoToolStripMenuItem.Image")));
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToStartMenuToolStripMenuItem,
            this.addShortcutToStartMenuToolStripMenuItem});
            this.preferencesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("preferencesToolStripMenuItem.Image")));
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // addToStartMenuToolStripMenuItem
            // 
            this.addToStartMenuToolStripMenuItem.Name = "addToStartMenuToolStripMenuItem";
            this.addToStartMenuToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.addToStartMenuToolStripMenuItem.Text = "Add Shortcut to Desktop";
            this.addToStartMenuToolStripMenuItem.Click += new System.EventHandler(this.addToStartMenuToolStripMenuItem_Click);
            // 
            // addShortcutToStartMenuToolStripMenuItem
            // 
            this.addShortcutToStartMenuToolStripMenuItem.Name = "addShortcutToStartMenuToolStripMenuItem";
            this.addShortcutToStartMenuToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.addShortcutToStartMenuToolStripMenuItem.Text = "Add Shortcut to Start Menu";
            this.addShortcutToStartMenuToolStripMenuItem.Click += new System.EventHandler(this.addShortcutToStartMenuToolStripMenuItem_Click);
            // 
            // specialCharactersToolStripMenuItem
            // 
            this.specialCharactersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("specialCharactersToolStripMenuItem.Image")));
            this.specialCharactersToolStripMenuItem.Name = "specialCharactersToolStripMenuItem";
            this.specialCharactersToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.specialCharactersToolStripMenuItem.Text = "Special Characters";
            this.specialCharactersToolStripMenuItem.Click += new System.EventHandler(this.specialCharactersToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateBoilerplateToolStripMenuItem});
            this.insertToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("insertToolStripMenuItem.Image")));
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.insertToolStripMenuItem.Text = "Insert";
            // 
            // generateBoilerplateToolStripMenuItem
            // 
            this.generateBoilerplateToolStripMenuItem.Name = "generateBoilerplateToolStripMenuItem";
            this.generateBoilerplateToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.generateBoilerplateToolStripMenuItem.Text = "Generate boilerplate";
            this.generateBoilerplateToolStripMenuItem.Click += new System.EventHandler(this.generateBoilerplateToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.saveAsThisToolStripMenuItem,
            this.advancedToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // saveAsThisToolStripMenuItem
            // 
            this.saveAsThisToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsThisToolStripMenuItem.Image")));
            this.saveAsThisToolStripMenuItem.Name = "saveAsThisToolStripMenuItem";
            this.saveAsThisToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsThisToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.saveAsThisToolStripMenuItem.Text = "Save as this";
            this.saveAsThisToolStripMenuItem.Click += new System.EventHandler(this.saveAsThisToolStripMenuItem_Click);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveWithMetadataToolStripMenuItem,
            this.saveWithEncodingToolStripMenuItem});
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.advancedToolStripMenuItem.Text = "Advanced";
            // 
            // saveWithMetadataToolStripMenuItem
            // 
            this.saveWithMetadataToolStripMenuItem.Name = "saveWithMetadataToolStripMenuItem";
            this.saveWithMetadataToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveWithMetadataToolStripMenuItem.Text = "Save with metadata";
            this.saveWithMetadataToolStripMenuItem.Click += new System.EventHandler(this.saveWithMetadataToolStripMenuItem_Click);
            // 
            // saveWithEncodingToolStripMenuItem
            // 
            this.saveWithEncodingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uTF7ToolStripMenuItem,
            this.uTF8ToolStripMenuItem,
            this.unicodeToolStripMenuItem,
            this.uTF32ToolStripMenuItem});
            this.saveWithEncodingToolStripMenuItem.Name = "saveWithEncodingToolStripMenuItem";
            this.saveWithEncodingToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveWithEncodingToolStripMenuItem.Text = "Save With Encoding";
            // 
            // uTF7ToolStripMenuItem
            // 
            this.uTF7ToolStripMenuItem.Name = "uTF7ToolStripMenuItem";
            this.uTF7ToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.uTF7ToolStripMenuItem.Text = "UTF7";
            this.uTF7ToolStripMenuItem.Click += new System.EventHandler(this.uTF7ToolStripMenuItem_Click);
            // 
            // uTF8ToolStripMenuItem
            // 
            this.uTF8ToolStripMenuItem.Name = "uTF8ToolStripMenuItem";
            this.uTF8ToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.uTF8ToolStripMenuItem.Text = "UTF8";
            this.uTF8ToolStripMenuItem.Click += new System.EventHandler(this.uTF8ToolStripMenuItem_Click);
            // 
            // unicodeToolStripMenuItem
            // 
            this.unicodeToolStripMenuItem.Name = "unicodeToolStripMenuItem";
            this.unicodeToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.unicodeToolStripMenuItem.Text = "Unicode";
            this.unicodeToolStripMenuItem.Click += new System.EventHandler(this.unicodeToolStripMenuItem_Click);
            // 
            // uTF32ToolStripMenuItem
            // 
            this.uTF32ToolStripMenuItem.Name = "uTF32ToolStripMenuItem";
            this.uTF32ToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.uTF32ToolStripMenuItem.Text = "UTF32";
            this.uTF32ToolStripMenuItem.Click += new System.EventHandler(this.uTF32ToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontsizeToolStripMenuItem,
            this.themesToolStripMenuItem,
            this.wordwrapoffToolStripMenuItem,
            this.alwaysOnTopoffToolStripMenuItem,
            this.reloadAppToolStripMenuItem,
            this.removeCurrentTabToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // fontsizeToolStripMenuItem
            // 
            this.fontsizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.pxToolStripMenuItem,
            this.toolStripMenuItem2,
            this.pxToolStripMenuItem1,
            this.pxToolStripMenuItem2,
            this.pxToolStripMenuItem3,
            this.setFontTypeToolStripMenuItem});
            this.fontsizeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fontsizeToolStripMenuItem.Image")));
            this.fontsizeToolStripMenuItem.Name = "fontsizeToolStripMenuItem";
            this.fontsizeToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.fontsizeToolStripMenuItem.Text = "Fonts";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem1.Text = "8px";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // pxToolStripMenuItem
            // 
            this.pxToolStripMenuItem.Name = "pxToolStripMenuItem";
            this.pxToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.pxToolStripMenuItem.Text = "16px";
            this.pxToolStripMenuItem.Click += new System.EventHandler(this.pxToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem2.Text = "18px";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // pxToolStripMenuItem1
            // 
            this.pxToolStripMenuItem1.Name = "pxToolStripMenuItem1";
            this.pxToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.pxToolStripMenuItem1.Text = "20px";
            this.pxToolStripMenuItem1.Click += new System.EventHandler(this.pxToolStripMenuItem1_Click);
            // 
            // pxToolStripMenuItem2
            // 
            this.pxToolStripMenuItem2.Name = "pxToolStripMenuItem2";
            this.pxToolStripMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.pxToolStripMenuItem2.Text = "22px";
            this.pxToolStripMenuItem2.Click += new System.EventHandler(this.pxToolStripMenuItem2_Click);
            // 
            // pxToolStripMenuItem3
            // 
            this.pxToolStripMenuItem3.Name = "pxToolStripMenuItem3";
            this.pxToolStripMenuItem3.Size = new System.Drawing.Size(136, 22);
            this.pxToolStripMenuItem3.Text = "24px";
            this.pxToolStripMenuItem3.Click += new System.EventHandler(this.pxToolStripMenuItem3_Click);
            // 
            // setFontTypeToolStripMenuItem
            // 
            this.setFontTypeToolStripMenuItem.Name = "setFontTypeToolStripMenuItem";
            this.setFontTypeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.setFontTypeToolStripMenuItem.Text = "Set font type";
            this.setFontTypeToolStripMenuItem.Click += new System.EventHandler(this.setFontTypeToolStripMenuItem_Click);
            // 
            // themesToolStripMenuItem
            // 
            this.themesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darkToolStripMenuItem,
            this.lightToolStripMenuItem});
            this.themesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("themesToolStripMenuItem.Image")));
            this.themesToolStripMenuItem.Name = "themesToolStripMenuItem";
            this.themesToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.themesToolStripMenuItem.Text = "Themes";
            // 
            // darkToolStripMenuItem
            // 
            this.darkToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("darkToolStripMenuItem.Image")));
            this.darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            this.darkToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.darkToolStripMenuItem.Text = "Dark";
            this.darkToolStripMenuItem.Click += new System.EventHandler(this.darkToolStripMenuItem_Click);
            // 
            // lightToolStripMenuItem
            // 
            this.lightToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("lightToolStripMenuItem.Image")));
            this.lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            this.lightToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.lightToolStripMenuItem.Text = "Light";
            this.lightToolStripMenuItem.Click += new System.EventHandler(this.lightToolStripMenuItem_Click);
            // 
            // wordwrapoffToolStripMenuItem
            // 
            this.wordwrapoffToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("wordwrapoffToolStripMenuItem.Image")));
            this.wordwrapoffToolStripMenuItem.Name = "wordwrapoffToolStripMenuItem";
            this.wordwrapoffToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.wordwrapoffToolStripMenuItem.Text = "Wordwrap (off)";
            this.wordwrapoffToolStripMenuItem.Click += new System.EventHandler(this.wordwrapoffToolStripMenuItem_Click);
            // 
            // alwaysOnTopoffToolStripMenuItem
            // 
            this.alwaysOnTopoffToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("alwaysOnTopoffToolStripMenuItem.Image")));
            this.alwaysOnTopoffToolStripMenuItem.Name = "alwaysOnTopoffToolStripMenuItem";
            this.alwaysOnTopoffToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.alwaysOnTopoffToolStripMenuItem.Text = "Always on top (off)";
            this.alwaysOnTopoffToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopoffToolStripMenuItem_Click);
            // 
            // reloadAppToolStripMenuItem
            // 
            this.reloadAppToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reloadAppToolStripMenuItem.Image")));
            this.reloadAppToolStripMenuItem.Name = "reloadAppToolStripMenuItem";
            this.reloadAppToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.reloadAppToolStripMenuItem.Text = "Reload app";
            this.reloadAppToolStripMenuItem.Click += new System.EventHandler(this.reloadAppToolStripMenuItem_Click);
            // 
            // removeCurrentTabToolStripMenuItem
            // 
            this.removeCurrentTabToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeCurrentTabToolStripMenuItem.Image")));
            this.removeCurrentTabToolStripMenuItem.Name = "removeCurrentTabToolStripMenuItem";
            this.removeCurrentTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.removeCurrentTabToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.removeCurrentTabToolStripMenuItem.Text = "Remove current tab";
            this.removeCurrentTabToolStripMenuItem.Click += new System.EventHandler(this.removeCurrentTabToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asPythonToolStripMenuItem,
            this.asHTMLFileToolStripMenuItem});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // asPythonToolStripMenuItem
            // 
            this.asPythonToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("asPythonToolStripMenuItem.Image")));
            this.asPythonToolStripMenuItem.Name = "asPythonToolStripMenuItem";
            this.asPythonToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.asPythonToolStripMenuItem.Text = "As python";
            this.asPythonToolStripMenuItem.Click += new System.EventHandler(this.asPythonToolStripMenuItem_Click);
            // 
            // asHTMLFileToolStripMenuItem
            // 
            this.asHTMLFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("asHTMLFileToolStripMenuItem.Image")));
            this.asHTMLFileToolStripMenuItem.Name = "asHTMLFileToolStripMenuItem";
            this.asHTMLFileToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.asHTMLFileToolStripMenuItem.Text = "As HTML file";
            this.asHTMLFileToolStripMenuItem.Click += new System.EventHandler(this.asHTMLFileToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.X)));
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // lblLength
            // 
            this.lblLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLength.Location = new System.Drawing.Point(-3, 4);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(125, 13);
            this.lblLength.TabIndex = 4;
            this.lblLength.Text = "Length:";
            this.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWords
            // 
            this.lblWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWords.Location = new System.Drawing.Point(128, 4);
            this.lblWords.Name = "lblWords";
            this.lblWords.Size = new System.Drawing.Size(125, 13);
            this.lblWords.TabIndex = 5;
            this.lblWords.Text = "Words";
            // 
            // Zoomfactorchange
            // 
            this.Zoomfactorchange.Enabled = true;
            this.Zoomfactorchange.Interval = 500;
            this.Zoomfactorchange.Tick += new System.EventHandler(this.Zoomfactorchange_Tick);
            // 
            // lblZoom
            // 
            this.lblZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZoom.Location = new System.Drawing.Point(259, 4);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(110, 13);
            this.lblZoom.TabIndex = 6;
            this.lblZoom.Text = "Zoomfactor: ";
            // 
            // lblPos
            // 
            this.lblPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPos.Location = new System.Drawing.Point(375, 4);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(101, 13);
            this.lblPos.TabIndex = 7;
            this.lblPos.Text = "Pos:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLength);
            this.panel1.Controls.Add(this.lblPos);
            this.panel1.Controls.Add(this.lblWords);
            this.panel1.Controls.Add(this.lblZoom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 559);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1192, 17);
            this.panel1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.MainTextField);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1184, 508);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MainTextField
            // 
            this.MainTextField.AcceptsTab = true;
            this.MainTextField.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.MainTextField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainTextField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTextField.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTextField.Location = new System.Drawing.Point(3, 3);
            this.MainTextField.Name = "MainTextField";
            this.MainTextField.Size = new System.Drawing.Size(1178, 502);
            this.MainTextField.TabIndex = 3;
            this.MainTextField.Text = "";
            this.MainTextField.WordWrap = false;
            this.MainTextField.SelectionChanged += new System.EventHandler(this.MainTextField_SelectionChanged);
            this.MainTextField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainTextField_MouseClick);
            this.MainTextField.TextChanged += new System.EventHandler(this.MainTextField_TextChanged_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1192, 535);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 576);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MenuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "Form1";
            this.Text = "Untitled";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontsizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asPythonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeAndDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceInSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsThisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asHTMLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordwrapoffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopoffToolStripMenuItem;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.ToolStripMenuItem insertRegexToolStripMenuItem;
        private System.Windows.Forms.Label lblWords;
        private System.Windows.Forms.Timer Zoomfactorchange;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.ToolStripMenuItem recentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmR1;
        private System.Windows.Forms.ToolStripMenuItem tsmR2;
        private System.Windows.Forms.ToolStripMenuItem tsmR3;
        private System.Windows.Forms.ToolStripMenuItem tsmR4;
        private System.Windows.Forms.ToolStripMenuItem tsmR5;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWithMetadataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToStartMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addShortcutToStartMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specialCharactersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateBoilerplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWithEncodingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uTF7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uTF8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unicodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uTF32ToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox MainTextField;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem removeCurrentTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setFontTypeToolStripMenuItem;
    }
}

