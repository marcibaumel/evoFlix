using System;

namespace evoFlix.WPF.Models.Subtitle
{
    public static class SubtitleFactory
    {
        private static SubtitleService subtitleService = new SubtitleService();
        public static ISubtitle CreateSubtitle(string source)
        {
            switch (subtitleService.GetExtension(source))
            {
                case FileExtension.ASS:
                    return new AssSubtitle(source);
                case FileExtension.SRT:
                    return new SrtSubtitle(source);
                default:
                    throw new ArgumentException("Wrong subtitle extension!");
            }
        }
    }
}
