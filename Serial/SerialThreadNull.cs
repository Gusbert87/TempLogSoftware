using System;
using ApplicationSettings;

namespace Serial
{
    class SerialThreadNull : SerialThread
    {
        private static SerialThreadNull instance;
        private static object locker = new object();

        public static new SerialThreadNull Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new SerialThreadNull();
                        }
                    }
                }
                return instance;
            }
        }

        private SerialThreadNull()
        { }

        public override void Open(String portName)
        {
        }

        public override void Close()
        {
        }

        public override void StartReadThread()
        {
        }

        public override void SendTemperatureRequest()
        {
        }

        public override void SendSettingsRequest()
        {
        }

        public override void SendSettings(CUSettings settings)
        {
        }

        public override void SendCalibrationData(CalibrationData calibrationData)
        {
        }

        public override bool isNull()
        {
            return true;
        }

        public override bool isConnected
        {
            get
            {
                return false;
            }
        }
    }
}
