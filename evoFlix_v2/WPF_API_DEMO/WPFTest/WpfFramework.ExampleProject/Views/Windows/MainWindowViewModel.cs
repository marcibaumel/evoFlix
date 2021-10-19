using WpfFramework.Core;
using WpfFramework.ExampleProject.Views.Pages;

namespace WpfFramework.ExampleProject.Views.Windows
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly RedPage _redPage;
        private readonly GreenPage _greenPage;
        private readonly BluePage _bluePage;

        public NavigationService NavigationService { get; }
        public RelayCommand LoadRedPageCommand { get; set; }
        public RelayCommand LoadGreenPageCommand { get; set; }
        public RelayCommand LoadBluePageCommand { get; set; }

        public MainWindowViewModel(NavigationService navigationService, RedPage redPage, GreenPage greenPage, BluePage bluePage)
        {
            NavigationService = navigationService;

            _redPage = redPage;
            _greenPage = greenPage;
            _bluePage = bluePage;

            LoadRedPageCommand = new RelayCommand(LoadRedPage, IsRedPageEnabled);
            LoadGreenPageCommand = new RelayCommand(LoadGreenPage, IsGreenPageEnabled);
            LoadBluePageCommand = new RelayCommand(LoadBluePage, IsBluePageEnabled);
        }

        private void LoadRedPage()
        {
            NavigationService.NavigateTo(_redPage);
        }

        private bool IsRedPageEnabled()
        {
            return !NavigationService.IsActiveContent(_redPage);
        }
            
        private void LoadGreenPage()
        {
            NavigationService.NavigateTo(_greenPage);
        }

        private bool IsGreenPageEnabled()
        {
            return !NavigationService.IsActiveContent(_greenPage);
        }

        private void LoadBluePage()
        {
            NavigationService.NavigateTo(_bluePage);
        }

        private bool IsBluePageEnabled()
        {
            return !NavigationService.IsActiveContent(_bluePage);
        }
    }
}
