using System;
using System.Threading;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationSettings;

namespace FileManager
{

    public delegate void SaveDataHandler(DataTable dataTable);

    public class SaveScheduler
    {
        public event SaveDataHandler saveDataHandler;

        private static readonly SaveScheduler instance = new SaveScheduler();

        public static SaveScheduler Instance
        {
            get { return instance; }
        }

        private Timer startTimer;
        private Timer scheduleTimer;

        public void StopTimer()
        {
            if (startTimer != null)
                startTimer.Dispose();
        }

        public void StartTimer()
        {
            DateTime startDate = (DateTime)GlobalSettings.getProperty(GlobalSettings.SAVE_DATE);
            TimeSpan saveInterval = (TimeSpan)GlobalSettings.getProperty(GlobalSettings.SAVE_INTERVAL);

            StartTimer(startDate, saveInterval);
        }

        public void StartTimer(DateTime startDate, TimeSpan saveInterval)
        {
            if (startTimer != null)
                return;

            DateTime now = DateTime.Now;
            //now.AddMilliseconds(-now.Millisecond);
            //now.AddSeconds(-now.Second);

            TimeSpan timeToGo;
            if (startDate.Ticks < now.Ticks)
            {
                timeToGo = new TimeSpan(now.Ticks - startDate.Ticks);
                timeToGo = TimeSpan.FromMinutes(saveInterval.TotalMinutes - (timeToGo.TotalMinutes % saveInterval.TotalMinutes));
            }
            else
            {
                timeToGo = new TimeSpan(startDate.Ticks - now.Ticks);
            }

            startTimer = new Timer(Save, null, timeToGo, saveInterval);
        }

        private void SetupSaveTimer(object parameter)
        {
            if (scheduleTimer != null)
                return;

            TimeSpan scheduleTime = (TimeSpan)((Object[])parameter)[0];
            DataTable dataTable = (DataTable)((Object[])parameter)[1];

            scheduleTimer = new Timer(Save, dataTable, scheduleTime.Milliseconds, Timeout.Infinite);
        }

        private void Save(Object parameter)
        {
            DataTable dataTable = new DataTable();
            saveDataHandler?.Invoke(dataTable);

            DateTime current = DateTime.Now;
            String fileName = GlobalSettings.settings.save_folder + String.Format("{0:00}", current.Day) + "." + String.Format("{0:00}", current.Month) + "." + current.Year + "-" + String.Format("{0:00}", current.Hour) + "." + String.Format("{0:00}", current.Minute) + ".csv";
            FileSaver.Instance.SaveFile(fileName, dataTable);
        }
    }
}
