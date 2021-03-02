using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace evoFlix.Models
{
    public static class SubtitleTextPropertiesProvider
    {
        public static SubtitleTextProperties Instance;
        static SubtitleTextPropertiesProvider()
        {
            Instance = new SubtitleTextProperties(); 
        }


        public class SubtitleTextProperties : INotifyPropertyChanged
        {
            private int fontSize;
            public int FontSize 
            {
                get { return this.fontSize; }
                set
                {
                    if (this.fontSize != value)
                    {
                        this.fontSize = value;
                        this.NotifyPropertyChanged("FontSize");
                    }
                } 
            }

            private Brush foreground;
            public Brush Foreground
            {
                get { return this.foreground; }
                set
                {
                    if (this.foreground != value)
                    {
                        this.foreground = value;
                        this.NotifyPropertyChanged("ForeGround");
                    }
                }
            }

            private FontFamily textFontFamily;
            public FontFamily TextFontFamily
            {
                get { return this.textFontFamily; }
                set
                {
                    if (this.textFontFamily != value)
                    {
                        this.textFontFamily = value;
                        this.NotifyPropertyChanged("TextFontFamily");
                    }
                }
            }
            public DropShadowEffect TextShadow { get; set; }
            public SubtitleTextProperties()
            {
                SetDefault();
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public void NotifyPropertyChanged(string propName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
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
        }

        

       
    }
}
