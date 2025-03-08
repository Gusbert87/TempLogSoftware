using System;
using System.IO.Ports;

namespace Serial
{
    public static class SerialUtils
    {
        public static String[] GetSerialPortNames()
        {
            return SerialPort.GetPortNames();
        }
    }
}
