using evoFlix.Models.Users;
using evoFlix.WPF.State.Authenticator;
using evoFlix.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace evoFlix.WPF.Commands
{
    public class DeleteCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public DeleteCommand(IAuthenticator authenticator, IRenavigator renavigator)
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
            MainUserTableModel CurrentUser = _authenticator.CurrentMainUser;
            _authenticator.Logout();
            _authenticator.DeleteAccount(CurrentUser);
            _renavigator.Renavigate();
        }
    }
}
