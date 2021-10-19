using System.Windows;
using WpfFramework.ExampleProject.Views.Windows;

namespace WpfFramework.ExampleProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();

            _mainGrid.DataContext = mainWindowViewModel;
            mainWindowViewModel.NavigationService.SetFrame(_mainFrame);
        }
    }
}
