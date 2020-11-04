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
    /// <summary>
    /// Interaction logic for Whos.xaml
    /// </summary>
    public partial class Whos : UserControl
    {
        UserService userService = new UserService();

        public Whos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User Gyula = new User();
            userService.CreateUser(Gyula);
            Console.WriteLine("asd");
        }
    }
}
