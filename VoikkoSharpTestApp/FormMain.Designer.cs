namespace VoikkoSharpTestApp
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSpellCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSpellCheck = new System.Windows.Forms.TextBox();
            this.odTextFile = new System.Windows.Forms.OpenFileDialog();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(800, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuSpellCheck});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(64, 20);
            this.mnuFile.Text = "Tiedosto";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(190, 22);
            this.mnuOpen.Text = "Avaa";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSpellCheck
            // 
            this.mnuSpellCheck.Name = "mnuSpellCheck";
            this.mnuSpellCheck.Size = new System.Drawing.Size(190, 22);
            this.mnuSpellCheck.Text = "Tarkista oikeinkirjoitus";
            this.mnuSpellCheck.Click += new System.EventHandler(this.mnuSpellCheck_Click);
            // 
            // tbSpellCheck
            // 
            this.tbSpellCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSpellCheck.Location = new System.Drawing.Point(12, 27);
            this.tbSpellCheck.Multiline = true;
            this.tbSpellCheck.Name = "tbSpellCheck";
            this.tbSpellCheck.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSpellCheck.Size = new System.Drawing.Size(776, 411);
            this.tbSpellCheck.TabIndex = 1;
            this.tbSpellCheck.WordWrap = false;
            // 
            // odTextFile
            // 
            this.odTextFile.Filter = "Tekstitiedostot|*.txt";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbSpellCheck);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "FormMain";
            this.Text = "VoikkoSharpTestApp Testisovellus © VPKSoft 2020";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.TextBox tbSpellCheck;
        private System.Windows.Forms.OpenFileDialog odTextFile;
        private System.Windows.Forms.ToolStripMenuItem mnuSpellCheck;
    }
}

