using evoFlix.WPF.Commands;
using evoFlix.WPF.State.Authenticator;
using evoFlix.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace evoFlix.WPF.ViewModels
{
    public class MainLoginViewModel : BaseViewModel
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }
        public ICommand LoginCommand { get; }
        public ICommand ViewRegisterCommand { get; }

        public MainLoginViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator, IRenavigator viewRegisterRenavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();
            LoginCommand = new LoginCommand(authenticator, this, loginRenavigator);
            ViewRegisterCommand = new RenavigateCommand(viewRegisterRenavigator);
        }
    }
}
