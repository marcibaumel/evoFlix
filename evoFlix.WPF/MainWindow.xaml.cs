

using evoFlix.Services;
using evoFlix.WPF.ViewModels;
using evoFlix.WPF.Views;
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

namespace evoFlix.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Page log;
        public MainWindow()
        {
            InitializeComponent();

            ///*
            //NavigationWindow navigationWdw = new NavigationWindow();
            //navigationWdw.Height = this.Height;
            //navigationWdw.Width = this.Width;
            //navigationWdw.Show();
            //navigationWdw.Navigate(new LoginPage());
            //*/



            //this.Content = log = new LoginPage(this);

            this.Content = new VideoPlayer(new DashboardPage(this), this, "semmi");


            //Page DashBoard = new DashboardPage(this);
            //this.Content = DashBoard;
            //DashBoard.DataContext = new DashboardViewModel();





            //setFilmPage();










        }

        private void main_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        //public void setFilmPage()
        //{
        //    Page player = new VideoPlayer(this);
        //    this.Content = player;
        //}
    }
}
