using evoFlix.WPF.State.Authenticator;
using evoFlix.WPF.State.Navigators;
using evoFlix.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace evoFlix.WPF.Commands
{
    public class LogOutCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LogOutCommand(IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _authenticator.Logout();
            _renavigator.Renavigate();
        }
    }
}
