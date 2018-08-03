using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using G1ANT.Manual.Sync.Properties;

namespace G1ANT.Manual.Sync
{
    public class Config
    {
        public string RepositoryUrl { get; set; } = Settings.Default.RepositoryUrl;
        public DirectoryInfo Directory { get; set; } = new DirectoryInfo(@"C:\Users\a\Documents\Github"); //new DirectoryInfo(Environment.CurrentDirectory);
        public string ManualHeader { get; set; } = Settings.Default.ManualHeader;
        public string CopyrightHeader { get; set; } = Settings.Default.CopyrightHeader;
        public string DefaultWebsiteUrl { get; set; } = Settings.Default.DefaultWebsiteUrl;
        public string DefaultCompany { get; set; } = Settings.Default.DefaultCompany;
        public string DefaultLicense { get; set; } = Settings.Default.DefaultLicense;
        public string LogFileName { get; set; } = Settings.Default.LogFileName;
        // TODO: More settings like LogFile
    }
}