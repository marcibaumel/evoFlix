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
    public class MyAccountViewModel : BaseViewModel
    {
        private readonly IAuthenticator _authenticator;
        public string UserName
        {
            get
            {
                return _authenticator.CurrentMainUser.Username;
            }
        }

        public string ProfilePic
        {
            get
            {
                return _authenticator.CurrentMainUser.ProfilePicturePath;
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand LogOutCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ChangePasswordCommand { get; }

        public MyAccountViewModel(IAuthenticator authenticator, IRenavigator renavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();
            _authenticator = authenticator;
            LogOutCommand = new LogOutCommand(authenticator, renavigator);
            DeleteCommand = new DeleteCommand(authenticator, renavigator);
            ChangePasswordCommand = new ChangePasswordCommand(authenticator, renavigator, this);
        }
    }
}
