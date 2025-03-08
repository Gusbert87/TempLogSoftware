using System;
using System.Windows.Forms;
using Serial;
using ApplicationSettings;

namespace View.Forms
{
    public partial class ConnectForm : Form
    {
        private String selectedPort;
        private bool isOnStart;
        public String SelectedPort { get { return selectedPort; } }

        public ConnectForm( bool isOnStart )
        {
            this.isOnStart = isOnStart;
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            Init();
        }

        private new void Closing(object sender, FormClosingEventArgs e)
        {
        }

        private void Init()
        {
            string[] ports = SerialUtils.GetSerialPortNames();
            string defaultPort = (string)GlobalSettings.getProperty(GlobalSettings.SERIAL_PORT);

            this.cbxPort.DataSource = ports;
            int index = this.cbxPort.FindStringExact(defaultPort);
            if (index > 0)
            {
                this.cbxPort.SelectedIndex = index;
            }

            chkConnectOnStart.Checked = (bool)GlobalSettings.getProperty(GlobalSettings.CONNECT_ON_START);
        }

        private void btnConnectClick(object sender, EventArgs e)
        {
            GlobalSettings.setProperty(GlobalSettings.SERIAL_PORT, selectedPort);
            GlobalSettings.setProperty(GlobalSettings.CONNECT_ON_START, chkConnectOnStart.Checked);
            this.Hide();
            this.DialogResult = ConnectingDialog.showConnectingDialog(selectedPort);
            //this.Close();
        }

        private void cbxPortValueChanged(object sender, EventArgs e)
        {
            selectedPort = cbxPort.Text;
        }

        public static bool showConnectionForm(bool isOnStart)
        {
            using (ConnectForm connectForm = new ConnectForm(isOnStart))
            {
                DialogResult result = connectForm.ShowDialog();
                switch (result)
                {
                    case DialogResult.OK:
                        return true;
                    default:
                        return false;
                }
            }
        }
    }
}
