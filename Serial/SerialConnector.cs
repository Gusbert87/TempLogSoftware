using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationSettings;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;

namespace Serial
{
    public delegate void UpdateProgressHandler(int percentage);
    public delegate void EndProcessHandler(bool connected);
    public delegate void ErrorProcessHandler(Exception exception);

    public class SerialConnector
    {
     
        private const int TIMER_INTERVAL = 100;
        public event UpdateProgressHandler updateProgress;
        public event EndProcessHandler endProcess;
        public event ErrorProcessHandler errorProcessHandler;

        private System.Threading.Timer updateTimer;
        private bool settingsOk;
        private int timeout;
        private int currentTime;
        private SerialThread serialThread;

        public bool SettingsOk
        {
            get
            {
                return settingsOk;
            }
        }

        public SerialConnector()
        {
            init();
        }

        public void init()
        {
            timeout = (int)(GlobalSettings.getProperty(GlobalSettings.CONNECTION_TIMEOUT));
            settingsOk = false;
            currentTime = 0;
        }

        public void connectThread(object sender, DoWorkEventArgs parameter)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
            string portName = (string)parameter.Argument;
            try
            {
                startConnection(portName);
            }
            catch (Exception e)
            {
                errorProcessHandler?.Invoke(e);
                backgroundWorker.CancelAsync();
            }

            updateTimer = new System.Threading.Timer(update, null, TIMER_INTERVAL, TIMER_INTERVAL);

            try
            {
                while (!settingsOk && currentTime < timeout)
                    if (backgroundWorker.CancellationPending == true)
                    {
                        updateTimer.Dispose();
                        parameter.Cancel = true;
                        return;
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the connect thread: {0}", ex.Message);
            }

            if(!settingsOk)
            {
                serialThread.Close();
            }

            updateTimer.Dispose();
            endProcess?.Invoke(settingsOk);
            updateProgress?.Invoke(currentTime * 100 / timeout);
        }

        private void update(Object state)
        {
            currentTime += TIMER_INTERVAL;
            updateProgress?.Invoke(currentTime*100 / timeout);
        }

        private void startConnection(string portName)
        {
            GlobalSettings.setProperty(GlobalSettings.SERIAL_PORT, portName);
            serialThread = SerialThread.Instance;
            serialThread.readyArrivedHandler += readyArrived;
            serialThread.settingsArrivedHandler += settingsArrived;
            serialThread.Open(portName);
            serialThread.StartReadThread();
        }

        private void settingsArrived(CUSettings settings)
        {
            GlobalSettings.SerialSettings = settings;
            settingsOk   = true;
            currentTime = (80 * timeout) / 100;
            updateProgress?.Invoke(currentTime * 100 / timeout);
        }

        private void readyArrived()
        {
            currentTime = (40 * timeout) / 100;
            serialThread.SendSettingsRequest();
            updateProgress?.Invoke(currentTime * 100 / timeout);
        }
    }
}
