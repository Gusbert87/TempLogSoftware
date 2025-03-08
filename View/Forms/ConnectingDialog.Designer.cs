namespace View.Forms
{
    partial class ConnectingDialog
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
            this.pgbStatus = new System.Windows.Forms.ProgressBar();
            this.lblConnect = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.connectionWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // pgbStatus
            // 
            this.pgbStatus.Location = new System.Drawing.Point(79, 12);
            this.pgbStatus.Name = "pgbStatus";
            this.pgbStatus.Size = new System.Drawing.Size(272, 23);
            this.pgbStatus.TabIndex = 0;
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Location = new System.Drawing.Point(12, 12);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(61, 13);
            this.lblConnect.TabIndex = 1;
            this.lblConnect.Text = "Connecting";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(276, 41);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancelClick);
            // 
            // ConnectingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 73);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblConnect);
            this.Controls.Add(this.pgbStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConnectingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConnectingDialog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClose);
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbStatus;
        private System.Windows.Forms.Label lblConnect;
        private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.BackgroundWorker connectionWorker;
    }
}