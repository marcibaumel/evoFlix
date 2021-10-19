using evoFlix.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.Services.AuthenticationServices
{
    public enum RegistrationResult
    {
        Success,
        UsernameIsAlreadyUsed,
        EmailAddressIsAlreadyUsed,
        PasswordsDoNotMatch,
        WeakPassword,
        EmptyRow
    }
    public enum PasswordChangeResult
    {
        Success,
        IncorrectPassword,
        PasswordsDoNotMatch,
        SamePassword,
        WeakPassword,
        EmptyRow
    }
    public interface IAuthenticationService
    {
        RegistrationResult Register(string username, string email, string password, string confirmedPassword, DateTime BirthDate);
        MainUserTableModel Login(string username, string password);
        void DeleteAccount(MainUserTableModel mainUser);
        PasswordChangeResult ChangePassword(int id, string currentPassword, string newPassword, string newConfirmedPassword);
    }
}
