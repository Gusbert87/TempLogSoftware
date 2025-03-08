using System;
using System.Threading;
using ApplicationSettings;
using System.Collections.Generic;

namespace Serial
{

    public class SerialThread
    {
        #region Public

        public event SettingsArrivedHandler settingsArrivedHandler
        {
            add { this.serialCom.settingsArrivedHandler += value; }
            remove { this.serialCom.settingsArrivedHandler -= value; }
        }
        public event TemperatureArrivedHandler temperatureArrivedHandler
        {
            add { this.serialCom.temperatureArrivedHandler += value; }
            remove { this.serialCom.temperatureArrivedHandler -= value; }
        }
        public event RawDataArrivedHandler rawDataArrivedHandler
        {
            add { this.serialCom.rawDataArrivedHandler += value; }
            remove { this.serialCom.rawDataArrivedHandler -= value; }
        }
        public event NoDataArrivedHandler noDataArrivedHandler
        {
            add { this.serialCom.noDataArrivedHandler += value; }
            remove { this.serialCom.noDataArrivedHandler -= value; }
        }
        public event ReadyArrivedHandler readyArrivedHandler
        {
            add { this.serialCom.readyArrivedHandler += value; }
            remove { this.serialCom.readyArrivedHandler -= value; }
        }
        public event OpenHandler openHandler
        {
            add { this.serialCom.openHandler += value; }
            remove { this.serialCom.openHandler -= value; }
        }
        public event ConnectedHandler connectedHandler
        {
            add { this.serialCom.connectedHandler += value; }
            remove { this.serialCom.connectedHandler -= value; }
        }

        private static readonly SerialThread instance = new SerialThread();

        public static SerialThread Instance { get { return instance; } }

        protected SerialThread()
        {
            serialCom = SerialCom.Instance;

        }

        private Thread getNewThread()
        {
            Thread readThread = new Thread(readProcess);
            readThread.IsBackground = true;
            return readThread;
        }

        private static Object serialComToken = new Object();

        private Boolean cancelToken = false;

        public Boolean CancelToken { get { return cancelToken; } }

        public void Connect(String portName)
        {
            Open(portName);
            StartReadThread();
        }

        public virtual void Open(String portName)
        {
            serialCom.Open(portName);
        }

        public virtual void Close()
        {
            lock (serialComToken)
            {
                if (!readThread.IsAlive)
                {
                    serialCom.Close();
                }
            }
            cancelToken = true;
            readThread.Abort();
        }

        public virtual void StartReadThread()
        {
            cancelToken = false;
            readThread = getNewThread();
            readThread.Start(cancelToken);
        }

        public virtual void StopReadThread()
        {
            throw new Exception();
        }

        public virtual void SendTemperatureRequest()
        {
            lock (serialComToken)
            {
                serialCom.SendTemperatureRequest();
            }
        }

        public virtual void SendSettingsRequest()
        {
            lock (serialComToken)
            {
                serialCom.SendSettingsRequest();
            }
        }

        public virtual void SendSettings(CUSettings settings)
        {
            lock (serialComToken)
            {
                serialCom.SendSettings(settings);
            }
        }

        public virtual void SendCalibrationData(CalibrationData calibrationData)
        {
            lock (serialComToken)
            {
                serialCom.SendCalibrationData(calibrationData);
            }
        }

        public virtual bool isConnected
        {
            get
            {
                return serialCom.isConnected;
            }
        }

        public virtual bool SettingsArrived
        {
            get
            {
                return serialCom.SettingsArrived;
            }
        }

        public virtual bool isNull()
        {
            return false;
        }

        #endregion

        #region Private
        private SerialCom serialCom;
        private Thread readThread;
        private Object readToken = new Object();

        private void readProcess(object parameter)
        {
            Boolean cToken = (Boolean)parameter;

            while (!cToken)
            {
                try
                {
                    lock (serialComToken)
                    {
                        serialCom.GetData();
                    }
                }
                catch (ThreadAbortException)
                {
                    serialCom.Close();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Exception in the serial thread: {0}", ex.Message);
                    throw ex;
                }
            }
            lock (serialComToken)
            {
                serialCom.Close();
            }
        }

        #endregion
    }
}
