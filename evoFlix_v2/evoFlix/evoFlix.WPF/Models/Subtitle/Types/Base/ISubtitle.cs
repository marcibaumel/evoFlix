using System.Collections.Generic;
using System.Windows.Media;

namespace evoFlix.WPF.Models.Subtitle
{
    public interface ISubtitle
    {
        string Path { get; set; }
        List<SubtitleLine> SubtitleLines { get; }
        int FontSize { get; set; }
        Brushes Foreground { get; set; }
        Brushes Background { get; set; }

        void Parse();

    }
}
