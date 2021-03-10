using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace evoFlix.Models
{

    /// TO-DO:
    /// - Implement Binary Search in GetTextIndex
    /// - Implement a faster sorting method
    /// 

    public class Subtitle
    {
        public string Source { get; set; }
        public List<SubtitleLine> SubtitleLines { get; set; }
        public List<string> AvailableSubtitlePaths { get; set; }

        //------------------------------------------
        public int FontSize { get; set; }
        public Brushes Foreground { get; set; }
        public Brushes Background { get; set; }
        //------------------------------------------
        public Subtitle(string source) // The source here is the source of the video
        {
            string videoFolderPath = Path.GetDirectoryName(source);
            string videoName = Path.GetFileNameWithoutExtension(source);
            string videoExtension = Path.GetExtension(source);

            string[] subtitlePaths = Directory.GetFiles(videoFolderPath, videoName + ".*");

            if (subtitlePaths.Length > 1)
            {
                Source = Path.GetExtension(subtitlePaths[0]) != videoExtension ? subtitlePaths[0] : subtitlePaths[1];

                AvailableSubtitlePaths = new List<string>();
                AvailableSubtitlePaths.AddRange(subtitlePaths);
                for (int i = 0; i < subtitlePaths.Length; i++)
                {
                    string ass = videoFolderPath + "\\" + videoName + ".ass";
                    string srt = videoFolderPath + "\\" + videoName + ".srt";
                    if (subtitlePaths[i] != ass && subtitlePaths[i] != srt)
                        AvailableSubtitlePaths.Remove(subtitlePaths[i]);
                }


                ReadSubtitle();
            }
        }

        public void SetActualSubtitle(string source)
        {
            Source = source;
            ReadSubtitle();
        }

        private void ReadSubtitle()
        {
            switch (Path.GetExtension(Source))
            {
                case ".ass":
                    SubtitleLines = ReadDotASSFile();
                    break;
                case ".srt":
                    SubtitleLines = ReadDotSRTFile();
                    break;
            }
            Sort();
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
            int index = GetTextIndex(currentTime);

            if (index < 0)
                return "";

            return SubtitleLines[index].Text;
        }

        private int GetTextIndex(double currentTime)
        {
            for (int i = 0; i < SubtitleLines.Count; i++)
                if (ConvertDateTimeToMilliSeconds(SubtitleLines[i].Begin) <= currentTime && ConvertDateTimeToMilliSeconds(SubtitleLines[i].End) >= currentTime)
                    return i;
            return -1;
        }

        private int ConvertDateTimeToMilliSeconds(DateTime dateTime)
        {
            return (dateTime.Hour * 3600 + dateTime.Minute * 60 + dateTime.Second) * 1000 + dateTime.Millisecond;
        }

        private List<SubtitleLine> ReadDotASSFile()
        {
            var subtitleLines = new List<SubtitleLine>();
            Regex dialogueRegex = new Regex(@"^Dialogue:\s*0\s*,\s*(?<begin>.*?),\s*(?<end>.*?),\s*(.*?,\s*){6}(\{.*\})?\s*(?<text>.*)");

            using (StreamReader reader = new StreamReader(Source))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Match match = dialogueRegex.Match(line);
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
            Regex indexRegex = new Regex(@"^\d+$");
            Regex timeRegex = new Regex(@"^\s*(?<begin>.*)\s+-->\s+(?<end>.*)");

            using (StreamReader reader = new StreamReader(Source))
            {
                
                while (!reader.EndOfStream)
                {
                    Match indexMatch = indexRegex.Match(reader.ReadLine());
                    if (!indexMatch.Success)
                        continue;
                    Match timeMatch = timeRegex.Match(reader.ReadLine());
                    DateTime begin = DateTime.Parse(Regex.Replace(timeMatch.Groups["begin"].Value, ",", "."));
                    DateTime end = DateTime.Parse(Regex.Replace(timeMatch.Groups["end"].Value, ",", "."));
                    string text = "";
                    string line = reader.ReadLine();

                    while (line != "")
                    {
                        text += line + Environment.NewLine;
                        line = reader.ReadLine();
                    }
                    subtitleLines.Add(new SubtitleLine(begin, end, text));
                }
            }

            return subtitleLines;
        }
    }
}
