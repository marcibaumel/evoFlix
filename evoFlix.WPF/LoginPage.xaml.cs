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
            labelControl();
            profilPitcureControl();


        }

       
      
        public void test_button()
        {
            Console.WriteLine("asd");
            
            
        }

       
        public void labelControl()
        {
      
            int user1_Id = (int)ucs.listOfUsers()[0];
            int user2_Id = (int)ucs.listOfUsers()[1];
            int user3_Id = (int)ucs.listOfUsers()[2];
            int user4_Id = (int)ucs.listOfUsers()[3];
            
            User1_Label.Content = ucs.getUserName(user1_Id).ToString();
            User2_Label.Content = ucs.getUserName(user2_Id).ToString();
            User3_Label.Content = ucs.getUserName(user3_Id).ToString();
            User4_Label.Content = ucs.getUserName(user4_Id).ToString();

        }
        
        public void profilPitcureControl()
        {
            int user1_Id = (int)ucs.listOfUsers()[0];
            int user2_Id = (int)ucs.listOfUsers()[1];
            int user3_Id = (int)ucs.listOfUsers()[2];
            int user4_Id = (int)ucs.listOfUsers()[3];

            Image img1 = new Image();
            img1.Source = new BitmapImage(new Uri(@ucs.getUserProfilPitcure(user3_Id)));

            
            StackPanel stackPnl = new StackPanel();
            stackPnl.Orientation = Orientation.Horizontal;
            stackPnl.Margin = new Thickness(10);
            stackPnl.Children.Add(img1);
            
            User1_Button.Content = stackPnl;



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
