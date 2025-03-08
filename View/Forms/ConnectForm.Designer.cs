using Serial;
using ApplicationSettings;

namespace View.Forms
{
    partial class ConnectForm
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
            this.cbxPort = new System.Windows.Forms.ComboBox();
            this.lblSerialPort = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkConnectOnStart = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbxPort
            // 
            this.cbxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPort.FormattingEnabled = true;
            this.cbxPort.Location = new System.Drawing.Point(73, 12);
            this.cbxPort.Name = "cbxPort";
            this.cbxPort.Size = new System.Drawing.Size(222, 21);
            this.cbxPort.TabIndex = 0;
            this.cbxPort.SelectedValueChanged += new System.EventHandler(this.cbxPortValueChanged);
            // 
            // lblSerialPort
            // 
            this.lblSerialPort.AutoSize = true;
            this.lblSerialPort.Location = new System.Drawing.Point(12, 15);
            this.lblSerialPort.Name = "lblSerialPort";
            this.lblSerialPort.Size = new System.Drawing.Size(55, 13);
            this.lblSerialPort.TabIndex = 1;
            this.lblSerialPort.Text = "Serial Port";
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConnect.Location = new System.Drawing.Point(220, 63);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnectClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(139, 63);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkShowOnStart
            // 
            this.chkConnectOnStart.AutoSize = true;
            this.chkConnectOnStart.Location = new System.Drawing.Point(73, 40);
            this.chkConnectOnStart.Name = "chkShowOnStart";
            this.chkConnectOnStart.Size = new System.Drawing.Size(98, 17);
            this.chkConnectOnStart.TabIndex = 4;
            this.chkConnectOnStart.Text = "mostra all\'avvio";
            this.chkConnectOnStart.UseVisualStyleBackColor = true;
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            if (isOnStart)
            {
                this.ClientSize = new System.Drawing.Size(307, 98);
                this.Controls.Add(this.chkConnectOnStart);
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(307, 78);
                this.btnCancel.Location = new System.Drawing.Point(139, 43);
                this.btnConnect.Location = new System.Drawing.Point(220, 43);
            }

            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lblSerialPort);
            this.Controls.Add(this.cbxPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect to Control Unit";
            this.Load += new System.EventHandler(this.FormLoad);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxPort;
        private System.Windows.Forms.Label lblSerialPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkConnectOnStart;
    }
}

