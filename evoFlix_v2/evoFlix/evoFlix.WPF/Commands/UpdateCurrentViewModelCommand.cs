using evoFlix.Services.AuthenticationServices;
using evoFlix.WPF.State.Authenticator;
using evoFlix.WPF.State.Navigators;
using evoFlix.WPF.ViewModels;
using evoFlix.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace evoFlix.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private INavigator _navigator;
        private readonly IRootViewModelFactory _rootViewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IRootViewModelFactory rootViewModelFactory)
        {
            _navigator = navigator;
            _rootViewModelFactory = rootViewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                _navigator.CurrentViewModel = _rootViewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}