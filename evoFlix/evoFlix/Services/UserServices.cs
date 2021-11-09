using evoFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace evoFlix.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool UsernameIsValid(string username)
        {
            if (_userRepository.GetUser(username) != null)
                return false;
            return true;
        }

        public bool PasswordIsStrong(string password)
        {
            if (password.Length < 6)
                return false;

            if (!Regex.IsMatch(password, @".*\d.*")) // Contains a number
                return false;

            if (!Regex.IsMatch(password, @".*[A-Z].*")) // Contans an uppercase letter
                return false;

            if (!Regex.IsMatch(password, @".*[a-z].*")) // Contans a lowercase letter
                return false;

            if (!Regex.IsMatch(password, @".*[^\w\d\s]|_.*")) // Contans a special character
                return false;

            return true;
        }
    }
}
