using System;
using System.IO;
using System.Text.RegularExpressions;

namespace evoFlix.WPF.Models.Subtitle
{
    public class SrtSubtitle : AbstractSubtitle
    {
        private SubtitleService subtitleService = new SubtitleService();
        public SrtSubtitle(string source)
        {
            Path = source;
            Parse();
        }

        public SrtSubtitle() { }

        public override void Parse()
        {
            var indexRegex = new Regex(@"^\d+$");
            var timeRegex = new Regex(@"^\s*(?<begin>.*)\s+-->\s+(?<end>.*)");

            using (var reader = new StreamReader(Path))
            {
                while (!reader.EndOfStream)
                {
                    var indexMatch = indexRegex.Match(reader.ReadLine());
                    if (!indexMatch.Success)
                        continue;
                    var timeMatch = timeRegex.Match(reader.ReadLine());
                    var begin = subtitleService.ConvertDateTimeToMilliSeconds(DateTime.Parse(Regex.Replace(timeMatch.Groups["begin"].Value, ",", ".")));
                    var end = subtitleService.ConvertDateTimeToMilliSeconds(DateTime.Parse(Regex.Replace(timeMatch.Groups["end"].Value, ",", ".")));
                    string text = "";
                    string line = reader.ReadLine();

                    while (line != "")
                    {
                        text += CleanTextData(line);
                        if (reader.EndOfStream)
                            break;
                        line = reader.ReadLine();
                    }
                    SubtitleLines.Add(new SubtitleLine(begin, end, text));
                }             
            }
        }

        private string CleanTextData(string data)
        {
            data = subtitleService.RemoveTags(data);
            data = subtitleService.RemoveExtraSpaces(data);
            data += Environment.NewLine;
            return data;
        }
    }
}
