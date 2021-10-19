using System;
using System.Collections.Generic;
using System.IO;

namespace evoFlix.WPF.Models.Subtitle
{
    public class SubtitleManager
    {
        public ISubtitle CurrentSubtitle { get; set; }
        public List<string> AvailableSubtitlePaths { get; set; }

        private SubtitleService subtitleService = new SubtitleService();

        public SubtitleManager(string source)
        {
            AvailableSubtitlePaths = ReturnAvailableSources(source);
            if (AvailableSubtitlePaths.Count > 0)
                SetCurrentSubtitle(AvailableSubtitlePaths[0]);
        }

        public void SetCurrentSubtitle(string source)
        {
            CurrentSubtitle = SubtitleFactory.CreateSubtitle(source);
            subtitleService.Sort(CurrentSubtitle);
        }

        public string GetText(double currentTime)
        {
            int index = -1;
            for (int i = 0; i < CurrentSubtitle.SubtitleLines.Count; i++)
                if (CurrentSubtitle.SubtitleLines[i].Begin <= currentTime &&
                    CurrentSubtitle.SubtitleLines[i].End >= currentTime)
                    { index = i; break; }

            if (index < 0)
                return "";

            return CurrentSubtitle.SubtitleLines[index].Text;
        }

        public List<string> ReturnAvailableSources(string path)
        {
            string videoFolderPath = Path.GetDirectoryName(path);
            string videoName = Path.GetFileNameWithoutExtension(path);
            string videoExtension = Path.GetExtension(path);

            string[] subtitlePaths = Directory.GetFiles(videoFolderPath, videoName + ".*");

            var availableSubtitlePaths = new List<string>();

            foreach (var item in subtitlePaths)
            {
                string ext = Path.GetExtension(item);

                if (subtitleService.IsValidFileExtension(ext))
                    availableSubtitlePaths.Add(item);
            }

            return availableSubtitlePaths;
        }

        public void AddSubtitlePath(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentException("The file does not exist!");

            if (!subtitleService.IsValidFileExtension(System.IO.Path.GetExtension(path)))
                throw new ArgumentException("The given given file is not a subtitle or not a supported subtitle");

            AvailableSubtitlePaths.Add(path);
        }
    }
}
