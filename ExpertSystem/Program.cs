﻿using ExpertSystem;
using System;
using System.Windows.Forms;

namespace ExpertSystem
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ExpertSystemForm());
        }
    }
}
