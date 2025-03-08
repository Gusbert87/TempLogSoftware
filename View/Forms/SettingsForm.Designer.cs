namespace View.Forms
{
    partial class SettingsForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("TempLog");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Nodo0");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Nodo1");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Centralina", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            this.trvSettings = new System.Windows.Forms.TreeView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlGlobalSettingsPanel = new View.Controls.SettingsPanel.GlobalSettingsPanel();
            this.pnlControlUnitSettingsPanel = new View.Controls.SettingsPanel.ControlUnitSettingsPanel();
            this.SuspendLayout();
            // 
            // trvSettings
            // 
            this.trvSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trvSettings.Location = new System.Drawing.Point(0, 0);
            this.trvSettings.Name = "trvSettings";
            treeNode1.Name = "GlobalSettings";
            treeNode1.Text = "TempLog";
            treeNode2.Name = "Nodo0";
            treeNode2.Text = "Nodo0";
            treeNode3.Name = "Nodo1";
            treeNode3.Text = "Nodo1";
            treeNode4.Name = "ControlUnitSettings";
            treeNode4.Text = "Centralina";
            this.trvSettings.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4});
            this.trvSettings.Size = new System.Drawing.Size(122, 307);
            this.trvSettings.TabIndex = 2;
            this.trvSettings.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvSettingsBeforeExpand);
            this.trvSettings.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvSettingsBeforeSelect);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(405, 313);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancella";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancelClick);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(480, 313);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(58, 26);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "&Applica";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApplyClick);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(356, 313);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(43, 26);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOkClick);
            // 
            // pnlGlobalSettingsPanel
            // 
            this.pnlGlobalSettingsPanel.Location = new System.Drawing.Point(128, 0);
            this.pnlGlobalSettingsPanel.MinimumSize = new System.Drawing.Size(420, 143);
            this.pnlGlobalSettingsPanel.Name = "pnlGlobalSettingsPanel";
            this.pnlGlobalSettingsPanel.SettingsChanged = false;
            this.pnlGlobalSettingsPanel.Size = new System.Drawing.Size(420, 235);
            this.pnlGlobalSettingsPanel.TabIndex = 6;
            // 
            // pnlControlUnitSettingsPanel
            // 
            this.pnlControlUnitSettingsPanel.Location = new System.Drawing.Point(128, 0);
            this.pnlControlUnitSettingsPanel.MinimumSize = new System.Drawing.Size(420, 33);
            this.pnlControlUnitSettingsPanel.Name = "pnlControlUnitSettingsPanel";
            this.pnlControlUnitSettingsPanel.SettingsChanged = false;
            this.pnlControlUnitSettingsPanel.Size = new System.Drawing.Size(420, 33);
            this.pnlControlUnitSettingsPanel.TabIndex = 7;
            this.pnlControlUnitSettingsPanel.Visible = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 348);
            this.Controls.Add(this.pnlControlUnitSettingsPanel);
            this.Controls.Add(this.pnlGlobalSettingsPanel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.trvSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsFormClosing);
            this.Load += new System.EventHandler(this.SettingsFormLoad);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView trvSettings;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnOk;
        private Controls.SettingsPanel.GlobalSettingsPanel pnlGlobalSettingsPanel;
        private Controls.SettingsPanel.ControlUnitSettingsPanel pnlControlUnitSettingsPanel;
    }
}