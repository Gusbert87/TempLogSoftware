﻿using System;
using System.Windows.Forms;
using ApplicationSettings;
using View.Forms;

namespace View
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ApplicationSettings.GlobalSettings.resetDefaultProperties();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //Console.ReadKey();
        }
    }
}
