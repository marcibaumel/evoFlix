using evoFlix.WPF.Commands;
using evoFlix.WPF.State.Authenticator;
using evoFlix.WPF.State.Navigators;
using evoFlix.WPF.ViewModels.Factories;
using System.Windows.Input;

namespace evoFlix.WPF.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IRootViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;

        public BaseViewModel CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; }


        public MainWindowViewModel(INavigator navigator, IRootViewModelFactory viewModelFactory, IAuthenticator authenticator)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;


            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;


            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.MainLogin);
        }

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
