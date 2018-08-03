using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace G1ANT.Manual.Sync
{
    public class Log
    {
        public string FileName { get; set; } = Properties.Settings.Default.LogFileName;
        public string LineFormat { get; set; } = Properties.Settings.Default.LogLineFormat;

        public Log(string fileName, string lineFormat = "")
        {
            FileName = fileName;
            if (lineFormat != "")
                LineFormat = lineFormat;
        }

        public void Add(string message)
        {
            File.AppendAllText(FileName, String.Format(LineFormat, DateTime.Now, message);
        }
    }
}
