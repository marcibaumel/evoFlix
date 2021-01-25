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
        List<int> UserWatchList = new List<int>();
        private int UserId { get; set; }

        public MyList()
        {
            
            InitializeComponent();
            UserId = Heap.ActualUserId;
            UserWatchList = mLS.ListOfUserWatching(UserId);
            makeFilmGrid();
            





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


                fn0.Content = mLS.getFilmTitle(giveMyList(UserWatchList));
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

        private int giveMyList(List<int> list)
        {
            int num = list[0];
            list.Remove(num);
            return num;
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
            string content = (String)titlelabel.Content;
            mLS.AddToMyList(fS.getFilmID(content), UserId);
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

        
        
       
    }
}
