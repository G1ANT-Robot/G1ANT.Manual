using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1ANT.Manual.Sync
{
    class Program
    {
        static void Main(string[] args)
        {
            Config settings = new Config();
            for (int index = 1; index < args.Length; index++)
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
                    Environment.Exit(0);
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
                // TODO: More switches... all from settings
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
            Console.WriteLine("G1ANT.Manual.Sync.exe [] [] []");
            // TODO: More information about program using
        }
    }
}
