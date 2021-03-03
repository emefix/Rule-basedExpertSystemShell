using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem
{
    public static class LogFile
    {
        #region "Append entry to logfile"

        public static void AppendEntry(string logMessage, string logFileName)
        {
            StreamWriter w = new StreamWriter(logFileName);

            w.Write("\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                                   DateTime.Now.ToLongDateString());
            w.WriteLine();
            w.WriteLine(logMessage);
            w.Close();
        }
        #endregion

        #region "Append message to logfile"

        public static void Log(string logMessage, string logFileName)
        {
            StreamWriter w = File.AppendText(logFileName);
            w.WriteLine(logMessage);
            w.Close();
        } 
        #endregion
    }
}
