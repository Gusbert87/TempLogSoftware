namespace View.Controls.SettingsPanel
{
    partial class ControlUnitSettingsPanel
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
            this.pnlTableMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblNumChannels = new System.Windows.Forms.Label();
            this.numNumChannels = new System.Windows.Forms.NumericUpDown();
            this.pnlTableMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumChannels)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTableMain
            // 
            this.pnlTableMain.ColumnCount = 2;
            this.pnlTableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.pnlTableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlTableMain.Controls.Add(this.lblNumChannels, 0, 0);
            this.pnlTableMain.Controls.Add(this.numNumChannels, 1, 0);
            this.pnlTableMain.Location = new System.Drawing.Point(3, 3);
            this.pnlTableMain.MinimumSize = new System.Drawing.Size(414, 25);
            this.pnlTableMain.Name = "pnlTableMain";
            this.pnlTableMain.RowCount = 1;
            this.pnlTableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlTableMain.Size = new System.Drawing.Size(414, 25);
            this.pnlTableMain.TabIndex = 0;
            // 
            // lblNumChannels
            // 
            this.lblNumChannels.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNumChannels.AutoSize = true;
            this.lblNumChannels.Location = new System.Drawing.Point(81, 6);
            this.lblNumChannels.Name = "lblNumChannels";
            this.lblNumChannels.Size = new System.Drawing.Size(86, 13);
            this.lblNumChannels.TabIndex = 0;
            this.lblNumChannels.Text = "Numero di canali";
            // 
            // numNumChannels
            // 
            this.numNumChannels.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numNumChannels.Location = new System.Drawing.Point(173, 3);
            this.numNumChannels.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numNumChannels.Name = "numNumChannels";
            this.numNumChannels.Size = new System.Drawing.Size(88, 20);
            this.numNumChannels.TabIndex = 1;
            this.numNumChannels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numNumChannels.ValueChanged += new System.EventHandler(this.numNumChannelsValueChanged);
            // 
            // ControlUnitSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTableMain);
            this.MinimumSize = new System.Drawing.Size(420, 33);
            this.Name = "ControlUnitSettingsPanel";
            this.Size = new System.Drawing.Size(420, 33);
            this.Load += new System.EventHandler(this.ControlUnitSettingsPanelLoad);
            this.pnlTableMain.ResumeLayout(false);
            this.pnlTableMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumChannels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlTableMain;
        private System.Windows.Forms.Label lblNumChannels;
        private System.Windows.Forms.NumericUpDown numNumChannels;
    }
}
