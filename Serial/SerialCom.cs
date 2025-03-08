using System;
using System.Text;
using System.IO.Ports;
using System.Globalization;
using ApplicationSettings;

namespace Serial
{
    public enum InputType : byte { Temperature = (byte)'t', Settings = (byte)'s' };

    public delegate void TemperatureArrivedHandler(T t);
    public delegate void SettingsArrivedHandler(CUSettings settings);
    public delegate void RawDataArrivedHandler(String rawData);
    public delegate void NoDataArrivedHandler(InputType inputType);
    public delegate void ReadyArrivedHandler();
    public delegate void OpenHandler(bool connected);
    public delegate void ConnectedHandler(bool connected);

    internal class SerialCom
    {
        #region Public
        public event SettingsArrivedHandler settingsArrivedHandler;
        public event TemperatureArrivedHandler temperatureArrivedHandler;
        public event RawDataArrivedHandler rawDataArrivedHandler;
        public event NoDataArrivedHandler noDataArrivedHandler;
        public event ReadyArrivedHandler readyArrivedHandler;
        public event OpenHandler openHandler;
        public event ConnectedHandler connectedHandler;

        private bool settingsArrived = false;

        public bool SettingsArrived
        {
            get { return settingsArrived; }
        }

        private static readonly SerialCom instance = new SerialCom();

        public static SerialCom Instance { get { return instance; } }

        private SerialCom()
        {
            Init();
        }

        /*public SerialCom(String portName)
        {
            Init();
            SetPortName(portName);
        }*/

        public void SetPortName(String portName)
        {
            if (portName != null) serialPort.PortName = portName;
        }

        private void Open()
        {
            if (serialPort.PortName != null)
            {
                serialPort.Open();
                openHandler?.Invoke(true);
            }
        }

        public void Open(String portName)
        {
            if (portName != null && !isConnected)
            {
                serialPort = getNewSerialPort();
                serialPort.PortName = portName;
                Open();
            }
        }

        public void Close()
        {
            if (isConnected)
            {
                serialPort.Close();
                openHandler?.Invoke(false);
                connectedHandler?.Invoke(false);
                settingsArrived = false;
            }
        }

        public byte Execute()                                                   //execute the main loop
        {
            return 0;
        }

        public CUSettings GetAvaiableSettings()                                   //return the settings recieved from serial
        {
            return new CUSettings();
        }

        public void SendCalibrationData(CalibrationData calibrationData)        //send the calibration data to TempLog
        {
            if (calibrationData != 0)
            {
                StringBuilder msg = new StringBuilder("<c,");
                msg.Append(calibrationData.Channel.ToString());
                msg.Append(",");
                msg.Append(calibrationData.Temperature.ToString("F2", CultureInfo.GetCultureInfo("en-US")));
                msg.Append(">");

                //Console.WriteLine(msg);
                serialPort.Write(msg.ToString());
            }
        }

        public void SendSettings(CUSettings settings)                             //send a message with the settings
        {
            if (settings != 0)
            {
                StringBuilder msg = new StringBuilder("<s,");
                msg.Append(settings.N.ToString());

                for (int i = 0; i < settings.N; i++)
                {
                    if (settings.isSup[i]) msg.Append(",T");
                    else msg.Append(",F");
                }

                for (int i = 0; i < settings.N; i++)
                {
                    if (settings.isInf[i]) msg.Append(",T");
                    else msg.Append(",F");
                }

                for (int i = 0; i < settings.N; i++)
                {
                    msg.Append(",");
                    msg.Append(settings.Sup[i].ToString("F1", CultureInfo.GetCultureInfo("en-US")));
                }

                for (int i = 0; i < settings.N; i++)
                {
                    msg.Append(",");
                    msg.Append(settings.Inf[i].ToString("F1", CultureInfo.GetCultureInfo("en-US")));
                }

                msg.Append(">");

                //Console.WriteLine(msg);
                serialPort.Write(msg.ToString());
            }
        }

        public void SendSettingsRequest()                                       //send a message with the settings
        {
            serialPort.Write(settingsRequest);
        }

        public void SendTemperatureRequest()                                    //send a message with the temperatures after a request
        {
            serialPort.Write(temperatureRequest);
        }

        public void SendReportRequest()                                         //send a report request
        {
            serialPort.Write(reportRequest);
        }

        public CUSettings GetSettings()
        {
            return settings;
        }

        public bool isConnected
        {
            get
            {
                return serialPort.IsOpen;
            }
        }

        public T GetTemperature()
        {
            return t;
        }
        #endregion

