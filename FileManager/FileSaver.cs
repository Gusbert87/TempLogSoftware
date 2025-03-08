using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileManager
{
    public class FileSaver
    {

        private static readonly FileSaver instance = new FileSaver();

        public static FileSaver Instance
        {
            get { return instance; }
        }

        public void SaveFile(String fileName, DataTable dataTable)
        {
            Thread saveThread = new Thread(new ParameterizedThreadStart(SaveFileTask));
            saveThread.Start(new Object[] { fileName, dataTable.Copy() });
        }

        private void SaveFileTask(object parameters)
        {
            String fileName = (String)((Object[])parameters)[0];
            DataTable dataTable = (DataTable)((Object[])parameters)[1];

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (StreamWriter sw = File.CreateText(fileName))
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    foreach (object data in dataRow.ItemArray)
                    {
                        sw.Write("\"" + data + "\";");
                    }
                    sw.WriteLine();
                }
            }
        }
    }
}
