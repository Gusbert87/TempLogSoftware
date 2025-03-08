namespace View
{
    partial class MainForm
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
            this.mnuMenuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStartAcquisition = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStopAcquisition = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.stbStatusBar = new System.Windows.Forms.StatusStrip();
            this.grdTable = new System.Windows.Forms.DataGridView();
            this.mnuMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMenuStrip
            // 
            this.mnuMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuMenuStrip.Name = "mnuMenuStrip";
            this.mnuMenuStrip.Size = new System.Drawing.Size(732, 24);
            this.mnuMenuStrip.TabIndex = 0;
            this.mnuMenuStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnect,
            this.toolStripSeparator1,
            this.mnuStartAcquisition,
            this.mnuStopAcquisition,
            this.mnuSaveAs,
            this.mnuLoad,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuConnect
            // 
            this.mnuConnect.Name = "mnuConnect";
            this.mnuConnect.Size = new System.Drawing.Size(159, 22);
            this.mnuConnect.Text = "&Connect";
            this.mnuConnect.Click += new System.EventHandler(this.mnuConnectClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // mnuStartAcquisition
            // 
            this.mnuStartAcquisition.Enabled = false;
            this.mnuStartAcquisition.Name = "mnuStartAcquisition";
            this.mnuStartAcquisition.Size = new System.Drawing.Size(159, 22);
            this.mnuStartAcquisition.Text = "Start &acquisition";
            this.mnuStartAcquisition.Click += new System.EventHandler(this.mnuStartAcquisitionClick);
            // 
            // mnuStopAcquisition
            // 
            this.mnuStopAcquisition.Enabled = false;
            this.mnuStopAcquisition.Name = "mnuStopAcquisition";
            this.mnuStopAcquisition.Size = new System.Drawing.Size(159, 22);
            this.mnuStopAcquisition.Text = "S&top acquisition";
            this.mnuStopAcquisition.Click += new System.EventHandler(this.mnuStopAcquisitionClick);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Enabled = false;
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.Size = new System.Drawing.Size(159, 22);
            this.mnuSaveAs.Text = "Save &As";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAsClick);
            // 
            // mnuLoad
            // 
            this.mnuLoad.Name = "mnuLoad";
            this.mnuLoad.Size = new System.Drawing.Size(159, 22);
            this.mnuLoad.Text = "&Load";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(159, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExitClick);
            // 
            // stbStatusBar
            // 
            this.stbStatusBar.Location = new System.Drawing.Point(0, 415);
            this.stbStatusBar.Name = "stbStatusBar";
            this.stbStatusBar.Size = new System.Drawing.Size(732, 22);
            this.stbStatusBar.TabIndex = 1;
            this.stbStatusBar.Text = "statusStrip1";
            // 
            // grdTable
            // 
            this.grdTable.AllowUserToAddRows = false;
            this.grdTable.AllowUserToDeleteRows = false;
            this.grdTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTable.Enabled = false;
            this.grdTable.Location = new System.Drawing.Point(0, 24);
            this.grdTable.Name = "grdTable";
            this.grdTable.ReadOnly = true;
            this.grdTable.Size = new System.Drawing.Size(732, 391);
            this.grdTable.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 437);
            this.Controls.Add(this.grdTable);
            this.Controls.Add(this.stbStatusBar);
            this.Controls.Add(this.mnuMenuStrip);
            this.MainMenuStrip = this.mnuMenuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            this.Load += new System.EventHandler(this.FormLoad);
            this.mnuMenuStrip.ResumeLayout(false);
            this.mnuMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuLoad;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.StatusStrip stbStatusBar;
        private System.Windows.Forms.DataGridView grdTable;
        private System.Windows.Forms.ToolStripMenuItem mnuStartAcquisition;
        private System.Windows.Forms.ToolStripMenuItem mnuStopAcquisition;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
    }
}