using evoFlix.Services;
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

namespace evoFlix.WPF.Views
{
    /// <summary>
    /// Interaction logic for DeleteUserController.xaml
    /// </summary>
    public partial class DeleteUserController : UserControl
    {
        UserService userService = new UserService();
        UserComponentsService ucs = new UserComponentsService();

        public DeleteUserController()
        {
            InitializeComponent();
            test();
        }


        public void test()
        {
            Console.WriteLine("asd");
            
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            CheckUserName();

        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
            
        }

       
        private void CheckUserName()
        {
            if(userService.IsUniqueUsername(myUsername.Text))
            {
                Label label = error_text.Child as Label;
                label.Content = "There's no user with this name!";
                error_text.Visibility = Visibility.Visible;
            }
            else
            {
                Label label = error_text.Child as Label;
                label.Content = myUsername.Text+ " deleted successfully!";
                userService.DeleteUser(myUsername.Text);
                error_text.Visibility = Visibility.Visible;
            }
        }



        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Backed");
        }
    }
}
