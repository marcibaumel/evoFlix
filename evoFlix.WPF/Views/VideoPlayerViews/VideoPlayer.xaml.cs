using evoFlix.Services;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using evoFlix.WPF.Models;

namespace evoFlix.WPF.Views
{
    /// TO-DO:
    ///     - Add styles to the buttons
    ///     - Clean up code
    ///     -------------------------------------------
    ///     - Load the given video
    ///     - Proper button image design missing
    ///     - Fix button imgage error
    public partial class VideoPlayer : Page
    {

        private Window main;
        private int savedTime;
        private Page backPage;
        private int startTime;
        private bool IsDragged = false;
        private int totalVisibilityTime = 2;
        private bool maximized = false;
        private bool videoIsPaused = false;
        private bool showSubtitles = true;
        private DispatcherTimer visibilityTimer;
        public string Source { get; set; }
        private Subtitle subtitle;
        private FilmService fS = new FilmService();
        private VideoSettingsWindow settings;

        public VideoPlayer(Page page, Window window, String Title)
        {
            //String sourcePath = fS.getSource(Title);

            //if(sourcePath=="Failed")
            //{
            //    Source = @"D:\Letöltések\Shingeki no Kyojin S01-S03 (BD_1920x1080)\[ReinForce] Shingeki no Kyojin - 01 (BDRip 1920x1080 x264 FLAC).mkv";
            //}
            //else
            //{
            //    Source = @sourcePath;
            //}

            //Only works with .srt and .ass
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            Source = openFileDialog.FileName;
            
            //Source = @"D:\Letöltések\Shingeki no Kyojin S01-S03 (BD_1920x1080)\[ReinForce] Shingeki no Kyojin - 01 (BDRip 1920x1080 x264 FLAC).mkv";
            //Source = @"C:\Users\Asus\Downloads\Inuyasha S06\Inuyasha - 139 - Nagy csata a Shouun vízesésnél.mkv";
            subtitle = new Subtitle(Source); //Source: path of the video (not the subtitle)
            Heap.ActualSubtitle = subtitle;
            settings = new VideoSettingsWindow();

            InitializeComponent();

            SubtitleTextPropertiesProvider.Instance.WindowHeight = Application.Current.MainWindow.Height;
            SubtitleTextPropertiesProvider.Instance.SetPosition();
            

            maingrid.DataContext = this;
            if (subtitle != null)
            {
                btnCaption.IsEnabled = true;
                btnCaption.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Images\Icons\CaptionON.png", UriKind.Relative)) };
                showSubtitles = true;
            }

            main = window;
            main.Title = System.IO.Path.GetFileNameWithoutExtension(Source);
            backPage = page;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.01);
            timer.Tick += timer_Tick;
            timer.Start();

            visibilityTimer = new DispatcherTimer();
            visibilityTimer.Interval = TimeSpan.FromSeconds(totalVisibilityTime);
            visibilityTimer.Tick += visibilityTimer_Tick;


            slrSoundBar.Value = mdaVideo.Volume * 100;
            main.KeyDown += new KeyEventHandler(Page_KeyDown);
        }

        //public VideoPlayer(Page page, Window window, int time)
        //    : this(page, window)
        //{
        //    startTime = time;
        //}

        //public VideoPlayer(Page page, Window window, string Title)
        //   : this(page, window)
        //{
            
        //}

        private void visibilityTimer_Tick(object sender, EventArgs e)
        {
            visibilityTimer.Stop();
            grdButtons.Visibility = Visibility.Hidden;
            Cursor = Cursors.None;
            
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
                if (Heap.ActualSubtitle.Source != null)
                    txtSubtitle.Text = subtitle.GetActualText(mdaVideo.Position.TotalMilliseconds);
            }
            
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            savedTime = (int) mdaVideo.Position.TotalSeconds;
            MessageBox.Show(savedTime.ToString());
            main.Content = backPage;
            main.WindowState = WindowState.Normal;
            main.WindowStyle = WindowStyle.SingleBorderWindow;
            main.Title = "EvoFlix";
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            mdaVideo.Position += TimeSpan.FromSeconds(30);
        }

        private void btnRewind_Click(object sender, RoutedEventArgs e)
        {
            mdaVideo.Position -= TimeSpan.FromSeconds(30);
        }

        private void btnMute_Click(object sender, RoutedEventArgs e)
        {
            if (mdaVideo.Volume == 0)
                slrSoundBar.Value = 10;
            else
                slrSoundBar.Value = 0;
        }

        private void slrProgress_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            mdaVideo.Position = TimeSpan.FromSeconds(slrProgress.Value);
            IsDragged = false;
        }

        private void slrProgress_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            IsDragged = true;
        }

        private void slrProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsDragged)
                mdaVideo.Position = TimeSpan.FromSeconds(slrProgress.Value);
        }

        private void slrSoundBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mdaVideo.Volume = slrSoundBar.Value / 100;
            ChangeMuteButton();

        }

        private void grdVideo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
                if (maximized)
                {
                    main.WindowStyle = WindowStyle.None;
                    main.WindowState = WindowState.Maximized;
                    maximized = false;
                    mdaVideo.Play();
                }
                else
                {
                    main.WindowStyle = WindowStyle.SingleBorderWindow;
                    main.WindowState = WindowState.Normal;
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

        private void ChangeMuteButton()
        {
            if (mdaVideo.Volume == 0) 
                btnMute.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Images\Icons\Mute.png", UriKind.Relative)) };
            else
                btnMute.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Images\Icons\Unmute.png", UriKind.Relative)) };

        }

        private void ChangePlayButton()
        {
            if (videoIsPaused)
                btnPlay.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Images\Icons\Play.png", UriKind.Relative)) };
            else
                btnPlay.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Images\Icons\Pause.jpg", UriKind.Relative)) };

        }

        private void ChangeCaptionButton()
        {
            if (showSubtitles)
                btnCaption.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Images\Icons\CaptionON.png", UriKind.Relative)) };
            else
                btnCaption.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Images\Icons\CaptionOFF.png", UriKind.Relative)) };
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                main.WindowState = WindowState.Normal;
                main.WindowStyle = WindowStyle.SingleBorderWindow;
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
            visibilityTimer.Stop();
            grdButtons.Visibility = Visibility.Visible;
            Cursor = Cursors.Arrow;
            visibilityTimer.Start();
            e.Handled = true;
        }

        private void grdButtons_MouseEnter(object sender, MouseEventArgs e)
        {
            visibilityTimer.Stop();
        }

        private void grdButtons_MouseLeave(object sender, MouseEventArgs e)
        {
            visibilityTimer.Start();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            
            settings.Show();
        }

        private void player_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SubtitleTextPropertiesProvider.Instance.WindowHeight = Application.Current.MainWindow.Height;
            SubtitleTextPropertiesProvider.Instance.SetPosition();
        }
    }
}
