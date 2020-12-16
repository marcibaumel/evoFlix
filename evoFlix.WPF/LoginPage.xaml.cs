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

namespace evoFlix.WPF
{
   
    public partial class LoginPage : Page
    {
        

        UserService userService = new UserService();
        UserComponentsService ucs = new UserComponentsService();

        public LoginPage()
        {
            
            InitializeComponent();
            test_button();

            ucs.writeOutListOfUser();

            

            /*
            var list = new List<UserDB>(ucs.listOfUsers().ToString());
            string.ForEach(Console.WriteLine);
            */

            
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
            DataContext = new LoginView();
              
        }

        private void Delet_Click(object sender, RoutedEventArgs e)
        {
            clear_data_context();
            DataContext = new DeleteUserController();
        }
    }
}
