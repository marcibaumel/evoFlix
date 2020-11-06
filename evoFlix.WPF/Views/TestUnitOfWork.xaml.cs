using evoFlix.DataAccess;
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
    /// Interaction logic for TestUnitOfWork.xaml
    /// </summary>
    public partial class TestUnitOfWork : Page
    {
        UserService userService = new UserService();
        //UnitOfWork unitOfWork=new UnitOfWork();
        UserDB Béla = new UserDB();
        

        public TestUnitOfWork()
        {
            InitializeComponent();
        }


        private void Test_Button_Click(object sender, RoutedEventArgs e)
        {
            //Béla = (new User { Username = "Bécike" });
            //userService.CreateUser(Béla);
            

            string name = MyTextBox.Text;
            userService.CreateUser(new UserDB {Username=name });
            Console.WriteLine("asd");
            
        }

        
    }
}
