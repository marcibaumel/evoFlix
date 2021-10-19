using evoFlix.Services.Exceptions;
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
    public class LoginCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly MainLoginViewModel _mainloginviewmodel;
        private readonly IRenavigator _renavigator;

        public LoginCommand(IAuthenticator authenticator, MainLoginViewModel mainloginviewmodel, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _mainloginviewmodel = mainloginviewmodel;
            _renavigator = renavigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
            try
            {
                _authenticator.Login(_mainloginviewmodel.Username, password);
                _renavigator.Renavigate();
            }
            catch (UserNotFoundException)
            {
                _mainloginviewmodel.ErrorMessage = "Invalid Username!";
            }
            catch (InvalidPasswordException)
            {
                _mainloginviewmodel.ErrorMessage = "Incorrect Password!";
            }
            catch (Exception)
            {
                _mainloginviewmodel.ErrorMessage = "Login Failed!";
            }
        }
    }
}
