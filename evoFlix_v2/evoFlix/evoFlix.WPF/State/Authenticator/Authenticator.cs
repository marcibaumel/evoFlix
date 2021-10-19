using evoFlix.Models.Users;
using evoFlix.Services.AuthenticationServices;
using evoFlix.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.WPF.State.Authenticator
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public MainUserTableModel _currentMainUser;

        public MainUserTableModel CurrentMainUser
        {
            get
            {
                return _currentMainUser;
            }
            private set
            {
                _currentMainUser = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentMainUser != null;

        public event Action StateChanged;
        public void Login(string username, string password)
        {
            CurrentMainUser = _authenticationService.Login(username, password);
        }

        public void Logout()
        {
            CurrentMainUser = null;
        }

        public RegistrationResult Register(string username, string email, string password, string confirmedPassword, DateTime birthDate)
        {
            return _authenticationService.Register(username, email, password, confirmedPassword, birthDate);
        }

        public void DeleteAccount(MainUserTableModel mainUser)
        {
            _authenticationService.DeleteAccount(mainUser);
        }
        public PasswordChangeResult ChangePassword(int id, string currentPassword, string newPassword, string newConfirmedPassword)
        {
            return _authenticationService.ChangePassword(id, currentPassword, newPassword, newConfirmedPassword);
        }
    }
}
