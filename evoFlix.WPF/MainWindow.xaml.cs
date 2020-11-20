using evoFlix.WPF.ViewModels;
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
        public MainWindow()
        {
            InitializeComponent();
            /*
            NavigationWindow navigationWdw = new NavigationWindow();
            navigationWdw.Height = this.Height;
            navigationWdw.Width = this.Width;
            navigationWdw.Show();
            navigationWdw.Navigate(new LoginPage());
            */

            Page DashBoard = new DashboardPage();
            this.Content = DashBoard;
            DashBoard.DataContext = new DashboardViewModel();


           
        }
    }
}
