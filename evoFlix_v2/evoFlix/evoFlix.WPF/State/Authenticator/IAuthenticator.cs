using evoFlix.Models.Users;
using evoFlix.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.WPF.State.Authenticator
{
    public interface IAuthenticator
    {
        MainUserTableModel CurrentMainUser { get; }
        bool IsLoggedIn { get; }

        event Action StateChanged;
        RegistrationResult Register(string username, string email, string password, string confirmedPassword, DateTime birthDate);
        void Login(string username, string password);
        void Logout();
        void DeleteAccount(MainUserTableModel mainUser);
        PasswordChangeResult ChangePassword(int id, string currentPassword, string newPassword, string newConfirmedPassword);
    }
}
