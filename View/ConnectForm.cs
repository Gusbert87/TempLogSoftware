using System;
using System.Windows.Forms;
using Serial;
using ApplicationSettings;

namespace View
{
    public partial class ConnectForm : Form
    {
        private String selectedPort;
        public String SelectedPort { get { return selectedPort; } }

        public ConnectForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            Init();
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
        }

        private void btnConnectClick(object sender, EventArgs e)
        {
            this.Hide();
            this.DialogResult = startConnectingDialog(selectedPort);
            if(this.DialogResult == DialogResult.OK)
            {

            }
        }

        private DialogResult startConnectingDialog(string portName)
        {
            using (ConnectingDialog connectingDialog = new ConnectingDialog(portName))
            {
                return connectingDialog.ShowDialog();
            }
        }

        private void cbxPortValueChanged(object sender, EventArgs e)
        {
            selectedPort = cbxPort.Text;
        }
    }
}
