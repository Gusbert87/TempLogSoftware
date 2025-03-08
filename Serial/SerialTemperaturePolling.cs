using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using ApplicationSettings;

namespace Serial
{
    public delegate void PollingHandler(bool isPolling);
    public class SerialTemperaturePolling
    {
        public static event PollingHandler pollingHandler;

        private static Timer pollingTimer;
        private static bool isPolling = false;

        private static readonly SerialTemperaturePolling instance = new SerialTemperaturePolling();

        public static SerialTemperaturePolling Instance { get { return instance; } }

        public bool IsPolling { get { return isPolling; } }

        private SerialTemperaturePolling()
        {
            SerialThread.Instance.openHandler += connectHandler;
        }

        private void connectHandler(bool connected)
        {
            if (!connected) stopTemperaturePolling();
        }

        public void setInterval(double interval)
        {
            pollingTimer.Interval = interval;
        }

        public void startTemperaturePolling(int interval)
        {
            if (!SerialThread.Instance.SettingsArrived || IsPolling) return;

            pollingTimer = new Timer(interval);
            pollingTimer.AutoReset = true;

            PollingTimerElapsed(pollingTimer, null);
            pollingTimer.Elapsed += PollingTimerElapsed;
            pollingTimer.Start();

            isPolling = true;
            pollingHandler?.Invoke(true);
        }

        public void startTemperaturePolling()
        {
            int interval = (int)(GlobalSettings.getProperty(GlobalSettings.TEMPERATURE_POLLING_INTERVAL));

            startTemperaturePolling(interval);
        }

        private void PollingTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (SerialThread.Instance.SettingsArrived)
                SerialThread.Instance.SendTemperatureRequest();
        }

        public void stopTemperaturePolling()
        {
            if (!IsPolling) return;

            pollingTimer.Stop();
            isPolling = false;
            pollingHandler?.Invoke(false);
        }

    }
}
