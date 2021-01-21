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
using System.Windows.Shapes;

namespace evoFlix.WPF
{
    
    public partial class DashboardPage : Page
    {

        //public string user { get; set; }
        public Window window { get; set; }

        public DashboardPage(Window window)
        {
            InitializeComponent();

            this.window = window;
        }

        public DashboardPage()
        {

        }

        
    }
}
