using System;
using System.Globalization;
using System.IO;

using Serial;

using ApplicationSettings;

namespace ConsoleOutput
{
    public class ConsoleOutput
    {
        private static String PORT = "COM3";//(string)ApplicationSettings.GlobalSettings.getProperty(ApplicationSettings.GlobalSettings.SERIAL_PORT);
        private static SerialThread serialThread;

        static void Main(string[] args)
        {
            ConsoleTest();
        }

        public static void ConsoleTest()
        {
            Console.WriteLine(PORT);
            serialThread = SerialThread.Instance;
            Init();
            serialThread.Open(PORT);
            serialThread.StartReadThread();
            
            Console.WriteLine("Program started");
            Console.WriteLine("T - get temperatures");
            Console.WriteLine("S - get settings");
            Console.WriteLine("U - send default 5 channel settings");
            Console.WriteLine("C - calibrate channel 4");
            Console.WriteLine("Q - exit");
            Console.WriteLine("D - disconnect serial");
            Console.WriteLine("R - reconnect serial");
            Console.WriteLine("G - start read thread");
            Console.WriteLine("Q - quit");


            char key = '0';

            try
            {
                while (!Char.ToUpper(key).Equals('Q'))
                {
                    //serialCom.GetData();
                    key = Console.ReadKey(true).KeyChar;
                    switch (Char.ToUpper(key))
                    {
                        case 'T':
                            serialThread.SendTemperatureRequest();
                            break;
                        case 'S':
                            serialThread.SendSettingsRequest();
                            break;
                        case 'U':
                            CUSettings settings = new CUSettings(5);
                            serialThread.SendSettings(settings);
                            break;
                        case 'C':
                            CalibrationData calibrationData = new CalibrationData();
                            calibrationData.Channel = 4;
                            calibrationData.Temperature = 34.0F;
                            serialThread.SendCalibrationData(calibrationData);
                            break;
                        case 'D':
                            serialThread.Close();
                            break;
                        case 'R':
                            serialThread.Open(PORT);
                            break;
                        case 'G':
                            serialThread.StartReadThread();
                            break;

                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Error, could not connect to " + PORT);
            }
            Console.ReadKey();
        }

        public static void Init()
        {
            serialThread.settingsArrivedHandler += settingsArrivedHandler;
            serialThread.temperatureArrivedHandler += temperatureArrived;
            serialThread.rawDataArrivedHandler += rawDataArrived;
            serialThread.noDataArrivedHandler += noDataArrived;
            serialThread.readyArrivedHandler += readyArrived;
        }

        private static void readyArrived()
        {
            Console.WriteLine("Device is ready!");
        }

        private static void noDataArrived(InputType inputType)
        {
            Console.Write("\nNo ");
            switch(inputType)
            {
                case InputType.Temperature:
                    Console.Write("temperature ");
                    break;
                case InputType.Settings:
                    Console.Write("settings ");
                    break;
                default:
                    Console.Write("unknown ");
                    break;
            }
            Console.WriteLine("data available.");
        }

        private static void rawDataArrived(String rawData)
        {
            Console.WriteLine("\nRawData arrived:");
            Console.WriteLine(rawData);
        }

        private static void temperatureArrived(T temperatureSet)
        {
            Console.WriteLine("\nTemperatures arrived:");
            for (int i = 0; i < temperatureSet.N; i++)
            {
                Console.Write(temperatureSet.temps[i].ToString("F1", CultureInfo.GetCultureInfo("en-US")) + " ");
            }
            Console.WriteLine();
        }

        private static void settingsArrivedHandler(CUSettings settings)
        {
            Console.WriteLine("\nSettings arrived:");
            Console.WriteLine("Number of channels: " + settings.N);

            Console.WriteLine("Soglia superiore attiva:");
            for (int i = 0; i < settings.N; i++)
            {
                Console.Write("  canale " + i + ":\t");
                if (settings.isSup[i]) Console.WriteLine("SI");
                else Console.WriteLine("NO");
            }

            Console.WriteLine("Soglia inferiore attiva:");
            for (int i = 0; i < settings.N; i++)
            {
                Console.Write("  canale " + i + ":\t");
                if (settings.isInf[i]) Console.WriteLine("SI");
                else Console.WriteLine("NO");
            }

            Console.WriteLine("Soglia superiore:");
            for (int i = 0; i < settings.N; i++)
            {
                Console.Write("  canale " + i + ":\t");
                Console.WriteLine(settings.Sup[i].ToString("F1", CultureInfo.GetCultureInfo("en-US")));
            }

            Console.WriteLine("Soglia inferiore:");
            for (int i = 0; i < settings.N; i++)
            {
                Console.Write("  canale " + i + ":\t");
                Console.WriteLine(settings.Inf[i].ToString("F1", CultureInfo.GetCultureInfo("en-US")));
            }

        }

        public static string returnPath()
        {
            string folder = Environment.CurrentDirectory;
            return folder;
        }
    }
}
