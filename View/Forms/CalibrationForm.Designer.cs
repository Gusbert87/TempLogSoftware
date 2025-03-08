namespace View.Forms
{
    partial class CalibrationForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTableMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblCanale = new System.Windows.Forms.Label();
            this.lblValoreAttuale = new System.Windows.Forms.Label();
            this.lblNuovoValore = new System.Windows.Forms.Label();
            this.cbxCanale1 = new System.Windows.Forms.CheckBox();
            this.lblValore1 = new System.Windows.Forms.Label();
            this.numNuovoValore1 = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.pnlTableMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNuovoValore1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(172, 89);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(43, 26);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOkClick);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(296, 89);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(58, 26);
            this.btnApply.TabIndex = 7;
            this.btnApply.Text = "&Applica";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApplyClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(221, 89);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 26);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancella";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pnlTableMain);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 89);
            this.panel1.TabIndex = 9;
            // 
            // pnlTableMain
            // 
            this.pnlTableMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pnlTableMain.ColumnCount = 3;
            this.pnlTableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlTableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.pnlTableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.pnlTableMain.Controls.Add(this.lblCanale, 0, 0);
            this.pnlTableMain.Controls.Add(this.lblValoreAttuale, 1, 0);
            this.pnlTableMain.Controls.Add(this.lblNuovoValore, 2, 0);
            this.pnlTableMain.Controls.Add(this.cbxCanale1, 0, 1);
            this.pnlTableMain.Controls.Add(this.lblValore1, 1, 1);
            this.pnlTableMain.Controls.Add(this.numNuovoValore1, 2, 1);
            this.pnlTableMain.Location = new System.Drawing.Point(3, 3);
            this.pnlTableMain.Name = "pnlTableMain";
            this.pnlTableMain.RowCount = 2;
            this.pnlTableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlTableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.pnlTableMain.Size = new System.Drawing.Size(359, 80);
            this.pnlTableMain.TabIndex = 0;
            // 
            // lblCanale
            // 
            this.lblCanale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblCanale.AutoSize = true;
            this.lblCanale.Location = new System.Drawing.Point(40, 1);
            this.lblCanale.Name = "lblCanale";
            this.lblCanale.Size = new System.Drawing.Size(40, 50);
            this.lblCanale.TabIndex = 0;
            this.lblCanale.Text = "Canale";
            this.lblCanale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValoreAttuale
            // 
            this.lblValoreAttuale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblValoreAttuale.AutoSize = true;
            this.lblValoreAttuale.Location = new System.Drawing.Point(142, 1);
            this.lblValoreAttuale.Name = "lblValoreAttuale";
            this.lblValoreAttuale.Size = new System.Drawing.Size(73, 50);
            this.lblValoreAttuale.TabIndex = 1;
            this.lblValoreAttuale.Text = "Valore Attuale";
            this.lblValoreAttuale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNuovoValore
            // 
            this.lblNuovoValore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblNuovoValore.AutoSize = true;
            this.lblNuovoValore.Location = new System.Drawing.Point(262, 1);
            this.lblNuovoValore.Name = "lblNuovoValore";
            this.lblNuovoValore.Size = new System.Drawing.Size(72, 50);
            this.lblNuovoValore.TabIndex = 2;
            this.lblNuovoValore.Text = "Nuovo Valore";
            this.lblNuovoValore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxCanale1
            // 
            this.cbxCanale1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbxCanale1.AutoSize = true;
            this.cbxCanale1.Location = new System.Drawing.Point(48, 57);
            this.cbxCanale1.Name = "cbxCanale1";
            this.cbxCanale1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbxCanale1.Size = new System.Drawing.Size(68, 17);
            this.cbxCanale1.TabIndex = 3;
            this.cbxCanale1.Text = "Canale 1";
            this.cbxCanale1.UseVisualStyleBackColor = true;
            // 
            // lblValore1
            // 
            this.lblValore1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblValore1.AutoSize = true;
            this.lblValore1.Location = new System.Drawing.Point(165, 52);
            this.lblValore1.Name = "lblValore1";
            this.lblValore1.Size = new System.Drawing.Size(28, 27);
            this.lblValore1.TabIndex = 4;
            this.lblValore1.Text = "33.5";
            this.lblValore1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numNuovoValore1
            // 
            this.numNuovoValore1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.numNuovoValore1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numNuovoValore1.Location = new System.Drawing.Point(267, 55);
            this.numNuovoValore1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numNuovoValore1.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numNuovoValore1.Name = "numNuovoValore1";
            this.numNuovoValore1.Size = new System.Drawing.Size(63, 20);
            this.numNuovoValore1.TabIndex = 5;
            // 
            // CalibrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 127);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CalibrationForm";
            this.Text = "CalibrationForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalibrationFormClosing);
            this.Load += new System.EventHandler(this.CalibrationFormLoad);
            this.panel1.ResumeLayout(false);
            this.pnlTableMain.ResumeLayout(false);
            this.pnlTableMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNuovoValore1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel pnlTableMain;
        private System.Windows.Forms.Label lblCanale;
        private System.Windows.Forms.Label lblValoreAttuale;
        private System.Windows.Forms.Label lblNuovoValore;
        private System.Windows.Forms.CheckBox cbxCanale1;
        private System.Windows.Forms.Label lblValore1;
        private System.Windows.Forms.NumericUpDown numNuovoValore1;
    }
}