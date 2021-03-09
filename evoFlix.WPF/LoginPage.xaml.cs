using evoFlix.Services;
using evoFlix.WPF.Views;
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
using evoFlix.Models.Users;
using evoFlix.WPF.Controls;

namespace evoFlix.WPF
{

    public partial class LoginPage : Page
    {
        Window window;

        UserService userService = new UserService();
        UserComponentsService ucs = new UserComponentsService();
        DeleteUserControl dlt = new DeleteUserControl();
        CreateUser cu = new CreateUser();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public LoginPage(Window window)
        {
            this.window = window;

            InitializeComponent();
            test_button();
            dlt.profileControl(User1_Label, User2_Label, User3_Label, User4_Label, User1_Button, User2_Button, User3_Button, User4_Button);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0,0,5);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            dlt.profileControl(User1_Label, User2_Label, User3_Label, User4_Label, User1_Button, User2_Button, User3_Button, User4_Button);
            Console.WriteLine("tick");
        }
        public void test_button()
        {
            Console.WriteLine("asd");
        }

       
        public void ChangeWindow()
        {
           
        }

        public void clear_data_context()
        {
            DataContext = null;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            clear_data_context();
            DataContext = new CreateUser();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            clear_data_context();
            DataContext = new LoginView(window);  
        }

        private void Delet_Click(object sender, RoutedEventArgs e)
        {
            clear_data_context();
            DataContext = new DeleteUserController();
        }
        private void Button_Click_Register(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            mainLogin.Visibility = Visibility.Hidden;
            sideAccounts.Visibility = Visibility.Visible;
        }
    }
}
