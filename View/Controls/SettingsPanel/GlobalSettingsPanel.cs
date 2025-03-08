using System;
using System.Windows.Forms;
using ApplicationSettings;
using Serial;
using System.IO;

namespace View.Controls.SettingsPanel
{
    public partial class GlobalSettingsPanel : SettingsPanelImpl
    {
        public GlobalSettingsPanel()
        {
            InitializeComponent();
        }

        private void GlobalSettingsPanelLoad(object sender, EventArgs e)
        {
            Init();
            loaded = true;
        }

        public override bool setVisible(bool visible)
        {
            DialogResult result = DialogResult.OK;
            if (!visible && Visible)
            {
                if(settingsChanged)
                    result = askSaveSettings();

                if (result != DialogResult.Cancel)
                    Visible = false;
            }
            else
            {
                Visible = true;
            }
            return Visible;
        }

        public override void loadSettings()
        {
            string[] ports = SerialUtils.GetSerialPortNames();
            string defaultPort = (string)GlobalSettings.getProperty(GlobalSettings.SERIAL_PORT);
            int index = Array.IndexOf(ports, defaultPort);


            if (ports.Length == 0)
            {
                ports = new string[1];
                ports[0] = "No ports found";
            }

            //int index = this.cbxPort.FindStringExact(defaultPort);
            if (index != -1 || "".Equals(defaultPort))
            {
                this.cbxPort.DataSource = ports;
                this.cbxPort.SelectedIndex = (index==-1 ? 0 : index);
            }
            else
            {
                string[] allPorts = new string[ports.Length+1];
                allPorts[0] = defaultPort;
                for(int i=0; i<ports.Length; i++)
                {
                    allPorts[i + 1] = ports[i];
                }
                this.cbxPort.DataSource = allPorts;
                this.cbxPort.SelectedIndex = 0;
            }
            Array pollingIntervals = Enum.GetValues(typeof(GlobalSettings.TEMPERATURE_INTERVAL));
            int pollingInterval = (int)GlobalSettings.getProperty(GlobalSettings.TEMPERATURE_POLLING_INTERVAL);
            GlobalSettings.TEMPERATURE_INTERVAL enumPollingInterval = (GlobalSettings.TEMPERATURE_INTERVAL)pollingInterval;
            index = Array.IndexOf(pollingIntervals, enumPollingInterval);
            if (index != -1) this.cbxPollingInterval.SelectedIndex = index;

            this.chkConnectOnStart.Checked = (bool)GlobalSettings.getProperty(GlobalSettings.CONNECT_ON_START);

            TimeSpan timeSpan = (TimeSpan)GlobalSettings.getProperty(GlobalSettings.SAVE_INTERVAL);
            DateTime timeInterval = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            this.txtSaveInterval.Text = String.Format("{0:00}", timeSpan.Hours + 24*timeSpan.Days ) + ":" + String.Format("{0:00}", timeSpan.Minutes);

            dtpSaveDate.Value = (DateTime)GlobalSettings.getProperty(GlobalSettings.SAVE_DATE);

            fslSaveFolder.Folder = (String)GlobalSettings.getProperty(GlobalSettings.SAVE_FOLDER);
        }

        public DialogResult askSaveSettings()
        {
            DialogResult dialogResult = MessageBox.Show("Vuoi salvare le impostazioni?", "Impostazioni cambiate", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                saveSettings();
                settingsChanged = false;
            }
            return dialogResult;
        }

