using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using ApplicationSettings;
using Serial;
using ConsoleOutput;
using View.Forms;

namespace View
{
    public static class ViewUtils
    {
        public static bool attempConnection(bool isOnStart)
        {
            if (!SerialThread.Instance.isConnected)
            {
                if ((bool)GlobalSettings.getProperty(GlobalSettings.CONNECT_ON_START) && "".Equals(GlobalSettings.getProperty(GlobalSettings.SERIAL_PORT)))
                    ConnectForm.showConnectionForm(isOnStart);
                else
                    ConnectingDialog.showConnectingDialog((String)GlobalSettings.getProperty(GlobalSettings.SERIAL_PORT));
            }

            return SerialThread.Instance.isConnected;
        }

        public static void disconnect()
        {
            if (IsConnected)
                SerialThread.Instance.Close();
        }

        public static bool IsConnected { get { return SerialThread.Instance.isConnected; } }
    }
}