        #region Private
        private const char START_MARKER = '<';
        private const char END_MARKER = '>';
        private const byte SPECIAL_BYTE = 253;
        private const int MAX_MESSAGE = 300;

        private const String settingsRequest = "<S>";
        private const String temperatureRequest = "<T>";
        private const String reportRequest = "<R>";

        private void Init()
        {
            inputChars = new char[MAX_MESSAGE];
            outputChars = new char[MAX_MESSAGE + 2];
            settings = new CUSettings();
            inProgress = false;
            ndx = 0;
            serialPort = getNewSerialPort();
            t = new T();
        }

        private static SerialPort getNewSerialPort()
        {
            SerialPort serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            serialPort.DtrEnable = true;
            return serialPort;
        }

        public void GetData()                              //check for avaiable data on serial port and read the data
        {
            char singleByte;

            while (serialPort.BytesToRead > 0)
            {
                singleByte = (char)serialPort.ReadChar();

                if (inProgress == true)
                {
                    if (singleByte != END_MARKER)
                    {
                        inputChars[ndx] = singleByte;
                        ndx++;
                        if (ndx >= MAX_MESSAGE)
                            ndx = MAX_MESSAGE - 1;
                    }
                    else
                    {
                        inputChars[ndx] = '\0';
                        inProgress = false;
                        ndx = 0;
                        ParseData();
                    }
                }
                else if (singleByte == START_MARKER)
                {
                    inProgress = true;
                }
            }
        }

        private InputType getInputTypeFromChar(char input)
        {
            return (InputType)((byte)input);
        }

        private void ParseData()                            //parse the data recieved from GetData, and turn on the appropriate flag
        {
            String[] data = ((new string(inputChars)).Split('\0')[0]).Split(',');

            InputType inputType = getInputTypeFromChar(data[0][0]);

            if ("READY".Equals(data[0]))
            {
                parseReady();
            }
            else if (data.Length == 2 && "NODATA".Equals(data[1]))
            {
                throwNoData(inputType);
            }
            else if (inputType.Equals(InputType.Settings))
            {
                parseSettings(data);
            }
            else if (inputType.Equals(InputType.Temperature))
            {
                parseTemperature(data);
            }
            else
            {
                parseRawData(data);
            }
        }

        private void parseSettings(String[] data)
        {
            CUSettings settings = new CUSettings();
            settings.N = Int32.Parse(data[1]);

            for (int i = 0; i < settings.N; i++)
            {
                if (data[i + 2].Equals("T")) settings.isSup[i] = true;
                else settings.isSup[i] = false;
            }

            for (int i = 0; i < settings.N; i++)
            {
                if (data[i + (2 + settings.N)].Equals("T")) settings.isInf[i] = true;
                else settings.isInf[i] = false;
            }

            for (int i = 0; i < settings.N; i++)
            {
                settings.Sup[i] = float.Parse(data[i + (2 + 2 * settings.N)], CultureInfo.GetCultureInfo("en-US"));
            }

            for (int i = 0; i < settings.N; i++)
            {
                settings.Inf[i] = float.Parse(data[i + (2 + 3 * settings.N)], CultureInfo.GetCultureInfo("en-US"));
            }

            this.settings = settings;

            settingsArrivedHandler?.Invoke(settings);
            if (!settingsArrived)
            {
                settingsArrived = true;
                connectedHandler?.Invoke(true);
            }
        }

        private void parseTemperature(String[] data)
        {
            T t = new T();
            try
            {
                t.N = Int32.Parse(data[1]);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Bad Format: \n" + e.StackTrace);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Overflow: \n" + e.StackTrace);
            }

            for (int i = 2; i < t.N + 2; i++)
            {
                if (!data[i].Equals("NAN"))
                {
                    t.temps[i - 2] = float.Parse(data[i], CultureInfo.GetCultureInfo("en-US"));
                }
            }

            this.t = t;

            temperatureArrivedHandler?.Invoke(t);
        }

        private void parseRawData(String[] data)
        {
            String rawData = "";
            foreach (String str in data)
            {
                rawData += str;
            }
            rawDataArrivedHandler?.Invoke(rawData);
        }

        private void throwNoData(InputType input)
        {
            noDataArrivedHandler?.Invoke(input);
        }

        private void parseReady()
        {
            readyArrivedHandler?.Invoke();
        }

        private char[] inputChars;
        private char[] outputChars;

        private CUSettings settings;                          //a temporary SerialCom to TempSensor settings interface

        SerialPort serialPort;
        T t;

        private bool inProgress;
        int ndx;

        #endregion
    }
}
