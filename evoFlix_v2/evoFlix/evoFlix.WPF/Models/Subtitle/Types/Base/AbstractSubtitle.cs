using System.Collections.Generic;
using System.Windows.Media;

namespace evoFlix.WPF.Models.Subtitle
{
    public abstract class AbstractSubtitle : ISubtitle
    {
        public string Path { get; set; }
        public List<SubtitleLine> SubtitleLines { get; protected set; } = new List<SubtitleLine>(); //readonly
        public int FontSize { get; set; }
        public Brushes Foreground { get; set; }
        public Brushes Background { get; set; }

        public abstract void Parse();
    }
}
