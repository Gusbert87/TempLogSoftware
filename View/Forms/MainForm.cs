using System;
using System.Data;
using System.Windows.Forms;
using Serial;
using ApplicationSettings;
using FileManager;

namespace View.Forms
{
    public partial class MainForm : Form
    {
        private DataTable dataTable;
        public delegate void RefreshGrid();
        public delegate void UpdateConnectionMenus();
        public delegate void UpdatePollingMenus();

        public MainForm()
        {
            InitializeComponent();
            dataTable = new DataTable();

            /*Type dgvType = grdTable.GetType();
            System.Reflection.PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi.SetValue(grdTable, true, null);*/
        }

        private void FormLoad(object sender, EventArgs e)
        {
            if ((bool)GlobalSettings.getProperty(GlobalSettings.CONNECT_ON_START))
                ViewUtils.attempConnection(true);
        }

        private void setConnectionComponents(bool connected)
        {
            try
            {
                if (!this.IsDisposed) Invoke(new UpdateConnectionMenus(() =>
                 {
                     mnuConnect.Checked = !connected;
                     mnuConnect.CheckState = (connected ? CheckState.Checked : CheckState.Unchecked);
                     mnuSaveAs.Enabled = connected;
                     mnuLoad.Enabled = connected;
                     mnuAcquisition.Enabled = connected;
                     grdTable.Enabled = connected;
                     if (connected)
                     {
                         setGridTable();
                         setCalibrationMenu();
                     }
                     else
                     {
                         mnuCalibration.DropDownItems.Clear();
                     }
                 }));
            } catch
            {
                return;
            }
        }

        private void setGridTable()
        {
            if (grdTable.Columns.Count != GlobalSettings.SerialSettings.N + 1)
            {
                clearTable();
                grdTable.DataSource = dataTable;
                dataTable.Columns.Clear();

                dataTable.Columns.Add("Ora");
                grdTable.Columns[0].Width = 70;

                grdTable.Columns[0].DefaultCellStyle.Font = new System.Drawing.Font(grdTable.Font, System.Drawing.FontStyle.Bold);
                grdTable.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                for (int i = 0; i < GlobalSettings.SerialSettings.N; i++)
                {
                    dataTable.Columns.Add("T" + i);
                    grdTable.Columns[i + 1].Width = 60;
                    grdTable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                grdTable.Refresh();
            }
        }

        private void setCalibrationMenu()
        {
            ToolStripItem[] mnuCalibrationChannel = new ToolStripItem[GlobalSettings.SerialSettings.N];
            for (int i = 0; i < GlobalSettings.SerialSettings.N; i++)
            {
                mnuCalibrationChannel[i] = new ToolStripMenuItem();
                mnuCalibrationChannel[i].Name = "mnuCalibrationChannel" + i;
                mnuCalibrationChannel[i].Size = new System.Drawing.Size(152, 22);
                mnuCalibrationChannel[i].Text = "Canale " + i;
                int channel = i;
                mnuCalibrationChannel[i].Click += (object sender, EventArgs e) =>
                    {
                        CalibrationForm calibrationForm = new CalibrationForm(channel);
                        calibrationForm.ShowDialog();
                        calibrationForm.Dispose();
                    };
            }
            mnuCalibration.DropDownItems.AddRange(mnuCalibrationChannel);
        }

        private void setPollingComponents(bool isPolling)
        {
            Invoke(new UpdatePollingMenus(() =>
            {
                mnuAcquisition.Checked = isPolling;
                mnuAcquisition.CheckState = (isPolling ? CheckState.Checked : CheckState.Unchecked);
                mnuSettings.Enabled = !isPolling;
                mnuCalibration.Enabled = !isPolling;
            }));
        }

        private void temperatureArrived(T t)
        {
            DataRow dataRow = dataTable.NewRow();
            dataRow.ItemArray = new object[GlobalSettings.SerialSettings.N + 1];
            dataTable.Rows.Add(dataRow);

            TimeSpan ts = DateTime.Now.TimeOfDay;
            dataRow[0] = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);//DateTime.Now.TimeOfDay;
            for (int i = 0; i < GlobalSettings.SerialSettings.N; i++)
            {
                dataRow[i + 1] = t[i];
            }

            grdTable.Invoke(new RefreshGrid(grdTable.Refresh));
        }

