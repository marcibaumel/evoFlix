using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace evoFlix.WPF.Models
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
            public DropShadowEffect TextShadow { get; set; }
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
                FontSize = 30;
                Foreground = Brushes.White;
                TextFontFamily = new FontFamily("Sugoe UI");
                SetTextShadow();
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
        }
    }
}
