namespace View.Controls.SettingsPanel
{
    partial class GlobalSettingsPanel
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPollingInterval = new System.Windows.Forms.Label();
            this.cbxPollingInterval = new System.Windows.Forms.ComboBox();
            this.lblSaveInterval = new System.Windows.Forms.Label();
            this.txtSaveInterval = new System.Windows.Forms.MaskedTextBox();
            this.chkSaveDate = new System.Windows.Forms.CheckBox();
            this.dtpSaveDate = new System.Windows.Forms.DateTimePicker();
            this.pnlTableMain = new System.Windows.Forms.TableLayoutPanel();
            this.fslSaveFolder = new View.Controls.FolderSelector();
            this.lblSaveFolder = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.cbxPort = new System.Windows.Forms.ComboBox();
            this.chkConnectOnStart = new System.Windows.Forms.CheckBox();
            this.pnlTableMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPollingInterval
            // 
            this.lblPollingInterval.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPollingInterval.AutoSize = true;
            this.lblPollingInterval.Location = new System.Drawing.Point(45, 71);
            this.lblPollingInterval.Name = "lblPollingInterval";
            this.lblPollingInterval.Size = new System.Drawing.Size(122, 13);
            this.lblPollingInterval.TabIndex = 0;
            this.lblPollingInterval.Text = "Intervallo di acquisizione";
            // 
            // cbxPollingInterval
            // 
            this.cbxPollingInterval.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxPollingInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPollingInterval.FormattingEnabled = true;
            this.cbxPollingInterval.Items.AddRange(new object[] {
            "acquisizione continua",
            "cinque minuti",
            "mezz\'ora",
            "un\'ora"});
            this.cbxPollingInterval.Location = new System.Drawing.Point(173, 67);
            this.cbxPollingInterval.Name = "cbxPollingInterval";
            this.cbxPollingInterval.Size = new System.Drawing.Size(163, 21);
            this.cbxPollingInterval.TabIndex = 1;
            this.cbxPollingInterval.SelectedIndexChanged += new System.EventHandler(this.cbxPollingIntervalSelectedIndexChanged);
            // 
            // lblSaveInterval
            // 
            this.lblSaveInterval.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSaveInterval.AutoSize = true;
            this.lblSaveInterval.Location = new System.Drawing.Point(12, 102);
            this.lblSaveInterval.Name = "lblSaveInterval";
            this.lblSaveInterval.Size = new System.Drawing.Size(155, 13);
            this.lblSaveInterval.TabIndex = 2;
            this.lblSaveInterval.Text = "Intervallo di salvataggio dei dati";
            // 
            // dtpSaveInterval
            // 
            this.txtSaveInterval.Anchor = System.Windows.Forms.AnchorStyles.Left;
            //this.dtpSaveInterval.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.txtSaveInterval.Location = new System.Drawing.Point(173, 98);
            this.txtSaveInterval.Name = "txtSaveInterval";
            this.txtSaveInterval.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSaveInterval.Mask = "00:00";
            this.txtSaveInterval.ValidatingType = typeof(System.DateTime);
            //this.dtpSaveInterval.ShowUpDown = true;
            this.txtSaveInterval.Size = new System.Drawing.Size(68, 20);
            this.txtSaveInterval.TabIndex = 3;
            //this.dtpSaveInterval.ValueChanged += new System.EventHandler(this.dtpSaveIntervalValueChanged);
            this.txtSaveInterval.TextChanged += new System.EventHandler(this.dtpSaveIntervalValueChanged);
            // 
            // chkSaveDate
            // 
            this.chkSaveDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkSaveDate.AutoSize = true;
            this.chkSaveDate.Location = new System.Drawing.Point(49, 131);
            this.chkSaveDate.Name = "chkSaveDate";
            this.chkSaveDate.Size = new System.Drawing.Size(118, 17);
            this.chkSaveDate.TabIndex = 4;
            this.chkSaveDate.Text = "Partendo dalla data";
            this.chkSaveDate.UseVisualStyleBackColor = true;
            this.chkSaveDate.CheckedChanged += new System.EventHandler(this.chkSaveDateCheckedChanged);
            // 
            // dtpSaveDate
            // 
            this.dtpSaveDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpSaveDate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSaveDate.Location = new System.Drawing.Point(173, 129);
            this.dtpSaveDate.Name = "dtpSaveDate";
            this.dtpSaveDate.Size = new System.Drawing.Size(128, 20);
            this.dtpSaveDate.TabIndex = 5;
            this.dtpSaveDate.ValueChanged += new System.EventHandler(this.dtpSaveDateValueChanged);
            // 
            // pnlTableMain
            // 
            this.pnlTableMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTableMain.ColumnCount = 2;
            this.pnlTableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.pnlTableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlTableMain.Controls.Add(this.fslSaveFolder, 1, 5);
            this.pnlTableMain.Controls.Add(this.lblSaveFolder, 0, 5);
            this.pnlTableMain.Controls.Add(this.dtpSaveDate, 1, 4);
            this.pnlTableMain.Controls.Add(this.chkSaveDate, 0, 4);
            this.pnlTableMain.Controls.Add(this.txtSaveInterval, 1, 3);
            this.pnlTableMain.Controls.Add(this.lblSaveInterval, 0, 3);
            this.pnlTableMain.Controls.Add(this.lblPollingInterval, 0, 2);
            this.pnlTableMain.Controls.Add(this.cbxPollingInterval, 1, 2);
            this.pnlTableMain.Controls.Add(this.lblPort, 0, 0);
            this.pnlTableMain.Controls.Add(this.cbxPort, 1, 0);
            this.pnlTableMain.Controls.Add(this.chkConnectOnStart, 1, 1);
            this.pnlTableMain.Location = new System.Drawing.Point(3, 3);
            this.pnlTableMain.MinimumSize = new System.Drawing.Size(417, 187);
            this.pnlTableMain.Name = "pnlTableMain";
            this.pnlTableMain.RowCount = 6;
            this.pnlTableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pnlTableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pnlTableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pnlTableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pnlTableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pnlTableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pnlTableMain.Size = new System.Drawing.Size(417, 187);
            this.pnlTableMain.TabIndex = 6;
            // 
            // fslSaveFolder
            // 
            this.fslSaveFolder.Folder = "";
            this.fslSaveFolder.Location = new System.Drawing.Point(173, 158);
            this.fslSaveFolder.MaximumSize = new System.Drawing.Size(0, 26);
            this.fslSaveFolder.MinimumSize = new System.Drawing.Size(229, 26);
            this.fslSaveFolder.Name = "fslSaveFolder";
            this.fslSaveFolder.Size = new System.Drawing.Size(229, 26);
            this.fslSaveFolder.TabIndex = 8;
            this.fslSaveFolder.ModifiedChanged += new System.EventHandler(this.fslSaveFolderModifiedChanged);
            // 
            // lblSaveFolder
            // 
            this.lblSaveFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSaveFolder.AutoSize = true;
            this.lblSaveFolder.Location = new System.Drawing.Point(57, 164);
            this.lblSaveFolder.Name = "lblSaveFolder";
            this.lblSaveFolder.Size = new System.Drawing.Size(110, 13);
            this.lblSaveFolder.TabIndex = 7;
            this.lblSaveFolder.Text = "Cartella di salvataggio";
            // 
            // lblPort
            // 
            this.lblPort.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(61, 9);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(106, 13);
            this.lblPort.TabIndex = 9;
            this.lblPort.Text = "Porta della centralina";
            // 
            // cbxPort
            // 
            this.cbxPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPort.FormattingEnabled = true;
            this.cbxPort.Location = new System.Drawing.Point(173, 5);
            this.cbxPort.Name = "cbxPort";
            this.cbxPort.Size = new System.Drawing.Size(128, 21);
            this.cbxPort.TabIndex = 10;
            this.cbxPort.SelectedIndexChanged += new System.EventHandler(this.cbxPortSelectedIndexChanged);
            // 
            // chkConnectOnStart
            // 
            this.chkConnectOnStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkConnectOnStart.AutoSize = true;
            this.chkConnectOnStart.Location = new System.Drawing.Point(173, 38);
            this.chkConnectOnStart.Name = "chkConnectOnStart";
            this.chkConnectOnStart.Size = new System.Drawing.Size(105, 17);
            this.chkConnectOnStart.TabIndex = 11;
            this.chkConnectOnStart.Text = "connetti all\'avvio";
            this.chkConnectOnStart.UseVisualStyleBackColor = true;
            this.chkConnectOnStart.CheckedChanged += new System.EventHandler(this.chkConnectOnStartCheckedChanged);
            // 
            // GlobalSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTableMain);
            this.MinimumSize = new System.Drawing.Size(420, 143);
            this.Name = "GlobalSettingsPanel";
            this.Size = new System.Drawing.Size(420, 235);
            this.Load += new System.EventHandler(this.GlobalSettingsPanelLoad);
            this.pnlTableMain.ResumeLayout(false);
            this.pnlTableMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPollingInterval;
        private System.Windows.Forms.ComboBox cbxPollingInterval;
        private System.Windows.Forms.Label lblSaveInterval;
        private System.Windows.Forms.MaskedTextBox txtSaveInterval;
        private System.Windows.Forms.CheckBox chkSaveDate;
        private System.Windows.Forms.DateTimePicker dtpSaveDate;
        private System.Windows.Forms.TableLayoutPanel pnlTableMain;
        private System.Windows.Forms.Label lblSaveFolder;
        private FolderSelector fslSaveFolder;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cbxPort;
        private System.Windows.Forms.CheckBox chkConnectOnStart;
    }
}
