namespace View.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mnuMenuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAcquisition = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.impostazioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCalibration = new System.Windows.Forms.ToolStripMenuItem();
            this.stbStatusBar = new System.Windows.Forms.StatusStrip();
            this.lblStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.grdTable = new View.Controls.MyDataGridView();
            this.mnuMenuStrip.SuspendLayout();
            this.stbStatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMenuStrip
            // 
            this.mnuMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.impostazioniToolStripMenuItem});
            this.mnuMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuMenuStrip.Name = "mnuMenuStrip";
            this.mnuMenuStrip.Size = new System.Drawing.Size(662, 24);
            this.mnuMenuStrip.TabIndex = 0;
            this.mnuMenuStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnect,
            this.toolStripSeparator1,
            this.mnuAcquisition,
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
            this.mnuConnect.Size = new System.Drawing.Size(195, 22);
            this.mnuConnect.Text = "&Connetti";
            this.mnuConnect.Click += new System.EventHandler(this.mnuConnectClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuAcquisition
            // 
            this.mnuAcquisition.Enabled = false;
            this.mnuAcquisition.Name = "mnuAcquisition";
            this.mnuAcquisition.Size = new System.Drawing.Size(195, 22);
            this.mnuAcquisition.Text = "&Acquisisci temperature";
            this.mnuAcquisition.Click += new System.EventHandler(this.mnuStartAcquisitionClick);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Enabled = false;
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.Size = new System.Drawing.Size(195, 22);
            this.mnuSaveAs.Text = "&Salva il log";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAsClick);
            // 
            // mnuLoad
            // 
            this.mnuLoad.Name = "mnuLoad";
            this.mnuLoad.Size = new System.Drawing.Size(195, 22);
            this.mnuLoad.Text = "&Carica un log";
            this.mnuLoad.Click += new System.EventHandler(this.mnuLoadClick);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(195, 22);
            this.mnuExit.Text = "&Esci";
            this.mnuExit.Click += new System.EventHandler(this.mnuExitClick);
            // 
            // impostazioniToolStripMenuItem
            // 
            this.impostazioniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.mnuCalibration});
            this.impostazioniToolStripMenuItem.Name = "impostazioniToolStripMenuItem";
            this.impostazioniToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.impostazioniToolStripMenuItem.Text = "&Impostazioni";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(142, 22);
            this.mnuSettings.Text = "I&mpostazioni";
            this.mnuSettings.Click += new System.EventHandler(this.mnuImpostazioniClick);
            // 
            // mnuCalibration
            // 
            this.mnuCalibration.Name = "mnuCalibration";
            this.mnuCalibration.Size = new System.Drawing.Size(142, 22);
            this.mnuCalibration.Text = "&Tarature";
            this.mnuCalibration.Click += new System.EventHandler(this.mnuTaratureClick);
            // 
            // stbStatusBar
            // 
            this.stbStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusBar});
            this.stbStatusBar.Location = new System.Drawing.Point(0, 413);
            this.stbStatusBar.Name = "stbStatusBar";
            this.stbStatusBar.Size = new System.Drawing.Size(662, 22);
            this.stbStatusBar.TabIndex = 1;
            this.stbStatusBar.Text = "statusStrip1";
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(0, 17);
            // 
            // grdTable
            // 
            this.grdTable.AllowUserToAddRows = false;
            this.grdTable.AllowUserToDeleteRows = false;
            this.grdTable.AllowUserToResizeRows = false;
            this.grdTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTable.Enabled = false;
            this.grdTable.EnableHeadersVisualStyles = false;
            this.grdTable.Location = new System.Drawing.Point(0, 24);
            this.grdTable.MultiSelect = false;
            this.grdTable.Name = "grdTable";
            this.grdTable.ReadOnly = true;
            this.grdTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdTable.RowHeadersVisible = false;
            this.grdTable.RowTemplate.ReadOnly = true;
            this.grdTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTable.ShowCellToolTips = false;
            this.grdTable.ShowEditingIcon = false;
            this.grdTable.Size = new System.Drawing.Size(662, 389);
            this.grdTable.TabIndex = 2;
            
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(662, 435);
            this.Controls.Add(this.grdTable);
            this.Controls.Add(this.stbStatusBar);
            this.Controls.Add(this.mnuMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMenuStrip;
            this.Name = "MainForm";
            this.Text = "TempLog 2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            this.Load += new System.EventHandler(this.FormLoad);
            this.Shown += new System.EventHandler(this.MainFormShown);
            this.mnuMenuStrip.ResumeLayout(false);
            this.mnuMenuStrip.PerformLayout();
            this.stbStatusBar.ResumeLayout(false);
            this.stbStatusBar.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem mnuAcquisition;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem impostazioniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBar;
        private System.Windows.Forms.ToolStripMenuItem mnuCalibration;
        private Controls.MyDataGridView grdTable;
    }
}