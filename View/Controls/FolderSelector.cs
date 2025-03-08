using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace View.Controls
{
    public partial class FolderSelector : UserControl
    {
        public event EventHandler ModifiedChanged
        {
            add { this.txtFolder.ModifiedChanged += value; }
            remove { this.txtFolder.ModifiedChanged -= value; }
        }

        public String Folder
        {
            get
            {
                String folder = txtFolder.Text;
                if (!folder.EndsWith("\\"))
                {
                    folder += "\\";
                }
                return Path.GetFullPath(folder);
            }
            set
            {
                this.txtFolder.Text = value;
            }
        }

        public FolderSelector()
        {
            InitializeComponent();
            this.txtFolder.LostFocus += FolderModified;
        }

        private void FolderModified(object sender, EventArgs e)
        {
            try
            {
                Path.GetFullPath(txtFolder.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtFolder.Text = Environment.GetEnvironmentVariable("userprofile") + "\\documents";
                txtFolder.Focus();
            }
        }

        private void btnFolderClick(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = txtFolder.Text;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String folderName = folderBrowserDialog.SelectedPath;
                txtFolder.Text = folderName;
            }
        }
    }
}
