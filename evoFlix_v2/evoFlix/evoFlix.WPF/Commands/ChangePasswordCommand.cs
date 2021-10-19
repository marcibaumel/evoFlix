using evoFlix.Services.AuthenticationServices;
using evoFlix.WPF.State.Authenticator;
using evoFlix.WPF.State.Navigators;
using evoFlix.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace evoFlix.WPF.Commands
{
    class ChangePasswordCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;
        private readonly MyAccountViewModel _myAccountViewModel;

        public ChangePasswordCommand(IAuthenticator authenticator, IRenavigator renavigator, MyAccountViewModel myAccountViewModel)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
            _myAccountViewModel = myAccountViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var passwordBoxes = parameter as List<Object>;
            PasswordBox pb;
            string currentPassword;
            string newPassword;
            string newRePassword;

            try
            {
                pb = passwordBoxes[0] as PasswordBox;
                currentPassword = pb.Password;
                pb = passwordBoxes[1] as PasswordBox;
                newPassword = pb.Password;
                pb = passwordBoxes[2] as PasswordBox;
                newRePassword = pb.Password;
            }
            catch
            {
                return;
            }

            PasswordChangeResult result = _authenticator.ChangePassword(_authenticator.CurrentMainUser.ID, currentPassword, newPassword, newRePassword);

            switch (result)
            {
                case PasswordChangeResult.Success:
                    _authenticator.Logout();
                    _renavigator.Renavigate();
                    break;
                case PasswordChangeResult.IncorrectPassword:
                    _myAccountViewModel.ErrorMessage = "Current Password is incorrect!";
                    break;
                case PasswordChangeResult.PasswordsDoNotMatch:
                    _myAccountViewModel.ErrorMessage = "Passwords do not match!";
                    break;
                case PasswordChangeResult.SamePassword:
                    _myAccountViewModel.ErrorMessage = "Current and new Password must not match!";
                    break;
                case PasswordChangeResult.WeakPassword:
                    _myAccountViewModel.ErrorMessage = "The new Password is too weak!";
                    break;
                case PasswordChangeResult.EmptyRow:
                    _myAccountViewModel.ErrorMessage = "The rows must not be empty!";
                    break;
                default:
                    _myAccountViewModel.ErrorMessage = "Password change failed!";
                    break;
            }
        }
    }
}
