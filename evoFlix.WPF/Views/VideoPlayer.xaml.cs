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
    ///     - Proper button image design missing
    ///     - Button imgage error fix
    ///     - Update slider tootip values (hh:mm:ss)
    /// 
    public partial class VideoPlayer : Page
    {
        private Page backPage;
        private Window main;
        private int savedTime;
        int startTime;
        bool IsDragged = false;
        public string StatusText { get; set; }

        public VideoPlayer(Page page, Window window)
        {
            InitializeComponent();

            backPage = page;
            main = window;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            slrProgress.Minimum = 0;
        }

        public VideoPlayer(Page page, Window window, int time)
            : this(page, window)
        {
            startTime = time;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (mdaVideo.NaturalDuration.HasTimeSpan && !IsDragged)
            {
                slrProgress.Value = mdaVideo.Position.TotalSeconds;
                slrProgress.Maximum = mdaVideo.NaturalDuration.TimeSpan.TotalSeconds;
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mdaVideo.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mdaVideo.Pause();
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mdaVideo.Position += TimeSpan.FromSeconds(10);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mdaVideo.Position -= TimeSpan.FromSeconds(10);
        }

        private void btnSound_Click(object sender, RoutedEventArgs e)
        {
            mdaVideo.Volume -= 0.1;
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
            {
                mdaVideo.Position = TimeSpan.FromSeconds(slrProgress.Value);
                StatusText = TimeSpan.FromSeconds(slrProgress.Value).ToString(@"hh\:mm\:ss");
            }
        }
    }
}
