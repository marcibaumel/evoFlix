using evoFlix.Models.Users;
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
    //TO-DO:
    //- SELECT LOCAL IMAGE BUTTON
    //- INPUT VALIDATION
    //- STRORE USER OBJECT IN DATABASE
    //- ERRORLIST

    
    public partial class CreateUser : UserControl
    {
        public enum Month
        { January=1, February, March, April, May, June, July, August, September, October, November, December}
        string[] month = { "January", "February", "March", "April", "May",
                           "June", "July", "August", "September", "October", "November", "December"};
        string[] pictures = { "kep1.jpg", "kep2.jpg", "kep3.jpg", "kep4.jpg" };
        Brush selectedPicture;
        List<int> year, day;
        UserService userService = new UserService();
        

        public CreateUser()
        {
            InitializeComponent();
            
            cmbMonth.ItemsSource = month;
            day = new List<int>();
            cmbDay.ItemsSource = new string[] { "Select month first!" };
            year = new List<int>();
            for (int i = 0; i < 100; i++)
                year.Add(DateTime.Now.Year - i);
            cmbYear.ItemsSource = year;
            
            for (int i = 0; i < pictures.Length; i++)
            {
                grdPictures.ColumnDefinitions.Add(new ColumnDefinition());
                Button button = new Button();
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(@"Images/" + pictures[i], UriKind.Relative));
                button.Background = brush;
                button.AddHandler(Button.ClickEvent, new RoutedEventHandler(button_click));

                Border border = new Border();
                border.Margin = new Thickness(5, 0, 5, 0);
                border.Child = button;
                border.BorderBrush = Brushes.Red;
                border.BorderThickness = new Thickness(0);
                border.CornerRadius = new CornerRadius(1);
                Grid.SetColumn(border, i);
                Grid.SetRow(border, 1);
                grdPictures.Children.Add(border);
            }
        }

        public void button_click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Border border = (Border)button.Parent;
            selectedPicture = button.Background;     
            foreach (Border imageBorder in grdPictures.Children)
                imageBorder.BorderThickness = new Thickness(0);
            border.BorderThickness = new Thickness(2);
        }

        /*DONE button
         * ezzel mentjük el az adatbázisba az elemeket*/
        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            int year = Convert.ToInt32(cmbYear.SelectedItem);
            int month = MonthValue(cmbMonth.SelectedItem.ToString());
            int day = Convert.ToInt32(cmbDay.SelectedItem);

            string userName = txbUsername.Text;
            string password = txbPassword.Password;
            DateTime birthDate = new DateTime(year, month, day);
            int age = GetAge(birthDate);
            Brush picture = selectedPicture;        //Usage: xyz.Background = picture;
            //userService.CreateUser(new User { Username =  userName, Age = age, Password = password});
            Console.WriteLine("asd");

        }


        /*Itt jó lenne ha egy dátumot adna vissza*/
        private void cmbMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] day30 = { "April", "June", "September", "November" };
            int year = Convert.ToInt32(cmbYear.SelectedItem);
            day.Clear();
            for (int i = 1; i <= 31; i++)
                day.Add(i);
            if (day30.Contains(cmbMonth.SelectedItem.ToString()))
                day.Remove(31);
            else if (cmbMonth.SelectedItem.ToString() == "February")
            {
                if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                    { day.Remove(31); day.Remove(30); }
                else
                    { day.Remove(31); day.Remove(30); day.Remove(29); }
            }   
            cmbDay.ItemsSource = null;
            cmbDay.ItemsSource = day;
        }

        private int MonthValue(string month)
        {
            for (int i = 1; i <= 12; i++)
                if (month == Enum.GetName(typeof(Month), i).ToString())
                    return i;
            return -1;
        }

        private int GetAge(DateTime birthDate)
        {
            if (DateTime.Now.Month < birthDate.Month || 
                            (DateTime.Now.Month == birthDate.Month && DateTime.Now.DayOfYear < birthDate.DayOfYear))
                return DateTime.Now.Year - birthDate.Year - 1;
            else
                return DateTime.Now.Year - birthDate.Year;

        }
    }
}
