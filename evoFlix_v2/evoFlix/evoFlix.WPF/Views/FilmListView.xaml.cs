using evoFlix.Models.Content;
using evoFlix.WPF.ViewModels;
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
    public partial class FilmListView : Page
    {
        private readonly FilmListViewModel filmListViewModel = new FilmListViewModel();
        private readonly Frame frame;
        public FilmListView(Frame frame)
        {
            InitializeComponent();

            this.frame = frame;

            LoadContent();
        }

        private void LoadContent()
        {
            var films = filmListViewModel.GetAllFilm();


            for (int i = 0; i < filmListViewModel.MaxItemsInRow; i++)
                homeGrid.ColumnDefinitions.Add(new ColumnDefinition());

            var filmEnumerator = films.GetEnumerator();
            int itemsInRow = 0;
            int row = 0;
            for (int i = 0; i < films.Count; i++)
            {

                filmEnumerator.MoveNext();
                var film = filmEnumerator.Current;
                if (itemsInRow >= filmListViewModel.MaxItemsInRow)
                {
                    itemsInRow = 0;
                    row++;
                    homeGrid.RowDefinitions.Add(new RowDefinition());
                }

                Button button = new Button();
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(film.Poster, UriKind.Absolute)) };
                button.AddHandler(Button.ClickEvent, new RoutedEventHandler(button_click));
                button.Tag = film;
                button.Margin = new Thickness(10, 20, 10, 0);
                button.Height = 300;
                button.Width = 200;
                homeGrid.Children.Add(button);
                Grid.SetRow(button, row);
                Grid.SetColumn(button, itemsInRow++);
            }
        }

        public void button_click(object sender, EventArgs e)
        {
            var button = sender as Button;
            frame.Content = new FilmDetailsView(frame, (FilmTableModel)button.Tag);
        }
    }
}