        public override void saveSettings()
        {
            String newSerialPort = cbxPort.Text;
            bool newConnectOnStart = chkConnectOnStart.Checked;

            int newPollingInterval = getNewPollingInterval();

            TimeSpan newSaveInterval = getTimeSpanFromSaveInterval();//this.dtpSaveInterval.Value.TimeOfDay;

            DateTime newSaveDate = this.dtpSaveDate.Value;
            newSaveDate.AddMilliseconds(-newSaveDate.Millisecond);
            newSaveDate.AddSeconds(-newSaveDate.Second);

            String newSaveFolder = this.fslSaveFolder.Folder;

            GlobalSettings.setProperty(GlobalSettings.SERIAL_PORT, newSerialPort);
            GlobalSettings.setProperty(GlobalSettings.CONNECT_ON_START, chkConnectOnStart.Checked);

            GlobalSettings.setProperty(GlobalSettings.TEMPERATURE_POLLING_INTERVAL, newPollingInterval );

            GlobalSettings.setProperty(GlobalSettings.SAVE_INTERVAL, newSaveInterval);
            if(this.chkSaveDate.Checked) GlobalSettings.setProperty(GlobalSettings.SAVE_DATE, newSaveDate);
            else GlobalSettings.setProperty(GlobalSettings.SAVE_DATE, DateTime.Now);

            GlobalSettings.setProperty(GlobalSettings.SAVE_FOLDER, fslSaveFolder.Folder);

            settingsChanged = false;
        }

        private void Init()
        {
            loadSettings();
        }

        private TimeSpan getTimeSpanFromSaveInterval()
        {
            String interval = txtSaveInterval.Text;
            string[] time = interval.Split(':');
            return new TimeSpan( int.Parse(time[0]), int.Parse(time[1]), 0);//this.dtpSaveInterval.Value.TimeOfDay;
        }

        public override bool isSettingsChanged()
        {
            String newSerialPort = cbxPort.Text;
            bool newConnectOnStart = chkConnectOnStart.Checked;
            int newPollingInterval = getNewPollingInterval();
            TimeSpan newSaveInterval = getTimeSpanFromSaveInterval();
            DateTime newSaveDate = this.dtpSaveDate.Value;
            String newSaveFolder = this.fslSaveFolder.Folder;

            String serialPort = (string)GlobalSettings.getProperty(GlobalSettings.SERIAL_PORT);
            bool connectOnStart = (bool)GlobalSettings.getProperty(GlobalSettings.CONNECT_ON_START);
            int pollingInterval = (int)GlobalSettings.getProperty(GlobalSettings.TEMPERATURE_POLLING_INTERVAL);
            TimeSpan saveInterval = (TimeSpan)GlobalSettings.getProperty(GlobalSettings.SAVE_INTERVAL);
            DateTime saveDate = (DateTime)GlobalSettings.getProperty(GlobalSettings.SAVE_DATE);
            String saveFolder = (String)GlobalSettings.getProperty(GlobalSettings.SAVE_FOLDER);

            if (    
                    serialPort.Equals(newSerialPort) || 
                    connectOnStart.Equals(connectOnStart) || 
                    pollingInterval.Equals(newPollingInterval) ||
                    saveInterval.Equals(newSaveInterval) ||
                    saveDate.Equals(newSaveDate) ||
                    saveFolder.Equals(newSaveFolder)
               )
                return true;

            return false;
        }

        private int getNewPollingInterval()
        {
            Array pollingIntervals = Enum.GetValues(typeof(GlobalSettings.TEMPERATURE_INTERVAL));
            return (int)pollingIntervals.GetValue(cbxPollingInterval.SelectedIndex);
        }

        private void cbxPortSelectedIndexChanged(object sender, EventArgs e)
        {
            componentChanged();
        }

        private void chkConnectOnStartCheckedChanged(object sender, EventArgs e)
        {
            componentChanged();
        }

        private void cbxPollingIntervalSelectedIndexChanged(object sender, EventArgs e)
        {
            componentChanged();
        }

        private void dtpSaveIntervalValueChanged(object sender, EventArgs e)
        {
            componentChanged();
        }

        private void chkSaveDateCheckedChanged(object sender, EventArgs e)
        {
            componentChanged();
        }

        private void dtpSaveDateValueChanged(object sender, EventArgs e)
        {
            componentChanged();
            chkSaveDate.Checked = true;
        }

        private void fslSaveFolderModifiedChanged(object sender, EventArgs e)
        {
            componentChanged();
        }
    }
}
