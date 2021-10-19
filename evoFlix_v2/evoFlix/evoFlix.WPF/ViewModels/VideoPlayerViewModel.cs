using evoFlix.WPF.Commands;
using evoFlix.WPF.Models.Subtitle;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;



namespace evoFlix.WPF.ViewModels
{
    public class VideoPlayerViewModel : BaseViewModel
    {
        private SubtitleManager subtitleManager;
        private double volume;
        private ImageBrush muteButtonBackground;
        private string actualSubtitle;

        public DispatcherTimer VisibilityTimer { get; set; }
        public string Source { get; set; }

        public double Volume 
        {
            get => volume;
            set 
            { 
                SetField<double>(ref volume, value, nameof(Volume));
                ChangeMuteButton();
            } 
        }

        public string ActualSubtitle 
        {
            get => actualSubtitle;
            set => SetField<string>(ref actualSubtitle, value, nameof(ActualSubtitle));
        }

        public ImageBrush MuteButtonBackground 
        { 
            get => muteButtonBackground; 
            set => SetField<ImageBrush>(ref muteButtonBackground, value, nameof(MuteButtonBackground)); 
        }

        public RelayCommand MuteButtonCommand { get; set; }

        public VideoPlayerViewModel(string source)
        {
            MuteButtonCommand = new RelayCommand(MuteButtonExecute, MuteButtonCanExecute);

            subtitleManager = new SubtitleManager(source); //Source: path of the video (not the subtitle)

            Source = source;
            Volume = 10;

            Application.Current.MainWindow.Title = System.IO.Path.GetFileNameWithoutExtension(source);
        }

        private void MuteButtonExecute()
        {
            if (Volume == 0)
                Volume = 10;
            else
                Volume = 0;
            ChangeMuteButton();
        }
        private void ChangeMuteButton()
        {
            if (Volume == 0)
                MuteButtonBackground = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Resources/Images/Mute.png", UriKind.Relative)) };
            else
                MuteButtonBackground = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Resources/Images/Unmute.png", UriKind.Relative)) };
        }

        private bool MuteButtonCanExecute()
        {
            return true;
        }

    }
}
