using evoFlix.DataAccess;
using evoFlix.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace evoFlix.Services
{
    
    public class UserService
    {
        #region Properties
        private UnitOfWork unitOfWork;
        public enum Month
        { January = 1, February, March, April, May, June, July, August, September, October, November, December }
        #endregion

        public UserService()
        {
            unitOfWork = new UnitOfWork();
        }
        public void CreateUser(UserDB user)
        {
            unitOfWork.Users.Add(user);
            unitOfWork.SaveChanges();
        }

        private int GetAge(DateTime birthDate)
        {
            if (DateTime.Now.Month < birthDate.Month ||
                            (DateTime.Now.Month == birthDate.Month && DateTime.Now.DayOfYear < birthDate.DayOfYear))
                return DateTime.Now.Year - birthDate.Year - 1;
            else
                return DateTime.Now.Year - birthDate.Year;

        }

        public List<UserView> GetUsers()
        {
            List<UserView> userViews = new List<UserView>();
            foreach (var user in unitOfWork.Users)
            {
                userViews.Add(new UserView { Username = user.Username, Password = user.Password, BirthDate = user.BirthDate, Id = user.Id, Age = GetAge(user.BirthDate)});
            }
            return userViews;
        }

        public int MonthValue(string month)
        {
            for (int i = 1; i <= 12; i++)
                if (month == Enum.GetName(typeof(Month), i).ToString())
                    return i;
            return -1;
        }

        public bool IsUniqueUsername(string username)
        {
            foreach (UserDB user in unitOfWork.Users)
                if (user.Username == username)
                    return false;
            return true;
        }

        public bool IsStrongPassword(string password)
        {
            if (!Regex.IsMatch(password, @"[A-Z]")) // Contains an uppercase letter
                return false;
            if (!Regex.IsMatch(password, @"\d")) // Contains a digit
                return false;
            return true;
        }

        public void countUser()
        {
            var count = unitOfWork.Users.Count();
            Console.WriteLine(count);
        }
    }
}
