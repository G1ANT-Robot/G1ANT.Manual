using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace G1ANT.Manual.Sync
{
    public class Parser
    {
        public Config Settings { get; set; } = null;

        public Parser(Config settings)
        {
            Settings = settings;
        }

        public void PrepareFiles(string sectionName, Section section)
        {
            string pathToSection = $@"{Settings.Directory}\G1ANT.Manual\{sectionName}.md";
            string fullHeader = $"# List of All {sectionName}{Settings.ManualHeader}";
            if (sectionName == "Addons")
                fullHeader = fullHeader.Replace("Addon ", "Author ");
            string text = "";
            string addonPath = "";

            File.WriteAllText(pathToSection, fullHeader);

            for (int i = 0; i < section.Addons.Count; i++)
            {
                string repLink = Settings.RepositoryUrl + section.Addons[i] + "/blob/master/" + section.Addons[i];
                string sectionLink = $"{repLink}/{sectionName}/{section.Files[i]}";
                string addonLink = $"{repLink}/Addon.md";
                addonPath = $@"{Settings.Directory}\{section.Addons[i]}\{section.Addons[i]}\Addon.md";
                if (sectionName == "Addons")
                    File.AppendAllText(pathToSection, $@"| [{section.Addons[i]}]({addonLink}) | {section.Tooltips[i]} | {section.Sections[i]} |{Environment.NewLine}");
                else
                {
                    File.AppendAllText(pathToSection, $@"| [{section.Sections[i]}]({sectionLink}) | {section.Tooltips[i]} | [{section.Addons[i]}]({addonLink}) |{Environment.NewLine}");
                    if (File.Exists(addonPath) == false)
                        File.AppendAllText(addonPath, Environment.NewLine + fullHeader.Replace(" Addon |", "").Replace(" ----- |", ""));
                    else
                        text = File.ReadAllText(addonPath);
                    if (text.Contains(fullHeader.Replace(" Addon |", "").Replace(" ----- |", "")) == false && string.IsNullOrWhiteSpace(text) == false)
                        File.AppendAllText(addonPath, Environment.NewLine + fullHeader.Replace(" Addon |", "").Replace(" ----- |", ""));
                    File.AppendAllText(addonPath, $"| [{section.Sections[i]}]({sectionLink}) | {section.Tooltips[i]} |{Environment.NewLine}");
                }
            }
            if (sectionName != "Addons" && addonPath != "")
                File.AppendAllText(addonPath, Environment.NewLine);
        }

        public void GenerateFiles()
        {
            foreach (var directory in Settings.Directory.GetDirectories())
            {
                if (directory.Name.Contains("G1ANT.Addon.") && directory.Name.Contains(".Tests") == false)
                {
                    string path = $@"{Settings.Directory}\{directory.Name}\{directory.Name}\Addon.md";
                    if (File.Exists(path))
                        File.Delete(path);
                }
            }
            PrepareFiles("Commands", GetSection("Command"));
            PrepareFiles("Structures", GetSection("Structure"));
            PrepareFiles("Variables", GetSection("Variable"));
            PrepareFiles("Triggers", GetSection("Trigger"));
            PrepareFiles("Panels", GetSection("Panel"));
            PrepareFiles("Wizards", GetSection("Wizard"));
            PrepareFiles("Addons", GetSection("Addon"));
        }

        public string GetMatch(string text, string attribute, string property)
        {
            string matchLine = Regex.Match(text, $@"\[{attribute}(Attribute)?\((.|\s)*?\)\s*\]").ToString();
            string match = Regex.Match(matchLine, $@"({property}\s?)+=\s?(?<value>(.)*?)[,)]").Groups["value"].Value.ToString();
            return match;
        }

        public Section GetSection(string name)
        {
            Section section = new Section();
            string argumentName = "";

            if (name == "Panel")
                argumentName = "Title";
            else if (name == "Addon")
            {
                foreach (var directory in Settings.Directory.GetDirectories())
                {
                    if (directory.Name.Contains("G1ANT.Addon.") && directory.Name.Contains(".Tests") == false)
                    {
                        DirectoryInfo addonDirectory = new DirectoryInfo(directory.FullName);
                        foreach (var addoncs in addonDirectory.GetFiles("Addon.cs", SearchOption.AllDirectories))
                        {
                            section.Files.Add("Addon.md");
                            var text = File.ReadAllText(addoncs.FullName);
                            string addonName = GetMatch(text, "Addon", "Name").Replace("\"", "");
                            section.Addons.Add(addonName);
                            string tooltip = GetMatch(text, "Addon", "Tooltip").Replace("\"", "");
                            section.Tooltips.Add(tooltip);
                            string author = GetMatch(text, "Copyright", "Author").Replace("\"", "");
                            section.Sections.Add(author);
                        }
                    }
                }
                return section;
            }
            else
                argumentName = "Name";

            foreach (var directory in Settings.Directory.GetDirectories())
            {
                if (directory.Name == "G1ANT.Language" || directory.Name == "G1ANT.Robot" || (directory.Name.Contains("G1ANT.Addon.") && directory.Name.Contains(".Tests") == false))
                {
                    DirectoryInfo repDirectory = new DirectoryInfo(directory.FullName);

                    foreach (var csfile in repDirectory.GetFiles("*.cs", SearchOption.AllDirectories))
                    {
                        if (csfile.FullName.Contains(".Tests") == false)
                        {
                            var text = File.ReadAllText(csfile.FullName);
                            string sectionName = GetMatch(text, name, argumentName);
                            string addonName = csfile.FullName.Replace($@"{Settings.Directory.ToString()}\", "");
                            addonName = addonName.Substring(0, addonName.IndexOf(@"\"));

                            if (sectionName != "" && sectionName != "...")
                            {
                                string tooltip = GetMatch(text, name, "Tooltip").Replace("\"", "").Replace("\n", " ");

                                if (sectionName.Contains("\""))
                                {
                                    sectionName = sectionName.Replace("\"", "");
                                    section.Sections.Add(sectionName);
                                }
                                else if (sectionName.Contains("."))
                                {
                                    string dictionarysection = sectionName.Substring(0, sectionName.IndexOf("."));
                                    string dictionaryundersection = sectionName.Replace(dictionarysection, "").Replace(".", "");
                                    DirectoryInfo dictionary = new DirectoryInfo($@"{Settings.Directory.ToString()}\{addonName}");
                                    foreach (var file in dictionary.GetFiles("*.cs", SearchOption.AllDirectories))
                                    {
                                        string content = File.ReadAllText(file.FullName);
                                        if (content.Contains($"class {dictionarysection}"))
                                        {
                                            sectionName = Regex.Match(content, $"({dictionaryundersection}\\s?)+=\\s?\"(?<theTitle>(.)*?)[\"]").Groups["theTitle"].Value.ToString();
                                            section.Sections.Add(sectionName);
                                        }
                                    }
                                }
                                else
                                {
                                    sectionName = Regex.Match(text, $"({sectionName}\\s?)+=\\s?\"(?<theTitle>(.)*?)[\"]").Groups["theTitle"].Value.ToString();
                                    section.Sections.Add(sectionName);
                                }
                                section.Files.Add(csfile.Name.ToString().Replace("cs", "md"));
                                section.Tooltips.Add(tooltip);
                                section.Addons.Add(addonName);
                            }
                        }
                    }
                }
            }
            return section;
        }

        public void CheckAllHeaders()
        {
            foreach (var file in Settings.Directory.GetFiles("*.sln", SearchOption.AllDirectories))
            {
                Regex findfolder = new Regex($@"(?<={Settings.Directory.ToString().Replace(@"\", @"\\")}\\).*?(?=\\)");
                Match folder = findfolder.Match(file.FullName);
                string solution = Path.GetFileNameWithoutExtension(file.Name);
                DirectoryInfo path = new DirectoryInfo($@"{Settings.Directory}\{folder}");
                foreach (var csproj in path.GetFiles("*.csproj", SearchOption.AllDirectories))
                {
                    string project = Path.GetFileNameWithoutExtension(csproj.Name);
                    path = new DirectoryInfo(csproj.FullName.Substring(0, csproj.FullName.LastIndexOf("\\")));
                    string folder2 = (path.ToString().Substring(Settings.Directory.ToString().Length)).Split('\\')[1];
                    string addonFile = $@"{Settings.Directory.ToString()}\{folder2}\{folder2}\Addon.cs";
                    if (File.Exists(addonFile))
                    {
                        string addonContent = File.ReadAllText(addonFile);
                        string author = Regex.Match(addonContent, $@"(Author\s?)+=\s?(?<theName>(.)*?)[,)]").Groups["theName"].Value.ToString();
                        string website = Regex.Match(addonContent, $@"(Website\s?)+=\s?(?<theName>(.)*?)[,)]").Groups["theName"].Value.ToString();


                        if (author.Contains("G1ANT"))
                        {
                            foreach (var csfile in path.GetFiles("*.cs", SearchOption.AllDirectories))
                            {
                                // TODO: get website and license from current project
                                string header = Settings.CopyrightHeader.Replace("{project}", project).Replace("{solution}", solution).Replace("{company}", author).Replace("{website}", Settings.DefaultWebsiteUrl).Replace("{license}", Settings.DefaultLicense);
                                string fileContent = File.ReadAllText(csfile.FullName);
                                if ((!fileContent.Contains(" Copyright") || fileContent.Contains("G1ANT.Addon,")) && !csfile.FullName.Contains("Sdk"))
                                {
                                    if (fileContent.Contains("G1ANT.Addon,") == false)
                                        File.WriteAllText(csfile.FullName, header + fileContent);
                                    else
                                    {
                                        Regex headerRegex = new Regex(@"(\/\*\*)(.|\s)*?(\*\/)");
                                        Match headerMatch = headerRegex.Match(fileContent);
                                        fileContent = fileContent.Replace(headerMatch.ToString(), "");
                                        File.WriteAllText(csfile.FullName, header + fileContent);
                                    }
                                    File.AppendAllText(Settings.LogFileName, $"{csfile.FullName}\r\n");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
