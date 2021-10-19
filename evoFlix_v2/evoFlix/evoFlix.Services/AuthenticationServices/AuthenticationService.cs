using evoFlix.Models.Users;
using evoFlix.Services.Exceptions;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace evoFlix.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMainUserService _mainUserService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IMainUserService mainUserService, IPasswordHasher passwordHasher)
        {
            _mainUserService = mainUserService;
            _passwordHasher = passwordHasher;
        }

        public MainUserTableModel Login(string username, string password)
        {
            MainUserTableModel storedAccount = _mainUserService.GetByUsername(username);

            if (storedAccount == null)
            {
                throw new UserNotFoundException(username);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount.Password, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }

            return storedAccount;
        }

        public RegistrationResult Register(string username, string email, string password, string confirmedPassword, DateTime birthDate)
        {
            Random _random = new Random();
            string[] pictures = { 
                "/evoFlix.WPF;component/Resources/Profile/yellowprofile.png", 
                "/evoFlix.WPF;component/Resources/Profile/blueprofile.png", 
                "/evoFlix.WPF;component/Resources/Profile/pinkprofile.png",
                "/evoFlix.WPF;component/Resources/Profile/brownprofile.png",
                "/evoFlix.WPF;component/Resources/Profile/greenprofile.png",
                "/evoFlix.WPF;component/Resources/Profile/greyprofile.png",
                "/evoFlix.WPF;component/Resources/Profile/purpleprofile.png",
                "/evoFlix.WPF;component/Resources/Profile/redprofile.png",
                "/evoFlix.WPF;component/Resources/Profile/szexyprofile.png",};
            RegistrationResult result = RegistrationResult.Success;

            //Checks if the rows are empty
            if (email == null || username == null || password.Equals("") || confirmedPassword.Equals(""))
            {
                result = RegistrationResult.EmptyRow;
                return result;
            }

            //Checks if there is already a User with that username
            MainUserTableModel usernameUser = _mainUserService.GetByUsername(username);
            if (usernameUser != null)
            {
                result = RegistrationResult.UsernameIsAlreadyUsed;
                return result;
            }

            //Checks if there is already a User with that email
            MainUserTableModel emailUser = _mainUserService.GetByEmail(email);
            if (emailUser != null)
            {
                result = RegistrationResult.EmailAddressIsAlreadyUsed;
                return result;
            }

            //Checks if the given password equals with the given confirmed password
            if (!(password.Equals(confirmedPassword)))
            {
                result = RegistrationResult.PasswordsDoNotMatch;
                return result;
            }

            //Checks if the password is strong enough
            if (!Regex.IsMatch(password, @"[A-Z]")) // Contains an uppercase letter
            {
                result = RegistrationResult.WeakPassword;
            }
            if (!Regex.IsMatch(password, @"\d")) // Contains a digit
            {
                result = RegistrationResult.WeakPassword;

            }
            if (!Regex.IsMatch(password, @".{6}")) // Contains at least 6 characters
            {
                result = RegistrationResult.WeakPassword;

            }

            if (result.Equals(RegistrationResult.Success))
            {
                string hashedPassword = _passwordHasher.HashPassword(password);
                int random = _random.Next(0, pictures.Length - 1);

                MainUserTableModel mainUser = new MainUserTableModel()
                {
                    Username = username,
                    Email = email,
                    Password = hashedPassword,
                    Created = DateTimeOffset.Now,
                    BirthDate = (DateTimeOffset)birthDate,
                    ProfilePicturePath = pictures[random]
                };

                _mainUserService.Create(mainUser);
            }


            return result;
        }
        public void DeleteAccount(MainUserTableModel mainUser)
        {
            _mainUserService.Delete(mainUser.ID);
        }
        public PasswordChangeResult ChangePassword(int id, string currentPassword, string newPassword, string newConfirmedPassword)
        {
            PasswordChangeResult result = PasswordChangeResult.Success;

            //Checks if the rows are empty
            if (currentPassword.Equals("") || newPassword.Equals("") || newConfirmedPassword.Equals(""))
            {
                result = PasswordChangeResult.EmptyRow;
                return result;
            }


            //Checks if the Current password is correct
            if (_passwordHasher.VerifyHashedPassword(_mainUserService.Get(id).Password, currentPassword) == PasswordVerificationResult.Failed)
            {
                result = PasswordChangeResult.IncorrectPassword;
                return result;
            }

            //Checks if the current password and the new password is the same
            if (currentPassword.Equals(newPassword))
            {
                result = PasswordChangeResult.SamePassword;
                return result;
            }

            //Checks if the new Password and the confirmed new Password is the same
            if (!(newPassword.Equals(newConfirmedPassword)))
            {
                result = PasswordChangeResult.PasswordsDoNotMatch;
                return result;
            }

            //Checks if the password is strong enough
            if (!Regex.IsMatch(newPassword, @"[A-Z]")) // Contains an uppercase letter
            {
                result = PasswordChangeResult.WeakPassword;
            }
            if (!Regex.IsMatch(newPassword, @"\d")) // Contains a digit
            {
                result = PasswordChangeResult.WeakPassword;

            }
            if (!Regex.IsMatch(newPassword, @".{6}")) // Contains at least 6 characters
            {
                result = PasswordChangeResult.WeakPassword;

            }

            if (result.Equals(PasswordChangeResult.Success))
            {
                string hashedPassword = _passwordHasher.HashPassword(newPassword);
                MainUserTableModel updatedUser = _mainUserService.Get(id);
                updatedUser.Password = hashedPassword;
                _mainUserService.Update(id, updatedUser);
            }
            return result;
        }
    }
}
