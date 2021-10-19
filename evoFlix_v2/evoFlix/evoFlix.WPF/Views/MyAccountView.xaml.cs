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
    /// Interaction logic for MyAccount.xaml
    /// </summary>
    public partial class MyAccountView : UserControl
    {
        public MyAccountView()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteButton.Visibility = Visibility.Hidden;
            Verify.Visibility = Visibility.Visible;
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            Verify.Visibility = Visibility.Hidden;
            DeleteButton.Visibility = Visibility.Visible;
        }
    }
}