        private new void Closing(object sender, FormClosingEventArgs e)
        {
            SerialThread.Instance.connectedHandler -= setConnectionComponents;
            SerialTemperaturePolling.pollingHandler -= setPollingComponents;

            stopAcquisition();

            if (SerialThread.Instance.isConnected)
            {
                SerialThread.Instance.Close();
            }

            SaveScheduler.Instance.StopTimer();
            SaveScheduler.Instance.saveDataHandler -= saveData;
        }

        public new void Dispose()
        {
            SerialThread.Instance.connectedHandler -= setConnectionComponents;
        }

        private void mnuConnectClick(object sender, EventArgs e)
        {
            if (!SerialThread.Instance.isConnected)
            {
                ViewUtils.attempConnection(false);
            }
            else
            {
                ViewUtils.disconnect();
            }
        }

        private void mnuExitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuStartAcquisitionClick(object sender, EventArgs e)
        {
            if (SerialTemperaturePolling.Instance.IsPolling)
                stopAcquisition();
            else
                startAcquisition();
        }

        private void startAcquisition()
        {
            SerialThread.Instance.temperatureArrivedHandler += temperatureArrived;
            SerialTemperaturePolling.Instance.startTemperaturePolling();
            SaveScheduler.Instance.StartTimer();
            SaveScheduler.Instance.saveDataHandler += saveData;
        }

        private void stopAcquisition()
        {
            SerialThread.Instance.temperatureArrivedHandler -= temperatureArrived;
            SerialTemperaturePolling.Instance.stopTemperaturePolling();
            SaveScheduler.Instance.StopTimer();
            SaveScheduler.Instance.saveDataHandler -= saveData;
        }

        private void saveData(DataTable dataTable)
        {
            dataTable.Merge(this.dataTable.Copy());
            Invoke(new Action(clearTable));
        }

        private void clearTable()
        {
            dataTable.Clear();
        }

        private void mnuStopAcquisitionClick(object sender, EventArgs e)
        {
            SerialTemperaturePolling.Instance.stopTemperaturePolling();
        }

        private void mnuSaveAsClick(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveFile()
        {
            string fileName = showSaveFileDialog();
            if (!String.IsNullOrEmpty(fileName))
            {
                FileSaver.Instance.SaveFile(fileName, dataTable);
            }
        }

        private string showSaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Comma separated value|*.csv";
            saveFileDialog.Title = "Salva il file di log";
            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;
            saveFileDialog.Dispose();
            return fileName;
        }

        private string showLoadFileDialog()
        {
            OpenFileDialog loadFileDialog = new OpenFileDialog();
            loadFileDialog.Filter = "Comma separated value|*.csv";
            loadFileDialog.Title = "Carica un file di log";
            loadFileDialog.ShowDialog();
            string fileName = loadFileDialog.FileName;
            loadFileDialog.Dispose();
            return fileName;
        }

        private void mnuImpostazioniClick(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
            settingsForm.Dispose();
        }

        private void mnuTaratureClick(object sender, EventArgs e)
        {
            CalibrationForm calibrationForm = new CalibrationForm();
            calibrationForm.ShowDialog();
            calibrationForm.Dispose();

        }

        private void MainFormShown(object sender, EventArgs e)
        {
            SerialThread.Instance.connectedHandler += setConnectionComponents;
            SerialTemperaturePolling.pollingHandler += setPollingComponents;
        }

        private void mnuLoadClick(object sender, EventArgs e)
        {
            string fileName = showLoadFileDialog();
            ViewLogForm viewLogForm = new ViewLogForm(fileName);
            viewLogForm.Show();
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
