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
    //TO-DO:
    //- CREATE GENERAL ERROR FUNCTIONS (TO CLEAR UP CODE DUPPLICATES)
    //- REVIEW CODE

    //ISSUES:
    //- CENTER TEXT IN LABEL
    //- SELECTED PICTURE BORDER SIZE
    //- PASSWORDBOX TEXT CHANGED EVENT EQUIVALENT

    
    public partial class CreateUser : UserControl
    {
        #region Properties
        string[] month = { "January", "February", "March", "April", "May",
                           "June", "July", "August", "September", "October", "November", "December"};
        string[] basePictures = { "kep1.jpg", "kep2.jpg", "kep3.jpg", "kep4.jpg" };
        List<string> pictures;
        string selectedImagePath;
        List<int> year, day;
        UserService userService = new UserService();
        Dictionary<string, bool> missing = new Dictionary<string, bool>() 
                { {"username", true}, {"confirm", true}, {"password", true}, {"picture", true} };
        #endregion

        public CreateUser()
        {

            InitializeComponent();
            userService.countUser();
            cmbMonth.ItemsSource = month;
            day = new List<int>();
            cmbDay.ItemsSource = new string[] { "Select month first!" };
            year = new List<int>();
            for (int i = 0; i < 100; i++)
                year.Add(DateTime.Now.Year - i);
            cmbYear.ItemsSource = year;
            
             pictures = basePictures.ToList<string>();

            for (int i = 0; i < pictures.Count; i++)
            {
                grdPictures.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
                Button button = new Button();
                button.Height = 40;
                button.Width = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(@"Images/" + pictures[i], UriKind.Relative));
                brush.Stretch = Stretch.UniformToFill;
                button.Background = brush;
                button.AddHandler(Button.ClickEvent, new RoutedEventHandler(Picture_click));

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

        public void Picture_click(object sender, EventArgs e)
        {
            missing["picture"] = false;
            Button button = sender as Button;
            Border border = (Border)button.Parent;
            ImageBrush imgbrush = (ImageBrush)button.Background;
            selectedImagePath = imgbrush.ImageSource.ToString();
            foreach (Border imageBorder in grdPictures.Children)
                imageBorder.BorderThickness = new Thickness(0);
            border.BorderThickness = new Thickness(2);
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            btnDone.IsEnabled = true;
            bool condition = true;
            foreach (KeyValuePair<string, bool> item in missing)
                condition &= !item.Value;
            if (condition)
            {
                try
                {
                    int year = Convert.ToInt32(cmbYear.SelectedItem);
                    int month = userService.MonthValue(cmbMonth.SelectedItem.ToString());
                    int day = Convert.ToInt32(cmbDay.SelectedItem);
                    DateTime birthDate = new DateTime(year, month, day);
                    string username = txbUsername.Text;
                    string password = txbPassword.Password;
                    string profilePicturePath = System.IO.Path.GetFullPath(selectedImagePath);
                    userService.CreateUser(new UserDB { Username = username, Password = password, BirthDate = birthDate, ProfilePicturePath = profilePicturePath});
                    Console.WriteLine("asd");
                    Visibility = Visibility.Hidden;
                }
                catch (Exception)
                {
                    Label label = lblError.Child as Label;
                    label.Content = "Some field have missing values.";
                    lblError.Visibility = Visibility.Visible;
                    btnDone.IsEnabled = false;
                }
            }
            else
            {
                Label label = lblError.Child as Label;
                label.Content = "Some field have missing values.";
                lblError.Visibility = Visibility.Visible;
                btnDone.IsEnabled = false;
            }
        }

        private void CmbMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblError.Visibility = Visibility.Hidden;
            btnDone.IsEnabled = true;

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

        private void TxbUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!userService.IsUniqueUsername(txbUsername.Text))
            {
                Label label = lblError.Child as Label;
                label.Content = "This username has already been taken.\nChoose another one!";
                lblError.Visibility = Visibility.Visible;
                btnDone.IsEnabled = false;
            }   
            else
            {
                lblError.Visibility = Visibility.Hidden;
                btnDone.IsEnabled = true;
            }
            if (txbUsername.Text == "")
                missing["username"] = true;
            else
                missing["username"] = false;
        }

        private void TxbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!userService.IsStrongPassword(txbPassword.Password))
            {
                Label label = lblError.Child as Label;
                label.Content = "The given password is too weak! It must contain the following:\n\t- at least 6 characters\n\t- at least an uppercase character and a number!";
                lblError.Visibility = Visibility.Visible;
                btnDone.IsEnabled = false;
            }
            else
            {
                lblError.Visibility = Visibility.Hidden;
                btnDone.IsEnabled = true;
            }
            if (txbUsername.Text == "")
                missing["password"] = true;
            else
                missing["password"] = false;
        }

        private void TxbConfirm_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txbPassword.Password != txbConfirm.Password)
            {
                Label label = lblError.Child as Label;
                label.Content = "The passwords do not match. \nTry again!";
                lblError.Visibility = Visibility.Visible;
                btnDone.IsEnabled = false;
                txbConfirm.Password = "";
            }
            else
            {
                lblError.Visibility = Visibility.Hidden;
                btnDone.IsEnabled = true;
            }
            if (txbUsername.Text == "")
                missing["confirm"] = true;
            else
                missing["confirm"] = false;
        }

        private void CmbYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblError.Visibility = Visibility.Hidden;
            btnDone.IsEnabled = true;
        }

        public void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
        }

        private void CmbDay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblError.Visibility = Visibility.Hidden;
            btnDone.IsEnabled = true;
        }

        private void BtnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            if (openFileDialog.ShowDialog() == true)
            {
                Button button = new Button();
                button.Height = 40;
                button.Width = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                brush.Stretch = Stretch.Fill;
                button.Background = brush;
                button.AddHandler(Button.ClickEvent, new RoutedEventHandler(Picture_click));

                Border border = new Border
                {
                    Margin = new Thickness(5, 0, 5, 0),
                    Child = button,
                    BorderBrush = Brushes.Red,
                    BorderThickness = new Thickness(0),
                    CornerRadius = new CornerRadius(1)
                };
                grdPictures.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50)});
                pictures.Add(openFileDialog.FileName);
                Grid.SetColumn(border, pictures.Count - 1);
                Grid.SetRow(border, 1);
                grdPictures.Children.Add(border);

                selectedImagePath = openFileDialog.FileName;
                foreach (Border imageBorder in grdPictures.Children)
                    imageBorder.BorderThickness = new Thickness(0);
                border.BorderThickness = new Thickness(2);

                missing["picture"] = false;
            }
        }
    }
}
