using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace evoFlix.WPF.Models.Subtitle
{
    public class SubtitleTextPropertiesProvider
    {
        public static SubtitleTextProperties Instance;
        static SubtitleTextPropertiesProvider()
        {
            Instance = new SubtitleTextProperties();
        }


        public class SubtitleTextProperties : INotifyPropertyChanged
        {
            public double Ratio { get; set; }
            public double WindowHeight { get; set; }

            private double position;
            public double Position
            {
                get { return position; }
                set
                {
                    if (position != value)
                    {
                        position = value;
                        NotifyPropertyChanged("Position");
                    }
                }
            }

            public int DefaultFontSize { get => 30; }

            private int fontSize;
            public int FontSize
            {
                get { return fontSize; }
                set
                {
                    if (fontSize != value)
                    {
                        fontSize = value;
                        NotifyPropertyChanged("FontSize");
                    }
                }
            }

            public Brush DefaultForeground { get => Brushes.White; }

            private Brush foreground;
            public Brush Foreground
            {
                get { return foreground; }
                set
                {
                    if (foreground != value)
                    {
                        foreground = value;
                        NotifyPropertyChanged("ForeGround");
                    }
                }
            }


            public FontFamily DefaultFontFamily { get; set; }
            private FontFamily textFontFamily;
            public FontFamily TextFontFamily
            {
                get { return textFontFamily; }
                set
                {
                    if (textFontFamily != value)
                    {
                        textFontFamily = value;
                        NotifyPropertyChanged("TextFontFamily");
                    }
                }
            }

            public DropShadowEffect DefaultTextShadow { get => new DropShadowEffect { ShadowDepth = 1, BlurRadius = 5, Opacity = 1, Direction = 180 }; }
            private DropShadowEffect textShadow;
            public DropShadowEffect TextShadow
            {
                get { return textShadow; }
                set
                {
                    if (textShadow != value)
                    {
                        textShadow = value;
                        NotifyPropertyChanged("TextShadow");
                    }
                }
            }
            public SubtitleTextProperties()
            {
                SetDefault();
                SetRatio(4, 5);
                SetPosition();
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public void NotifyPropertyChanged(string propName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }

            public void SetDefault()
            {
                FontSize = DefaultFontSize;
                Foreground = DefaultForeground;
                TextFontFamily = DefaultFontFamily;
                TextShadow = DefaultTextShadow;
            }

            public void SetTextShadow()
            {
                TextShadow = new DropShadowEffect();
                TextShadow.ShadowDepth = 1;
                TextShadow.BlurRadius = 5;
                TextShadow.Opacity = 1;
                TextShadow.Direction = 180;
            }

            public void ClearTextShadow()
            {
                TextShadow = null;
            }

            public void SetRatio(double samplePosition, double sampleCanvasActualHeight)
            {
                Ratio = samplePosition / sampleCanvasActualHeight;
            }
            public void SetPosition()
            {
                Position = WindowHeight * Ratio;
            }

            public void SetDefaultPosition()
            {
                Position = WindowHeight * 0.9;
            }
        }
    }
}
