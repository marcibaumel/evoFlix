using evoFlix.Services;
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

namespace evoFlix.WPF.DashboardViews
{
    /// <summary>
    /// Interaction logic for Accounts.xaml
    /// </summary>
    public partial class Accounts : UserControl
    {
        UserService userService = new UserService();
        UserComponentsService ucs = new UserComponentsService();
        MainWindow mW = new MainWindow();
        HomeViewModel hVM = new HomeViewModel();

        public Accounts()
        {
            InitializeComponent();
            int UserId = Heap.ActualUserId;
            UserNameLabel.Content = ucs.getUserName(UserId);
        }

        public void Sign_Out(object sender, RoutedEventArgs e)
        {
            LoginPage log = new LoginPage(hVM.mainWindow);
            hVM.mainWindow.Content = log;
        }
    }
}
