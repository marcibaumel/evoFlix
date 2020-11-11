using evoFlix.Models.Users;
using evoFlix.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace evoFlix.WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        UserService userService = new UserService();
        public LoginView()
        {
            InitializeComponent();
        }

        public void test()
        {
            Console.WriteLine("asd");
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            CheckUser();

        }
        private void CheckUser()
        {
            if (!userService.IsUniqueUsername(myUsername.Text))
            {
                if (userService.IsExistingPassword(myUsername.Text, myPassword.Password))
                {
                    Label label = error_text.Child as Label;
                    label.Content = "The Password is incorrect! Please try again!";
                    error_text.Visibility = Visibility.Visible;
                }
                else
                {
                    error_text.Visibility = Visibility.Hidden;
                    Label label = scfLogin_text.Child as Label;
                    label.Content = "You have logged in succesfully!";
                    scfLogin_text.Visibility = Visibility.Visible;
                    Console.WriteLine("Log in");
                }
            }else
            {
                Label label = error_text.Child as Label;
                label.Content = "The Username is incorrect! Please try again!";
                error_text.Visibility = Visibility.Visible;
            }
        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Backed");
        }
    }
}
