namespace NotepadSharp
{
    partial class Boilerplate
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Cb1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "HTML",
            "C#",
            "Java"});
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(191, 338);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Cb1
            // 
            this.Cb1.AutoSize = true;
            this.Cb1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Cb1.Location = new System.Drawing.Point(0, 321);
            this.Cb1.Name = "Cb1";
            this.Cb1.Size = new System.Drawing.Size(191, 17);
            this.Cb1.TabIndex = 1;
            this.Cb1.Text = "Replace?";
            this.Cb1.UseVisualStyleBackColor = true;
            this.Cb1.CheckedChanged += new System.EventHandler(this.Cb1_CheckedChanged);
            // 
            // Boilerplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 338);
            this.Controls.Add(this.Cb1);
            this.Controls.Add(this.listBox1);
            this.Name = "Boilerplate";
            this.ShowIcon = false;
            this.Text = "Boilerplates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox Cb1;
    }
}