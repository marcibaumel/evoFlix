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
            int user1_Id;
            int user2_Id;
            int user3_Id;
            int user4_Id;

            try
            {
                user1_Id = ucs.listOfUsers()[0];
                User1_Label.Content = ucs.getUserName(user1_Id).ToString();

            }
            catch(ArgumentOutOfRangeException e)
            {
                User1_Label.Content = "";
                Console.WriteLine(e.Message);
            }


            try
            {
                user2_Id = ucs.listOfUsers()[1];
                User2_Label.Content = ucs.getUserName(user2_Id).ToString();

            }
            catch (ArgumentOutOfRangeException e)
            {
                User2_Label.Content = "";
                Console.WriteLine(e.Message);
            }


            try
            {
                user3_Id = ucs.listOfUsers()[2];
                User3_Label.Content = ucs.getUserName(user3_Id).ToString();

            }
            catch (ArgumentOutOfRangeException e)
            {
                User3_Label.Content = "";
                Console.WriteLine(e.Message);
            }


            try
            {
                user4_Id = ucs.listOfUsers()[3];
                User4_Label.Content = ucs.getUserName(user4_Id).ToString();

            }
            catch (ArgumentOutOfRangeException e)
            {
                User4_Label.Content = "";
                Console.WriteLine(e.Message);
            }

        }
        
        
        public void profilPitcureControl()
        {
            
           

            int user1_Id;
            int user2_Id;
            int user3_Id;
            int user4_Id;
            

            try
            {
                user1_Id = ucs.listOfUsers()[0];
                Image img1 = new Image();
                img1.Source = new BitmapImage(new Uri(@ucs.getUserProfilPitcure(user1_Id)));

                StackPanel stackPnl1 = new StackPanel();
                stackPnl1.Orientation = Orientation.Horizontal;
                stackPnl1.Margin = new Thickness(5);
                stackPnl1.Children.Add(img1);

                User1_Button.Content = stackPnl1;


            }
            catch (ArgumentOutOfRangeException e)
            {
                
                Console.WriteLine(e.Message);
                User1_Button.Content = "";
            }


            try
            {
                user2_Id = ucs.listOfUsers()[1];
                Image img2 = new Image();
                img2.Source = new BitmapImage(new Uri(@ucs.getUserProfilPitcure(user2_Id)));

                StackPanel stackPnl2 = new StackPanel();
                stackPnl2.Orientation = Orientation.Horizontal;
                stackPnl2.Margin = new Thickness(5);
                stackPnl2.Children.Add(img2);

                User2_Button.Content = stackPnl2;


            }
            catch (ArgumentOutOfRangeException e)
            {

                Console.WriteLine(e.Message);
                User2_Button.Content = "";
            }


            try
            {
                user3_Id = ucs.listOfUsers()[2];
                Image img3 = new Image();
                img3.Source = new BitmapImage(new Uri(@ucs.getUserProfilPitcure(user3_Id)));

                StackPanel stackPnl3 = new StackPanel();
                stackPnl3.Orientation = Orientation.Horizontal;
                stackPnl3.Margin = new Thickness(5);
                stackPnl3.Children.Add(img3);

                User3_Button.Content = stackPnl3;


            }
            catch (ArgumentOutOfRangeException e)
            {

                Console.WriteLine(e.Message);
                User3_Button.Content = "";
            }

            try
            {
                user4_Id = ucs.listOfUsers()[3];
                Image img4 = new Image();
                img4.Source = new BitmapImage(new Uri(@ucs.getUserProfilPitcure(user4_Id)));

                StackPanel stackPnl4 = new StackPanel();
                stackPnl4.Orientation = Orientation.Horizontal;
                stackPnl4.Margin = new Thickness(5);
                stackPnl4.Children.Add(img4);

                User4_Button.Content = stackPnl4;


            }
            catch (ArgumentOutOfRangeException e)
            {

                Console.WriteLine(e.Message);
                User4_Button.Content = "";
            }

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

          
            labelControl();
            profilPitcureControl();
        }
    }
}
