using System;

namespace ApplicationSettings
{
    public delegate void SettingsSavedHandler();
    public static class GlobalSettings
    {
        public static event SettingsSavedHandler settingsSavedHandler;
        public const String SERIAL_PORT = "serial_port";
        public const String CONNECT_ON_START = "connect_on_start";
        public const String CONNECTION_TIMEOUT = "connection_timeout";
        public const String TEMPERATURE_POLLING_INTERVAL = "temperature_polling_interval";
        public const String SAVE_FOLDER = "save_folder";
        public const String SAVE_DATE = "save_date";
        public const String SAVE_INTERVAL = "save_interval";

        private const String SETTINGS_FILE_NAME = "system.properties";
        //private static JavaProperties properties;
        private static CUSettings serialSettings;
        private static Object serialSettingsToken = new Object();

        public static Settings.Properties.Settings settings = Settings.Properties.Settings.Default;

        static GlobalSettings()
        {
            //properties = new JavaProperties(SETTINGS_FILE_NAME);
            //properties.newPropertyFileHandler += resetDefaultProperties;
            settings = Settings.Properties.Settings.Default;
        }

        public static object getProperty(String name)
        {
            //return properties.get(name);
            return settings[name];
        }

        public static void setProperty(String name, object value)
        {
            setProperty(name, value, true);
        }

        public static void setProperty(String name, object value, bool save)
        {
            //properties.set(name, value);
            settings[name] = value;
            if(save)
            {
                GlobalSettings.save();
            }
        }

        public static CUSettings SerialSettings
        {
            get
            {
                lock (serialSettingsToken)
                {
                    if (serialSettings == null)
                    {
                        serialSettings = new CUSettings();
                    }
                    return serialSettings;
                }
            }

            set
            {
                lock (serialSettingsToken)
                {
                    if (value != null)
                    {
                        serialSettings = value;
                    }
                }
            }
        }

        public static void save()
        {
            //properties.save();
            settings.Save();
            settingsSavedHandler?.Invoke();
        }

        public static void reload()
        {
            //properties.reload();
        }

        public static void resetDefaultProperties()
        {
            setProperty(SERIAL_PORT, Defaults.SERIAL_PORT, false);
            setProperty(CONNECT_ON_START, Defaults.CONNECT_ON_START);
            setProperty(CONNECTION_TIMEOUT, Defaults.CONNECTION_TIMEOUT, false);
            setProperty(TEMPERATURE_POLLING_INTERVAL, Defaults.TEMPERATURE_POLLING_INTERVAL, false);
            setProperty(SAVE_FOLDER, Defaults.SAVE_FOLDER);
            setProperty(SAVE_DATE, Defaults.SAVE_DATE);
            setProperty(SAVE_INTERVAL, Defaults.SAVE_INTERVAL);

            save();
        }

        private static class Defaults
        {
            public const String SERIAL_PORT = "COM4";
            public const bool CONNECT_ON_START = false;
            public const int CONNECTION_TIMEOUT = 15000;
            public const int TEMPERATURE_POLLING_INTERVAL = (int)TEMPERATURE_INTERVAL.CONTINUOS;
            public const String SAVE_FOLDER = ".\\";
            public static readonly DateTime SAVE_DATE = new DateTime(2017, 09, 16, 00 ,00 ,00 );
            public static readonly TimeSpan SAVE_INTERVAL = new TimeSpan(24,0,0);
        }

        public enum TEMPERATURE_INTERVAL : int
        {
            CONTINUOS = 1000,
            FIVE_MINUTES = (5 * 60 * 1000),
            THIRTY_MINUTES = (30 * 60 * 1000),
            SIXTY_MINUTES = (60 * 60 * 1000),
        }
    }
}
