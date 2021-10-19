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

namespace evoFlix.WPF.Controls
{
    public class DeleteUserControl
    {
        UserService userService = new UserService();
        UserComponentsService ucs = new UserComponentsService();

        public DeleteUserControl()
        {

        }

        public void profileControl( Label User1_Label, Label User2_Label, Label User3_Label, Label User4_Label, Button User1_Button, Button User2_Button, Button User3_Button, Button User4_Button)
        {
            int user_Id;

            try
            {
                user_Id = ucs.listOfUsers()[0];
                User1_Label.Content = ucs.getUserName(user_Id).ToString();
                Image img1 = new Image();
                img1.Source = new BitmapImage(new Uri(@ucs.getUserProfilPitcure(user_Id)));

                StackPanel stackPnl1 = new StackPanel();
                stackPnl1.Orientation = Orientation.Horizontal;
                stackPnl1.Margin = new Thickness(5);
                stackPnl1.Children.Add(img1);

                User1_Button.Content = stackPnl1;
            }
            catch (ArgumentOutOfRangeException e)
            {
                User1_Label.Content = "";
                User1_Button.Content = "";
                Console.WriteLine(e.Message);
            }


            try
            {
                user_Id = ucs.listOfUsers()[1];
                User2_Label.Content = ucs.getUserName(user_Id).ToString();

                Image img2 = new Image();
                img2.Source = new BitmapImage(new Uri(@ucs.getUserProfilPitcure(user_Id)));

                StackPanel stackPnl2 = new StackPanel();
                stackPnl2.Orientation = Orientation.Horizontal;
                stackPnl2.Margin = new Thickness(5);
                stackPnl2.Children.Add(img2);

                User2_Button.Content = stackPnl2;

            }
            catch (ArgumentOutOfRangeException e)
            {
                User2_Label.Content = "";
                User2_Button.Content = "";
                Console.WriteLine(e.Message);
            }


            try
            {
                user_Id = ucs.listOfUsers()[2];
                User3_Label.Content = ucs.getUserName(user_Id).ToString();

                Image img3 = new Image();
                img3.Source = new BitmapImage(new Uri(@ucs.getUserProfilPitcure(user_Id)));

                StackPanel stackPnl3 = new StackPanel();
                stackPnl3.Orientation = Orientation.Horizontal;
                stackPnl3.Margin = new Thickness(5);
                stackPnl3.Children.Add(img3);

                User3_Button.Content = stackPnl3;
            }
            catch (ArgumentOutOfRangeException e)
            {
                User3_Label.Content = "";
                User3_Button.Content = "";
                Console.WriteLine(e.Message);
            }


            try
            {
                user_Id = ucs.listOfUsers()[3];
                User4_Label.Content = ucs.getUserName(user_Id).ToString();

                Image img4 = new Image();
                img4.Source = new BitmapImage(new Uri(@ucs.getUserProfilPitcure(user_Id)));

                StackPanel stackPnl4 = new StackPanel();
                stackPnl4.Orientation = Orientation.Horizontal;
                stackPnl4.Margin = new Thickness(5);
                stackPnl4.Children.Add(img4);

                User4_Button.Content = stackPnl4;
            }
            catch (ArgumentOutOfRangeException e)
            {
                User4_Label.Content = "";
                User4_Button.Content = "";
                Console.WriteLine(e.Message);
            }

        }


    }
}
