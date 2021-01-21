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
        
        FilmService fS = new FilmService();
        Random rd = new Random();

       

        List<int> list = new List<int>();
        List<int> usedList = new List<int>();

        public HomeView()
        {
            
            InitializeComponent();
           
          

            loadList(list);
            makeFilmGrid();

            list.Clear();
            
        }

       
        private void Film_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Film Cick");

        }

        private void makeFilmGrid()
        {
            setFilmGrid(fn0, fk0);
            setFilmGrid(fn1, fk1);
            setFilmGrid(fn2, fk2);
            setFilmGrid(fn3, fk3);
            setFilmGrid(fn4, fk4);
            setFilmGrid(fn5, fk5);
            setFilmGrid(fn6, fk6);


            setFilmGrid(fn7, fk7);
            setFilmGrid(fn8, fk8);
            setFilmGrid(fn9, fk9);
            setFilmGrid(fn10, fk10);
            setFilmGrid(fn11, fk11);
            setFilmGrid(fn12, fk12);

            setFilmGrid(fn13, fk13);

            setFilmGrid(fn14, fk14);


            setFilmGrid(fn15, fk15);

            setFilmGrid(fn16, fk16);
            setFilmGrid(fn17, fk17);


        }



        private void setFilmGrid(Label fn0, Image fk0)
        {
           

            try
            {
                

                fn0.Content = fS.getFilmTitle(randomFilm());  
                fk0.Source = new BitmapImage(new Uri(@fS.getPoster(fn0.Content.ToString())));
               

            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Hiba");
                
            }

        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }






        /*
         * Random szám de még nem müködik rendesen
         */

        private int randomFilm()
        {
            int rN = randomNumber();

            if (usedList.Contains(rN))
            {
                rN = randomNumber();
                list.Remove(rN);
            }
          
           usedList.Add(rN);
           
           
           return rN;
             
           
            
        }

        /*
         * Random szám generálás
         */

        private int randomNumber()
        {
            int randomNumber = rd.Next(1, list.Count());
            return randomNumber;
        }

        /*
         * Az adatbázisban lévő elemek
         * 
         */
        private void loadList(List<int> list)
        {
            for(int i=0; i< fS.listOfFilms().Count(); i++)
            {        
                list.Add(i);
            }
        }
    }
}
