using evoFlix.DataAccess;
using evoFlix.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.Services
{
    
    public class UserService
    {
        private UnitOfWork unitOfWork;

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
    }
}
