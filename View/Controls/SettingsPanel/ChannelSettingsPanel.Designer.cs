namespace View.Controls.SettingsPanel
{
    partial class ChannelSettingsPanel
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
            this.gbxBorder = new System.Windows.Forms.GroupBox();
            this.pnlTableMain = new System.Windows.Forms.TableLayoutPanel();
            this.numInf = new System.Windows.Forms.NumericUpDown();
            this.chkIsSup = new System.Windows.Forms.CheckBox();
            this.chkIsInf = new System.Windows.Forms.CheckBox();
            this.numSup = new System.Windows.Forms.NumericUpDown();
            this.gbxBorder.SuspendLayout();
            this.pnlTableMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSup)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxBorder
            // 
            this.gbxBorder.Controls.Add(this.pnlTableMain);
            this.gbxBorder.Location = new System.Drawing.Point(3, 3);
            this.gbxBorder.MinimumSize = new System.Drawing.Size(414, 77);
            this.gbxBorder.Name = "gbxBorder";
            this.gbxBorder.Size = new System.Drawing.Size(414, 78);
            this.gbxBorder.TabIndex = 0;
            this.gbxBorder.TabStop = false;
            this.gbxBorder.Text = "Channel 0";
            // 
            // pnlTableMain
            // 
            this.pnlTableMain.ColumnCount = 2;
            this.pnlTableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.24324F));
            this.pnlTableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.75676F));
            this.pnlTableMain.Controls.Add(this.numInf, 1, 1);
            this.pnlTableMain.Controls.Add(this.chkIsSup, 0, 0);
            this.pnlTableMain.Controls.Add(this.chkIsInf, 0, 1);
            this.pnlTableMain.Controls.Add(this.numSup, 1, 0);
            this.pnlTableMain.Location = new System.Drawing.Point(6, 19);
            this.pnlTableMain.Name = "pnlTableMain";
            this.pnlTableMain.RowCount = 2;
            this.pnlTableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTableMain.Size = new System.Drawing.Size(407, 57);
            this.pnlTableMain.TabIndex = 0;
            // 
            // numInf
            // 
            this.numInf.DecimalPlaces = 2;
            this.numInf.Enabled = false;
            this.numInf.Location = new System.Drawing.Point(178, 31);
            this.numInf.Name = "numInf";
            this.numInf.Size = new System.Drawing.Size(120, 20);
            this.numInf.TabIndex = 3;
            this.numInf.Increment = new decimal(0.01);
            this.numInf.Minimum = -1000;
            // 
            // chkIsSup
            // 
            this.chkIsSup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkIsSup.AutoSize = true;
            this.chkIsSup.Location = new System.Drawing.Point(71, 5);
            this.chkIsSup.Name = "chkIsSup";
            this.chkIsSup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsSup.Size = new System.Drawing.Size(101, 17);
            this.chkIsSup.TabIndex = 0;
            this.chkIsSup.Text = "Soglia superiore";
            this.chkIsSup.UseVisualStyleBackColor = true;
            // 
            // chkIsInf
            // 
            this.chkIsInf.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkIsInf.AutoSize = true;
            this.chkIsInf.Location = new System.Drawing.Point(77, 34);
            this.chkIsInf.Name = "chkIsInf";
            this.chkIsInf.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsInf.Size = new System.Drawing.Size(95, 17);
            this.chkIsInf.TabIndex = 1;
            this.chkIsInf.Text = "Soglia inferiore";
            this.chkIsInf.UseVisualStyleBackColor = true;
            // 
            // numSup
            // 
            this.numSup.DecimalPlaces = 2;
            this.numSup.Enabled = false;
            this.numSup.Location = new System.Drawing.Point(178, 3);
            this.numSup.Name = "numSup";
            this.numSup.Size = new System.Drawing.Size(120, 20);
            this.numSup.TabIndex = 2;
            this.numSup.Increment = new decimal(0.01);
            this.numSup.Minimum = -1000;

            // 
            // ChannelSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxBorder);
            this.Name = "ChannelSettingsPanel";
            this.Size = new System.Drawing.Size(420, 88);
            this.Load += new System.EventHandler(this.ChannelSettingsPanelLoad);
            this.gbxBorder.ResumeLayout(false);
            this.pnlTableMain.ResumeLayout(false);
            this.pnlTableMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxBorder;
        private System.Windows.Forms.TableLayoutPanel pnlTableMain;
        private System.Windows.Forms.CheckBox chkIsSup;
        private System.Windows.Forms.CheckBox chkIsInf;
        private System.Windows.Forms.NumericUpDown numSup;
        private System.Windows.Forms.NumericUpDown numInf;
    }
}
