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
            int user1_Id = ucs.listOfUsers()[1];
           
            if(user1_Id<0)
            {
                User1_Label.Content = "";
            }
            else
            {
                User1_Label.Content = ucs.getUserName(user1_Id).ToString();
            }
            
            int user2_Id = (int)ucs.listOfUsers()[1];
            int user3_Id = (int)ucs.listOfUsers()[1];
            int user4_Id = (int)ucs.listOfUsers()[0];

           
            User2_Label.Content = ucs.getUserName(user2_Id).ToString();
            User3_Label.Content = ucs.getUserName(user3_Id).ToString();
            User4_Label.Content = ucs.getUserName(user4_Id).ToString();

        }
        
        
        public void profilPitcureControl()
        {
            int user1_Id = (int)ucs.listOfUsers()[1];
            int user2_Id = (int)ucs.listOfUsers()[1];
            int user3_Id = (int)ucs.listOfUsers()[1];
            int user4_Id = (int)ucs.listOfUsers()[0];

            if (user1_Id == 0 || user1_Id<0)
            {

            }
            else
            {
                Image img1 = new Image();
                img1.Source = new BitmapImage(new Uri(@ucs.getUserProfilPitcure(user1_Id)));

                StackPanel stackPnl1 = new StackPanel();
                stackPnl1.Orientation = Orientation.Horizontal;
                stackPnl1.Margin = new Thickness(5);
                stackPnl1.Children.Add(img1);

                User1_Button.Content = stackPnl1;
            }


            
            Image img2 = new Image();
            Image img3 = new Image();
            Image img4 = new Image();


            
            img2.Source = new BitmapImage(new Uri(@ucs.getUserProfilPitcure(user2_Id)));
            img3.Source = new BitmapImage(new Uri(@ucs.getUserProfilPitcure(user3_Id)));
            img4.Source = new BitmapImage(new Uri(@ucs.getUserProfilPitcure(user4_Id)));


            

            StackPanel stackPnl2 = new StackPanel();
            stackPnl2.Orientation = Orientation.Horizontal;
            stackPnl2.Margin = new Thickness(5);
            stackPnl2.Children.Add(img2);

            StackPanel stackPnl3 = new StackPanel();
            stackPnl3.Orientation = Orientation.Horizontal;
            stackPnl3.Margin = new Thickness(5);
            stackPnl3.Children.Add(img3);

            StackPanel stackPnl4 = new StackPanel();
            stackPnl4.Orientation = Orientation.Horizontal;
            stackPnl4.Margin = new Thickness(5);
            stackPnl4.Children.Add(img4);

           
            User2_Button.Content = stackPnl2;
            User3_Button.Content = stackPnl3;
            User4_Button.Content = stackPnl4;



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
