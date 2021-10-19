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
    public class MainRegisterViewModel : BaseViewModel
    {
        private string _username, _email;
        private DateTime _bDate = DateTime.Now;

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
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public DateTime BDate
        {
            get
            {
                return _bDate;
            }
            set
            {
                _bDate = value;
                OnPropertyChanged(nameof(BDate));
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }
        public ICommand RegisterCommand { get; }
        public ICommand ViewLoginCommand { get; }

        public MainRegisterViewModel(IAuthenticator authenticator, IRenavigator registerRenavigator, IRenavigator viewLoginRenavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();
            RegisterCommand = new RegisterCommand(authenticator, this, registerRenavigator);
            ViewLoginCommand = new RenavigateCommand(viewLoginRenavigator);
        }

    }
}
