using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Serial;

namespace View.Forms
{
    public partial class ConnectingDialog : Form
    {
        private string portName;
        private bool connected;
        private SerialConnector serialConnector;

        public ConnectingDialog(string portName)
        {
            InitializeComponent();
            this.portName = portName;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            serialConnector = new SerialConnector();
            connectionWorker.WorkerSupportsCancellation = true;
            connectionWorker.DoWork += serialConnector.connectThread; //ConnectionWorker_DoWork;
            //SerialConnector.Instance.connectThread;
            connectionWorker.WorkerReportsProgress = true;
            serialConnector.updateProgress += connectionWorker.ReportProgress;
            serialConnector.endProcess += serialConnectorCompleted;
            serialConnector.errorProcessHandler += serialConnectorError;
            connectionWorker.ProgressChanged += ProgressChanged;
            connectionWorker.RunWorkerCompleted += WorkerCompleted;
            connectionWorker.RunWorkerAsync(portName);
        }

        private void serialConnectorError(Exception exception)
        {
            this.BeginInvoke(new CrossAppDomainDelegate(this.Hide));
#if DEBUG
            
            MessageBox.Show(exception.ToString(), "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
            String message;
            if (exception is System.ArgumentException)
                message = "Porta COM non trovata";
            else
                message = exception.Message;
            
            MessageBox.Show(message, "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
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
                if (!e.Cancelled)
                {
                    this.BeginInvoke(new CrossAppDomainDelegate(this.Hide));
                    MessageBox.Show("Unable to connect to " + portName, "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static DialogResult showConnectingDialog(string portName)
        {
            using (ConnectingDialog connectingDialog = new ConnectingDialog(portName))
            {
                return connectingDialog.ShowDialog();
            }
        }

        private void btnCancelClick(object sender, EventArgs e)
        {
            connectionWorker.CancelAsync();
        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            connectionWorker.DoWork -= serialConnector.connectThread; //ConnectionWorker_DoWork;
            //SerialConnector.Instance.connectThread;
            serialConnector.updateProgress -= connectionWorker.ReportProgress;
            serialConnector.endProcess -= serialConnectorCompleted;
            serialConnector.errorProcessHandler -= serialConnectorError;
            connectionWorker.ProgressChanged -= ProgressChanged;
            connectionWorker.RunWorkerCompleted -= WorkerCompleted;
            connectionWorker.RunWorkerAsync(portName);
        }
    }
}
