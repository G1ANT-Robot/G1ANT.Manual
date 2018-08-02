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
                    if (text.Contains(fullHeader.Replace(" Addon |", "").Replace(" ----- |", "")) == false)
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
                string path = $@"{Settings.Directory}\{directory.Name}\{directory.Name}\Addon.md";
                if (File.Exists(path))
                    File.Delete(path);
            }
            PrepareFiles("Commands", GetSection("Command"));
            PrepareFiles("Structures", GetSection("Structure"));
            PrepareFiles("Variables", GetSection("Variable"));
            PrepareFiles("Triggers", GetSection("Trigger"));
            PrepareFiles("Panels", GetSection("Panel"));
            PrepareFiles("Wizards", GetSection("Wizard"));
            PrepareFiles("Addons", GetSection("Addon"));
        }

        public Section GetSection(string name)
        {
            Section section = new Section();
            string argumentName = "";

            if (name == "Panel")
                argumentName = "Title";
            else if (name == "Addon")
            {
                foreach (var addoncs in Settings.Directory.GetFiles("Addon.cs", SearchOption.AllDirectories))
                {
                    section.Files.Add("Addon.md");
                    var text = File.ReadAllText(addoncs.FullName);
                    Regex regexAddon = new Regex($@"\[Addon(Attribute)?\((.|\s)*?\)\s*\]");
                    Match match1 = regexAddon.Match(text);

                    Regex regexAddonName = new Regex($@"(Name\s?)+=\s?(?<theName>(.)*?)[,)]");
                    Match matchAddonName = regexAddonName.Match(match1.ToString());
                    string addonName = matchAddonName.Groups["theName"].Value.ToString().Replace("\"", "");
                    section.Addons.Add(addonName);

                    Regex regexTooltip = new Regex($@"(Tooltip\s?)+=\s?(?<theName>(.)*?)[,)]");
                    Match matchTooltip = regexTooltip.Match(match1.ToString());
                    string tooltip = matchTooltip.Groups["theName"].Value.ToString().Replace("\"", "");
                    section.Tooltips.Add(tooltip);

                    Regex regexCopyright = new Regex($@"\[Copyright(Attribute)?\((.|\s)*?\)\s*\]");
                    Match match2 = regexCopyright.Match(text);

                    Regex regexAuthor = new Regex($@"(Author\s?)+=\s?(?<theName>(.)*?)[,)]");
                    Match matchAuthor = regexAuthor.Match(match2.ToString());
                    string author = matchAuthor.Groups["theName"].Value.ToString().Replace("\"", "");
                    section.Sections.Add(author);
                }
                return section;
            }
            else
                argumentName = "Name";

            foreach (var csfile in Settings.Directory.GetFiles("*.cs", SearchOption.AllDirectories))
            {
                if (csfile.FullName.Contains("Test") == false)
                {
                    var text = File.ReadAllText(csfile.FullName);
                    Regex regex = new Regex($@"\[{name}(Attribute)?\((.|\s)*?\)\s*\]");
                    Match match = regex.Match(text);

                    Regex sectionFound = new Regex($@"({argumentName}\s?)+=\s?(?<theName>(.)*?)[,)]");
                    Match sectionMatch = sectionFound.Match(match.ToString());
                    string sectionName = sectionMatch.Groups["theName"].Value.ToString();
                    string addonName = csfile.FullName.Replace($@"{Settings.Directory.ToString()}\", "");
                    addonName = addonName.Substring(0, addonName.IndexOf(@"\"));

                    if (sectionName != "" && sectionName != "...")
                    {
                        Regex sectionTooltip = new Regex(@"(Tooltip\s?)+=\s?(?<theTooltip>(.)*?)[,)]");
                        Match sectionTooltipMatch = sectionTooltip.Match(match.ToString());
                        string tooltip = sectionTooltipMatch.Groups["theTooltip"].Value.ToString().Replace("\"", "").Replace("\n", " ");

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
                                    sectionFound = new Regex($"({dictionaryundersection}\\s?)+=\\s?\"(?<theTitle>(.)*?)[\"]");
                                    sectionMatch = sectionFound.Match(content);
                                    sectionName = sectionMatch.Groups["theTitle"].Value.ToString();
                                    section.Sections.Add(sectionName);
                                }
                            }
                        }
                        else
                        {
                            sectionFound = new Regex($"({sectionName}\\s?)+=\\s?\"(?<theTitle>(.)*?)[\"]");
                            sectionMatch = sectionFound.Match(text.ToString());
                            sectionName = sectionMatch.Groups["theTitle"].Value.ToString();
                            section.Sections.Add(sectionName);
                        }
                        section.Files.Add(csfile.Name.ToString().Replace("cs", "md"));
                        section.Tooltips.Add(tooltip);
                        section.Addons.Add(addonName);
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
                        Regex authorRegex = new Regex($@"(Author\s?)+=\s?(?<theName>(.)*?)[,)]");
                        Match authorMatch = authorRegex.Match(addonContent);
                        string author = authorMatch.Groups["theName"].Value.ToString();

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
