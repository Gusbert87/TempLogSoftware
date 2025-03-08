using System;
using System.Data;
using System.Windows.Forms;
using Serial;
using ApplicationSettings;
using FileManager;

namespace View
{
    public partial class MainForm : Form
    {
        private DataTable dataTable;
        public delegate void refreshGrid();

        public MainForm()
        {
            InitializeComponent();
            dataTable = new DataTable();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            attempConnection();
        }

        private void setComponents(bool enable)
        {
            mnuConnect.Enabled = !enable;
            mnuSaveAs.Enabled = enable;
            mnuLoad.Enabled = enable;
            mnuStartAcquisition.Enabled = enable;
            grdTable.Enabled = enable;
            if (enable)
            {
                dataTable.Columns.Add("Time");
                for (int i = 0; i < ApplicationSettings.GlobalSettings.SerialSettings.N; i++)
                {
                    dataTable.Columns.Add("Temp " + i);
                }
                grdTable.DataSource = dataTable;
            }
        }

        private void attempConnection()
        {
            showConnectionDialog();
            bool connected = SerialThread.ConnectedInstance.isConnected;
            if (connected)
            {
                SerialThread.LastInstance.temperatureArrivedHandler += temperatureArrived;
            }
            setComponents(connected);
        }

        private void temperatureArrived(T t)
        {
            DataRow dataRow = dataTable.NewRow();

            dataRow.ItemArray = new object[ApplicationSettings.GlobalSettings.SerialSettings.N];
            dataRow[0] = DateTime.Now.TimeOfDay;
            for(int i=0; i< ApplicationSettings.GlobalSettings.SerialSettings.N; i++)
            {
                dataRow[i+1] = t[i];
            }

            dataTable.Rows.Add(dataRow);
            grdTable.BeginInvoke(new refreshGrid(grdTable.Refresh));
        }

        private bool showConnectionDialog()
        {
            using (ConnectForm connectDialog = new ConnectForm())
            {
                DialogResult result = connectDialog.ShowDialog();
                switch(result)
                {
                    case DialogResult.OK:
                        return true;
                    default:
                        return false;
                }
            }
        }

        private new void Closing(object sender, FormClosingEventArgs e)
        {
            if (SerialThread.ConnectedInstance.isConnected)
            {
                SerialThread.ConnectedInstance.Close();
            }
        }

        private void mnuConnectClick(object sender, EventArgs e)
        {
            if(!SerialThread.ConnectedInstance.isConnected)
            {
                attempConnection();
            }
        }

        private void mnuExitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuStartAcquisitionClick(object sender, EventArgs e)
        {
            SerialTemperaturePolling.startTemperaturePolling();
            SaveScheduler.StartSaveScheduler(dataTable);
            SaveScheduler.SavedEvent += SavedEvent;
            
            mnuStartAcquisition.Enabled = false;
            mnuStopAcquisition.Enabled = true;
        }

        private void SavedEvent()
        {
            grdTable.BeginInvoke( new refreshGrid(() => { dataTable.Clear(); grdTable.Refresh(); }));
        }

        private void mnuSaveClick(object sender, EventArgs e)
        {
            
        }

        private void mnuStopAcquisitionClick(object sender, EventArgs e)
        {
            SaveScheduler.StopSaveScheduler();
            SerialTemperaturePolling.stopTemperaturePolling();
            mnuStartAcquisition.Enabled = true;
            mnuStopAcquisition.Enabled = false;
        }

        private void mnuSaveAsClick(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveFile()
        {
            string fileName = showFileDialog();
            StaticFileManager.SaveFile(fileName, dataTable);
        }

        private string showFileDialog()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Comma separated value|*.csv";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();
            return saveFileDialog1.FileName;
        }
    }

    public static class ToolBarMessages
    {
        public const String CONNECTED = "Connected";
        public const String NOT_CONNECTED = "Not connected";
        public const String ACQUIRING_DATA = "Acquiring data";
    }

    public enum Status
    {
        connected, notConnected, acquiring, setting
    }
}
