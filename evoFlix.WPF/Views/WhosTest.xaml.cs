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
    /// Interaction logic for WhosTest.xaml
    /// </summary>
    public partial class WhosTest : Page
    {
        public WhosTest()
        {
            InitializeComponent();
        }

        public void test()
        {
            Console.WriteLine("asd");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test();

        }

        private void Create_a_New_User_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
