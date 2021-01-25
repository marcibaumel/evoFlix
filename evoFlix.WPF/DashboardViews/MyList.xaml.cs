using evoFlix.Services;
using evoFlix.WPF.ViewModels;
using evoFlix.WPF.Views;
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
        Label titlelabel, directorlabel, actorslabel, minlabel, ratelabel, imdbrate, descrlabel;
        HomeViewModel hVM = new HomeViewModel();
        private int UserId { get; set; }

        public MyList()
        {
            
            InitializeComponent();
            UserId = 5;
            makeFilmGrid();


            var UserWatchList = mLS.ListOfUserWatching(UserId);
            
            for(int i=0; i<UserWatchList.Count; i++)
            {
                Console.WriteLine(UserWatchList.ElementAt(i));
            }


        }
       

       
        
        private void makeFilmGrid()
        {
            //setFilmGrid(fn0, fk0);
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {


            Page DashBoard = new DashboardPage(hVM.mainWindow);
            FilmPanel.Visibility = Visibility.Hidden;
            DashBoard.DataContext = new DashboardViewModel();


            Page player = new VideoPlayer(DashBoard, hVM.mainWindow, (String)titlelabel.Content);
            hVM.mainWindow.Content = player;



        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            FilmPanel.Visibility = Visibility.Hidden;
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Film_Click(object sender, RoutedEventArgs e)
        {
            string title;

            FilmPanel.Visibility = Visibility.Visible;
            switch (((Button)sender).Name)
            {
                case "f0":
                    title = (string)fn0.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f1":
                    title = (string)fn1.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f2":
                    title = (string)fn2.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f3":
                    title = (string)fn3.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f4":
                    title = (string)fn4.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f5":
                    title = (string)fn5.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f6":
                    title = (string)fn6.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f7":
                    title = (string)fn7.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f8":
                    title = (string)fn8.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f9":
                    title = (string)fn9.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f10":
                    title = (string)fn10.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f11":
                    title = (string)fn11.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f12":
                    title = (string)fn12.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f13":
                    title = (string)fn13.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f14":
                    title = (string)fn14.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f15":
                    title = (string)fn15.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f16":
                    title = (string)fn16.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
                case "f17":
                    title = (string)fn17.Content;
                    fI.Source = new BitmapImage(new Uri(@fS.getPoster(title.ToString())));

                    titlelabel = titlelbl.Child as Label;
                    titlelabel.Content = title;

                    directorlabel = directorlbl.Child as Label;
                    directorlabel.Content = fS.getDirector(title);

                    actorslabel = castlbl.Child as Label;
                    actorslabel.Content = fS.getActors(title);

                    minlabel = minlbl.Child as Label;
                    minlabel.Content = fS.getRuntime(title);

                    ratelabel = ratelbl.Child as Label;
                    ratelabel.Content = fS.getRated(title);

                    imdbrate = imbdlbl.Child as Label;
                    imdbrate.Content = fS.getRating(title);

                    descrlabel = desclbl.Child as Label;
                    descrlabel.Content = fS.getPlot(title);

                    break;
            }

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
