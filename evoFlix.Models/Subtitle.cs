using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;

namespace evoFlix.Models
{
    public class Subtitle
    {
        public string Source { get; set; }
        public List<SubtitleLine> SubtitleLines { get; set; }
        public int CurrentPosition { get; set; }
        //------------------------------------------
        // These properties should be set with the toolbar, wich will be added later
        public int FontSize { get; set; }
        public Brushes Foreground { get; set; }
        public Brushes Background { get; set; }
        //------------------------------------------
        public Subtitle(string source) // The source here is the source of the video
        {
            CurrentPosition = 0;
            // Later: get the subtitle with the same name
            Source = source;
            // Later: Use regex to determine extension (.ass, .srt, ...)
            SubtitleLines = ReadDotASSFile();
            Sort();

            //test
            //foreach (var item in SubtitleLines)
            //{
            //    Console.WriteLine($"{item.Begin}, {item.End}, {item.Text}");
            //}
        }

        private void Sort()
        {
            for (int i = 0; i < SubtitleLines.Count; i++)
            {
                for (int j = 0; j < SubtitleLines.Count; j++)
                {
                    if (SubtitleLines[i].Begin < SubtitleLines[j].Begin)
                    {
                        var temp = SubtitleLines[i];
                        SubtitleLines[i] = SubtitleLines[j];
                        SubtitleLines[j] = temp;
                    }
                }
            }
        }
        public string GetActualText(double currentTime)
        {
            int index = GetActualTextIndex(currentTime);

            if (index < 0)
                return "";
            
            //test
            //Console.WriteLine($"{ConvertDateTimeToSeconds(SubtitleLines[CurrentPosition].Begin)}, {ConvertDateTimeToSeconds(SubtitleLines[CurrentPosition].End)}, {currentTime}");

            return SubtitleLines[index].Text;
        }

        private int GetActualTextIndex(double currentTime)
        {
            for (int i = 0; i < SubtitleLines.Count; i++)
                if (ConvertDateTimeToSeconds(SubtitleLines[i].Begin) <= currentTime && ConvertDateTimeToSeconds(SubtitleLines[i].End) >= currentTime)
                    return i;
            return -1;
        }

        private int ConvertDateTimeToSeconds(DateTime dateTime)
        {
            return dateTime.Hour * 3600 + dateTime.Minute * 60 + dateTime.Second;
        }

        private List<SubtitleLine> ReadDotASSFile()
        {
            var subtitleLines = new List<SubtitleLine>();
            Regex regex = new Regex(@"^Dialogue:\s*0\s*,\s*(?<begin>.*?),\s*(?<end>.*?),\s*(.*?,\s*){6}(\{.*\})?\s*(?<text>.*)");

            using (StreamReader reader = new StreamReader(Source))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        //test
                        //Console.WriteLine($"{match.Groups["begin"].Value}, {match.Groups["end"].Value}, {match.Groups["text"].Value}");

                        DateTime begin = DateTime.Parse(match.Groups["begin"].Value);
                        DateTime end = DateTime.Parse(match.Groups["end"].Value);
                        string text = match.Groups["text"].Value;
                        subtitleLines.Add(new SubtitleLine(begin, end, text));
                    }
                        
                }
            }

            return subtitleLines;
        }

        private List<SubtitleLine> ReadDotSRTFile()
        {
            var subtitleLines = new List<SubtitleLine>();

            using (StreamReader reader = new StreamReader(Source))
            {
                
            }

            return subtitleLines;
        }
    }
}
