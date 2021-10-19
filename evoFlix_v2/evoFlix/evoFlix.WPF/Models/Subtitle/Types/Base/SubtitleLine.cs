using System;
using System.Text.RegularExpressions;

namespace evoFlix.WPF.Models.Subtitle
{
    public class SubtitleLine
    {

        public int Begin { get; set; }
        public int End { get; set; }
        public string Text { get; set; }
        public SubtitleLine(int begin, int end, string text)
        {
            Begin = begin;
            End = end;
            Text = text;
        }

        public override bool Equals(object obj)
        {
            SubtitleLine subtitleLine = obj as SubtitleLine;
            if (subtitleLine.Begin != Begin || subtitleLine.End != End || subtitleLine.Text != Text)
                return false;
            return true;
        }

    }
}
