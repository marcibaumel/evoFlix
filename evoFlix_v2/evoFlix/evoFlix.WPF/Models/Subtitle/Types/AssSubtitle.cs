using System;
using System.IO;
using System.Text.RegularExpressions;

namespace evoFlix.WPF.Models.Subtitle
{
    public class AssSubtitle : AbstractSubtitle
    {
        private SubtitleService subtitleService = new SubtitleService();
        public AssSubtitle(string source)
        {
            Path = source;
            Parse();
        }
        public override void Parse()
        {
            var dialogueRegex = new Regex(@"^Dialogue:\s*0\s*,\s*(?<begin>.*?),\s*(?<end>.*?),\s*(.*?,\s*){6}(\{.*\})?\s*(?<text>.*)");

            using (var reader = new StreamReader(Path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Match match = dialogueRegex.Match(line);
                    if (match.Success)
                    {
                        var begin = subtitleService.ConvertDateTimeToMilliSeconds(DateTime.Parse(match.Groups["begin"].Value));
                        var end = subtitleService.ConvertDateTimeToMilliSeconds(DateTime.Parse(match.Groups["end"].Value));
                        string text = subtitleService.RemoveFormatSpecifiers(match.Groups["text"].Value);
                        SubtitleLines.Add(new SubtitleLine(begin, end, text));
                    }
                }
                
            }
        }
    }
}
