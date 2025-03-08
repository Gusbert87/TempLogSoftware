using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationSettings
{
    public delegate void NewPropertyFileHandler();
    public class JavaProperties
    {
        public event NewPropertyFileHandler newPropertyFileHandler;

        private Dictionary<String, String> list;
        private String filename;

        public JavaProperties(String file)
        {
            reload(file);
        }

        public String get(String field, String defValue)
        {
            return (get(field) == null) ? (defValue) : (get(field));
        }
        public String get(String field)
        {
            return (list.ContainsKey(field)) ? (list[field]) : (null);
        }

        public void set(String field, String value)
        {
            if (!list.ContainsKey(field))
                list.Add(field, value);
            else
                list[field] = value;
        }

        public void save()
        {
            save(this.filename);
        }

        public void save(String filename)
        {
            this.filename = filename;

            if (!System.IO.File.Exists(filename))
                System.IO.File.Create(filename);

            System.IO.StreamWriter file = new System.IO.StreamWriter(filename);

            foreach (String prop in list.Keys.ToArray())
                if (!"".Equals(list[prop]))
                    file.WriteLine(prop + "=" + list[prop]);

            file.Close();
        }

        public void reload()
        {
            reload(this.filename);
        }

        public void reload(String filename)
        {
            this.filename = filename;
            list = new Dictionary<String, String>();

            if (System.IO.File.Exists(filename))
            {
                loadFromFile(filename);
            }
            else
            {
                System.IO.File.Create(filename);
                newPropertyFileHandler?.Invoke();
            }
        }

        private void loadFromFile(String file)
        {
            foreach (String line in System.IO.File.ReadAllLines(file))
            {
                if ((!String.IsNullOrEmpty(line)) &&
                    (!line.StartsWith(";")) &&
                    (!line.StartsWith("#")) &&
                    (!line.StartsWith("'")) &&
                    (line.Contains('=')))
                {
                    int index = line.IndexOf('=');
                    String key = line.Substring(0, index).Trim();
                    String value = line.Substring(index + 1).Trim();

                    if ((value.StartsWith("\"") && value.EndsWith("\"")) ||
                        (value.StartsWith("'") && value.EndsWith("'")))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }

                    try
                    {
                        //ignore dublicates
                        list.Add(key, value);
                    }
                    catch { }
                }
            }
        }
    }
}
