using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Serial;

namespace View
{
    public partial class ConnectingDialog : Form
    {
        private string portName;
        private bool connected;

        public ConnectingDialog(string portName)
        {
            InitializeComponent();
            this.portName = portName;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            SerialConnector serialConnector = new SerialConnector();
            connectionWorker.DoWork += serialConnector.connectThread; //ConnectionWorker_DoWork;
            //SerialConnector.Instance.connectThread;
            connectionWorker.WorkerReportsProgress = true;
            serialConnector.updateProgress += connectionWorker.ReportProgress;
            serialConnector.endProcess += serialConnectorCompleted;
            connectionWorker.ProgressChanged += ProgressChanged;
            connectionWorker.RunWorkerCompleted += WorkerCompleted;
            connectionWorker.RunWorkerAsync(portName);
        }

        private void serialConnectorCompleted(bool connected)
        {
            this.connected = connected;
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int percentage = e.ProgressPercentage;
            pgbStatus.Value = e.ProgressPercentage;
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (connected)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show("Unable to connect to " + portName, "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
