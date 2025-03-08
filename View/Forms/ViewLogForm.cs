using ApplicationSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace View.Forms
{
    public partial class ViewLogForm : Form
    {
        String fileName;
        private DataTable dataTable;

        public ViewLogForm(String fileName)
        {
            InitializeComponent();
            dataTable = new DataTable();
            this.fileName = fileName;
            Text = fileName;
        }

        private void ViewLogFormLoad(object sender, EventArgs e)
        {

            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    DataRow dataRow = null;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = Regex.Split(line, "(?<=\")[,;](?!$)"); //line.Split(new char[] { ';', ','});

                        initGridTable(values.Length);

                        dataRow = dataTable.NewRow();

                        for (int i = 0; i < values.Length; i++)
                        {
                            dataRow[i] = values[i].Replace("\"", "");
                        }

                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                if (String.IsNullOrEmpty(fileName))
                {
                    Close();
                }
                else throw ex;
            }

            grdTable.Refresh();
        }

        private void initGridTable(int columns)
        {
            if (dataTable.Columns != null && dataTable.Columns.Count != 0) return;

            grdTable.DataSource = dataTable;
            dataTable.Columns.Clear();

            dataTable.Columns.Add("Ora");
            grdTable.Columns[0].Width = 120;

            for (int i = 1; i < columns; i++)
            {
                dataTable.Columns.Add("T" + (i - 1));
                grdTable.Columns[i].Width = 60;
            }

            grdTable.Refresh();
        }
    }
}
