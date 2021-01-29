using evoFlix.Models;
using evoFlix.Services;
using evoFlix.WPF.DashboardViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

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
        int startTime;
        bool IsDragged = false;
        int totalVisibilityTime = 3;
        bool maximized = false;
        bool videoIsPaused = false;
        DispatcherTimer visibilityTimer;
        public string Source { get; set; }
        Subtitle subtitle;
        FilmService fS = new FilmService();

        public VideoPlayer(Page page, Window window, String Title)
        {
            
            InitializeComponent();

            maingrid.DataContext = this;

            //String sourcePath = fS.getSource(Title);

            //if(sourcePath=="Failed")
            //{
            //    Source = @"D:\Letöltések\Shingeki no Kyojin S01-S03 (BD_1920x1080)\[ReinForce] Shingeki no Kyojin - 01 (BDRip 1920x1080 x264 FLAC).mkv";
            //}
            //else
            //{
            //    Source = @sourcePath;
            //}

            Source = @"D:\Letöltések\Shingeki no Kyojin S01-S03 (BD_1920x1080)\[ReinForce] Shingeki no Kyojin - 01 (BDRip 1920x1080 x264 FLAC).mkv";
            //currently only works with .ass extension
            subtitle = new Subtitle(@"D:\Letöltések\Shingeki no Kyojin S01-S03 (BD_1920x1080)\[ReinForce] Shingeki no Kyojin - 01 (BDRip 1920x1080 x264 FLAC).ass");
            main = window;
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
                mainSubtitle.Text = subtitle.GetActualText(mdaVideo.Position.TotalSeconds);
            }
            
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mdaVideo.Play();
            videoIsPaused = false;
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mdaVideo.Pause();
            videoIsPaused = true;
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
            //main.Content = new DashboardPage();
            main.WindowState = WindowState.Normal;
            main.WindowStyle = WindowStyle.SingleBorderWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mdaVideo.Position += TimeSpan.FromSeconds(30);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mdaVideo.Position -= TimeSpan.FromSeconds(30);
        }

        private void btnSound_Click(object sender, RoutedEventArgs e)
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

        //private void grdVideo_MouseMove(object sender, MouseEventArgs e)
        //{
        //    visibilityTimer.Stop();
        //    grdButtons.Visibility = Visibility.Visible;
        //    Cursor = Cursors.Arrow;
        //    visibilityTimer.Start();
        //}

        private void slrSoundBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mdaVideo.Volume = slrSoundBar.Value / 100;
            ChangeSoundButton();

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
        }

        private void ChangeSoundButton()
        {
            if (mdaVideo.Volume == 0) 
                btnSound.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Images\Icons\Mute.png", UriKind.Relative)) };
            else
                btnSound.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri(@"Images\Icons\Unmute.png", UriKind.Relative)) };

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
    }
}
