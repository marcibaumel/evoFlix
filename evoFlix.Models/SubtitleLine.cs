using System;
using System.Text.RegularExpressions;

namespace evoFlix.Models
{
    public class SubtitleLine
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public string Text { get; set; }
        public SubtitleLine(DateTime begin, DateTime end, string text)
        {
            Begin = begin;
            End = end;
            Text = ConvertText(text);

            //test
            //Console.WriteLine(Text);
        }

        private string ConvertText(string text)
        {
            text = Regex.Replace(text, @"\\N", "\n");
            text = Regex.Replace(text, @"\{.*\}", "");
            return text;
        }
    }
}
