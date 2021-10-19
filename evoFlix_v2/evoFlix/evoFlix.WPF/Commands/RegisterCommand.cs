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
    class RegisterCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly MainRegisterViewModel _mainregisterviewmodel;
        private readonly IRenavigator _renavigator;

        public RegisterCommand(IAuthenticator authenticator, MainRegisterViewModel mainregisterviewmodel, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _mainregisterviewmodel = mainregisterviewmodel;
            _renavigator = renavigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            RegistrationResult result = RegistrationResult.PasswordsDoNotMatch;

            var passwordBoxes = parameter as List<Object>;
            PasswordBox pb;
            string password;
            string repassword;

            try
            {
                pb = passwordBoxes[0] as PasswordBox;
                password = pb.Password;
                pb = passwordBoxes[1] as PasswordBox;
                repassword = pb.Password;
            }
            catch
            {
                return;
            }

            result = _authenticator.Register(_mainregisterviewmodel.Username, _mainregisterviewmodel.Email, password, repassword, _mainregisterviewmodel.BDate);

            switch (result)
            {
                case RegistrationResult.Success:
                    _renavigator.Renavigate();
                    break;
                case RegistrationResult.UsernameIsAlreadyUsed:
                    _mainregisterviewmodel.ErrorMessage = "Username is already in use!";
                    break;
                case RegistrationResult.EmailAddressIsAlreadyUsed:
                    _mainregisterviewmodel.ErrorMessage = "Email address is already in use!";
                    break;
                case RegistrationResult.PasswordsDoNotMatch:
                    _mainregisterviewmodel.ErrorMessage = "Passwords do not match!";
                    break;
                case RegistrationResult.WeakPassword:
                    _mainregisterviewmodel.ErrorMessage = "Password is too weak!";
                    break;
                case RegistrationResult.EmptyRow:
                    _mainregisterviewmodel.ErrorMessage = "The rows must not be empty!";
                    break;
                default:
                    _mainregisterviewmodel.ErrorMessage = "Registration Failed!";
                    break;
            }
        }
    }
}
