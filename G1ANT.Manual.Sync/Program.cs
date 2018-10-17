using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Manual.Sync.Properties;

namespace G1ANT.Manual.Sync
{
    class Program
    {
        static void Main(string[] args)
        {
            Config settings = new Config();
            for (int index = 0; index < args.Length; index++)
                SetArgument(settings, GetArgument(args[index]));

            ParseFiles(settings);
        }

        static KeyValuePair<string, string> GetArgument(string argument)
        {
            Match match = Regex.Match(argument, @"^((\/)|(\-\-)|(\-))(?<name>(\w)*)(\:(?<value>.*))?$");
            return new KeyValuePair<string, string>(
                match.Groups["name"].Value.ToLower(), match.Groups["value"].Value);
        }

        static void SetArgument(Config settings, KeyValuePair<string, string> arg)
        {
            switch(arg.Key)
            {
                case "?":
                case "help":
                case "h":
                    ShowHelp();
                    break;
                case "directory":
                case "dir":
                case "d":
                    if (arg.Value.ToLower() == "github")
                        settings.Directory = new DirectoryInfo($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\GitHub");
                    else
                        settings.Directory = new DirectoryInfo(arg.Value);
                    break;
                case "copyrightheader":
                case "ch":
                    settings.CopyrightHeader = File.ReadAllText(arg.Value);
                    break;
                case "websiteurl":
                case "w":
                    settings.DefaultWebsiteUrl = arg.Value;
                    break;
                case "company":
                case "c":
                    settings.DefaultCompany = arg.Value;
                    break;
                case "license":
                case "l":
                    settings.DefaultLicense = arg.Value;
                    break;
                case "logfilename":
                case "n":
                    settings.LogFileName = arg.Value;
                    break;
                case "repositoryurl":
                case "r":
                    settings.RepositoryUrl = arg.Value;
                    break;
                case "loglineformat":
                case "f":
                    settings.LogLineFormat = arg.Value;
                    break;
            }
        }

        static void ParseFiles(Config settings)
        {
            Parser parser = new Parser(settings);
            parser.GenerateFiles();
            parser.CheckAllHeaders();
        }

        static void ShowHelp()
        {

            string help = "G1ANT.Manual.Sync.exe (C) 2018 by G1ANT Ltd\r\n\r\n" +

                "Based on attributes from *.cs files, generates Addon.md files containing lists of all Variables, Commands, Structures, Panels and Wizards in all Addon repositories.\r\n" +
                "Creates Addons.md, Variables.md, Commands.md, Structures.md, Panels.md and Wizards.md files in G1ANT.Manual repository.\r\n" +
                "Checks all README.md files and adds an Addon.md link if not present. Inserts or modifies all needed headers in all *.cs files in every repository containing “Addon” word, G1ANT.Robot and G1ANT.Language.\r\n\r\n" +

                "G1ANT.Manual.Sync.exe [/? | /h | /help][/d:path | /dir:path | /directory:path][/ch:path | /copyrightheader:path][/w: | /website:][/c: | /company:][/l: | /license:][/n: | /logfilename:][/r: | /repositoryurl:][/f: | /loglineformat:]\r\n\r\n" +

                "Arguments:\r\n" +
                "   /?, /h, /help           Shows help\r\n" +
                "   /d, /dir, /directory    Specifies path to the main directory\r\n" +
                "                            Default value:\r\n" +
                "                               current directory\r\n" +
                "                            directories:\r\n" +
                "                                github           path to a GitHub folder in user’s Documents\r\n" +
                "                                [drive:][path]   custom path\r\n\r\n" +

                "   /ch, /copyrightheader   Specifies template of a Copyright header in *.cs files, copied from a file specified by the given directory\r\n" +
                "                            Template value:\r\n" + "                               " +
                                                Settings.Default.CopyrightHeader.Replace("\r\n", "\r\n                               ") + "\r\n" +
                "   /w, /website            Specifies default company website\r\n" +
                "                            Default value:\r\n" + "                               " +
                                                Settings.Default.DefaultWebsiteUrl + "\r\n" +
                "   /c, /company            Specifies default company name\r\n" +
                "                            Default value:\r\n" + "                               " +
                                                Settings.Default.DefaultCompany + "\r\n" +
                "   /l, /license            Specifies default license type\r\n" +
                "                            Default value:\r\n" + "                               " +
                                                Settings.Default.DefaultLicense + "\r\n" +
                "   /n, /logfilename        Specifies log file name\r\n" +
                "                            Value:\r\n" + "                               " +
                                                Settings.Default.LogFileName + "\r\n" +
                "   /r, /repositoryurl      Specifies repository url\r\n" +
                "                            Value:\r\n" + "                               " +
                                                Settings.Default.RepositoryUrl + "\r\n" +
                "   /f, /loglineformat      Specifies log line format\r\n" +
                "                            Value:\r\n" + "                               " +
                                                Settings.Default.LogLineFormat;

            Console.WriteLine(help);
            Console.ReadKey();
        }
    }
}
