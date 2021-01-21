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

namespace evoFlix.WPF.DashboardViews
{
    /// <summary>
    /// Interaction logic for MyList.xaml
    /// </summary>
    public partial class MyList : UserControl
    {
        FilmService fS = new FilmService();
        MyListService mLS = new MyListService();
        private int UserId { get; set; }

        public MyList()
        {
            
            InitializeComponent();
            UserId = 1;
            makeFilmGrid();
        }
       

        private void Film_Click(object sender, RoutedEventArgs e)
        {


        }
        
        private void makeFilmGrid()
        {
            //setFilmGrid(fn0, fk0);
        }

        private void setFilmGrid(Label fn0, Image fk0)
        {


            try
            {


                fn0.Content = fS.getFilmTitle(UserId);
                fk0.Source = new BitmapImage(new Uri(@fS.getPoster(fn0.Content.ToString())));


            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Hiba");
                fn0.Content = "";
                fk0.Source = null;



            }

        }
    }
}
