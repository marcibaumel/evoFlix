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

namespace evoFlix.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        UserService userService = new UserService();

        public MainWindow()
        {
            
            InitializeComponent();
            //DeleteAUser_Test();
            test_button();
        }

        /*
        public void DeleteAUser_Test()
        {
            string test = "Béla";
            userService.DeleteUser(test);
            test_button();

        }
        */



        public void test_button()
        {
            Console.WriteLine("asd");
        }

        public void creat_a_new_user()
        {
            test_button();

        }

      
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            test_button();
           
        }
        

        

        public void ImgLoad()
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

        private void Button_Click(object sender, RoutedEventArgs e)
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
