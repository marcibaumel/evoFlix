using evoFlix.WPF.Models;
using evoFlix.WPF.Models.Subtitle;
using evoFlix.WPF.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;
using evoFlix.Models.Content;

namespace evoFlix.WPF.Views
{
    public partial class VideoPlayerWindow : Window
    {
        private readonly int startTime;
        private bool IsDragged = false;
        private readonly double totalVisibilityTime = 1.5;
        private bool maximized = false;
        private bool videoIsPaused = false;
        private bool showSubtitles = true;
        private FilmTableModel film;
        private DispatcherTimer visibilityTimer;
        private SubtitleManager subtitleManager;
        private VideoPlayerViewModel videoPlayerViewModel;
        private SubtitleSettingsView subtitleSettingsView;


        public VideoPlayerWindow(FilmTableModel film, int startTime)
        {
            InitializeComponent();
            this.film = film;
            this.startTime = startTime;
            WindowState = WindowState.Maximized;
            Title = System.IO.Path.GetFileNameWithoutExtension(film.Source);
            videoPlayerViewModel = new VideoPlayerViewModel(film.Source);
            maingrid.DataContext = videoPlayerViewModel;

            subtitleManager = new SubtitleManager(film.Source); //Source: path of the video (not the subtitle)
            Heap.SubManager = subtitleManager;

            if (subtitleManager.CurrentSubtitle == null)
                txtSubtitle.Visibility = Visibility.Hidden;
            else
            {
                txtSubtitle.Visibility = Visibility.Visible;
                btnCaption.IsEnabled = true;
                btnCaption.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Resources/Images/CaptionON.png", UriKind.Relative)) };
                showSubtitles = true;
            }

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.01);
            timer.Tick += timer_Tick;
            timer.Start();

            visibilityTimer = new DispatcherTimer();
            visibilityTimer.Interval = TimeSpan.FromSeconds(totalVisibilityTime);
            visibilityTimer.Tick += visibilityTimer_Tick;


            slrSoundBar.Value = mdaVideo.Volume * 100;
            KeyDown += new KeyEventHandler(Page_KeyDown);

            SubtitleTextPropertiesProvider.Instance.WindowHeight = Height;
            SubtitleTextPropertiesProvider.Instance.SetPosition();

            subtitleSettingsView = new SubtitleSettingsView(settingsFrame, film);
            settingsFrame.Content = subtitleSettingsView;
        }

        private void visibilityTimer_Tick(object sender, EventArgs e)
        {
            if (settingsFrame.Visibility == Visibility.Hidden)
            {
                visibilityTimer.Stop();
                grdButtons.Visibility = Visibility.Hidden;
                Cursor = Cursors.None;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (mdaVideo.NaturalDuration.HasTimeSpan && !IsDragged)
            {
                slrProgress.Value = mdaVideo.Position.TotalSeconds;
                slrProgress.Maximum = mdaVideo.NaturalDuration.TimeSpan.TotalSeconds;
                string actual = mdaVideo.Position.ToString(@"hh\:mm\:ss");
                string total = mdaVideo.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss");
                lblProgress.Content = $"{actual} / {total}";
                if (subtitleManager.CurrentSubtitle != null)
                {
                    if (btnCaption.IsEnabled == false)
                    {
                        btnCaption.IsEnabled = true;
                        txtSubtitle.Visibility = Visibility.Visible;
                        showSubtitles = true;
                        ChangeCaptionButton();
                    }
                    
                    if (showSubtitles)
                        txtSubtitle.Text = subtitleManager.GetText(mdaVideo.Position.TotalMilliseconds);
                }
            }

        }

        private void btnCaption_Click(object sender, RoutedEventArgs e)
        {
            if (showSubtitles)
            {
                showSubtitles = false;
                txtSubtitle.Visibility = Visibility.Hidden;
            }
            else
            {
                showSubtitles = true;
                txtSubtitle.Visibility = Visibility.Visible;
            }
            ChangeCaptionButton();
        }

        private void mdaVideo_Loaded(object sender, RoutedEventArgs e)
        {
            mdaVideo.Play();
            mdaVideo.Position = TimeSpan.FromSeconds(startTime);
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            mdaVideo.Position += TimeSpan.FromSeconds(30);

        }

        private void btnRewind_Click(object sender, RoutedEventArgs e)
        {
            mdaVideo.Position -= TimeSpan.FromSeconds(30);
        }

        private void slrProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            mdaVideo.Position = TimeSpan.FromSeconds(slrProgress.Value);
            IsDragged = false;
        }

        private void slrProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            IsDragged = true;
        }

        private void slrProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsDragged)
                mdaVideo.Position = TimeSpan.FromSeconds(slrProgress.Value);
        }

        private void grdVideo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
                if (maximized)
                {
                    this.WindowStyle = WindowStyle.None;
                    this.WindowState = WindowState.Maximized;
                    maximized = false;
                    mdaVideo.Play();
                }
                else
                {
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                    this.WindowState = WindowState.Normal;
                    maximized = true;
                    mdaVideo.Play();
                }
            else if (e.ClickCount == 1)
            {
                if (videoIsPaused)
                {
                    mdaVideo.Play();
                    videoIsPaused = false;
                }
                else
                {
                    mdaVideo.Pause();
                    videoIsPaused = true;
                }
                ChangePlayButton();
            }

        }

        private void ChangePlayButton()
        {
            if (videoIsPaused)
                btnPlay.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Resources/Images/Play.png", UriKind.Relative)) };
            else
                btnPlay.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Resources/Images/Pause.png", UriKind.Relative)) };

        }

        private void ChangeCaptionButton()
        {
            if (showSubtitles)
                btnCaption.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Resources/Images/CaptionON.png", UriKind.Relative)) };
            else
                btnCaption.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Resources/Images/CaptionOFF.png", UriKind.Relative)) };
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.WindowState = WindowState.Normal;
                this.WindowStyle = WindowStyle.SingleBorderWindow;
            }
            else if (e.Key == Key.Space)
            {
                if (videoIsPaused)
                {
                    mdaVideo.Play();
                    videoIsPaused = false;
                }
                else
                {
                    mdaVideo.Pause();
                    videoIsPaused = true;
                }
                ChangePlayButton();
            }
        }

        private void Page_MouseMove(object sender, MouseEventArgs e)
        {
            if (settingsFrame.Visibility == Visibility.Hidden)
            {
                visibilityTimer.Stop();
                grdButtons.Visibility = Visibility.Visible;
                Cursor = Cursors.Arrow;
                visibilityTimer.Start();
                e.Handled = true;
            }
        }

        private void grdButtons_MouseEnter(object sender, MouseEventArgs e)
        {
            visibilityTimer.Stop();
        }

        private void grdButtons_MouseLeave(object sender, MouseEventArgs e)
        {
            visibilityTimer.Start();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (videoIsPaused)
            {
                mdaVideo.Play();
                btnPlay.ToolTip = "Pause";
                videoIsPaused = false;
            }
            else
            {
                mdaVideo.Pause();
                btnPlay.ToolTip = "Play";
                videoIsPaused = true;
            }
            ChangePlayButton();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            mdaVideo.Pause();
            btnPlay.ToolTip = "Play";
            videoIsPaused = true;
            ChangePlayButton();
            settingsFrame.Visibility = Visibility.Visible;
            grdButtons.Visibility = Visibility.Hidden;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            double backTime = mdaVideo.Position.TotalMilliseconds;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SubtitleTextPropertiesProvider.Instance.WindowHeight = this.ActualHeight;
        }
    }
}
