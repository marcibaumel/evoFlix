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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        UserService userService = new UserService();
        UserComponentsService ucs = new UserComponentsService();
        FilmService fS = new FilmService();
        Random rd = new Random();

        public HomeView()
        {
            InitializeComponent();
            setFilmGrid(fn0, fk0);
            setFilmGrid(fn1, fk1);
            setFilmGrid(fn2, fk2);
            setFilmGrid(fn3, fk3);
            setFilmGrid(fn4, fk4);
            setFilmGrid(fn5, fk5);
        }

        private void Film_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Film Cick");

        }

        private void setFilmGrid(Label fn0, Image fk0)
        {
            
           
            try
            {
                fn0.Content = fS.getFilmTitle(rd.Next(1, fS.listOfFilms().Count()));
                
                //Console.WriteLine(fc);
                fk0.Source = new BitmapImage(new Uri(@fS.getPoster(fn0.Content.ToString())));
               

            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /*
         * Ezzel a függvényel fogjuk kizárni azokat az id-kat amiket már használtunk
         */
        private int randomFilm()
        {

            int randNum=0;
            return randNum;
        }
    }
}
