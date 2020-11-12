using evoFlix.Services;
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
        

        UserService userService = new UserService();

        public MainWindow()
        {
            
            InitializeComponent();
        }

        public void test_button()
        {
            Console.WriteLine("asd");
        }

        public void creat_a_new_user()
        {
            test_button();

        }

        public void delet_a_user_button()
        {

        }

        public void login_user()
        {

        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            test_button();
            //FrameRegister.Visibility = Visibility.Visible;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateUser cwObj = new CreateUser();
            stkTest.Children.Add(cwObj);
        }
    }
}
