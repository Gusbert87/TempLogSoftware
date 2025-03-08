namespace View.Forms
{
    partial class ViewLogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewLogForm));
            this.grdTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTable
            // 
            this.grdTable.AllowUserToAddRows = false;
            this.grdTable.AllowUserToDeleteRows = false;
            this.grdTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTable.Location = new System.Drawing.Point(0, 0);
            this.grdTable.Name = "grdTable";
            this.grdTable.ReadOnly = true;
            this.grdTable.RowHeadersVisible = false;
            this.grdTable.Size = new System.Drawing.Size(576, 341);
            this.grdTable.TabIndex = 3;
            // 
            // ViewLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 341);
            this.Controls.Add(this.grdTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewLogForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ViewLogFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdTable;
    }
}