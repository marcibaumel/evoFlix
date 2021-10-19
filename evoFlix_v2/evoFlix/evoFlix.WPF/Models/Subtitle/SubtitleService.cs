using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace evoFlix.WPF.Models.Subtitle
{
    public class SubtitleService
    {
        public FileExtension GetExtension(string path)
        {
            try
            {
                return (FileExtension)Enum.Parse(typeof(FileExtension), Path.GetExtension(path).Substring(1), true);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("The provided file is not a supported subtitle type.");
            }
            
        }
        public void Sort(ISubtitle subtitle)
        {
            for (int i = 0; i < subtitle.SubtitleLines.Count; i++)
            {
                for (int j = 0; j < subtitle.SubtitleLines.Count; j++)
                {
                    if (subtitle.SubtitleLines[i].Begin < subtitle.SubtitleLines[j].Begin)
                    {
                        var temp = subtitle.SubtitleLines[i];
                        subtitle.SubtitleLines[i] = subtitle.SubtitleLines[j];
                        subtitle.SubtitleLines[j] = temp;
                    }
                }
            }
        }

        public int ConvertDateTimeToMilliSeconds(DateTime dateTime)
        {
            return (dateTime.Hour * 3600 + dateTime.Minute * 60 + dateTime.Second) * 1000 + dateTime.Millisecond;
        }

        public bool IsValidFileExtension(string extension)
        {
            extension = extension.Replace(".", "");
            foreach (var validExtension in Enum.GetValues(typeof(FileExtension)).Cast<FileExtension>())
            {
                if (extension.Equals(validExtension.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        public string RemoveTags(string str)
        {
            var tagRegex = new Regex(@"(?<tag></?.*?>)");
            var tagMatch = tagRegex.Match(str);
            while (tagMatch.Success)
            {
                str = str.Replace(tagMatch.Groups["tag"].Value, "");
                tagMatch = tagRegex.Match(str);
            }
            return str;
        }

        public string RemoveExtraSpaces(string str)
        {
            str = str.Trim();
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            return str;
        }

        public string RemoveFormatSpecifiers(string text)
        {
            text = Regex.Replace(text, @"\\N", "\n");
            text = Regex.Replace(text, @"\{.*\}", "");
            return text;
        }
    }
}
