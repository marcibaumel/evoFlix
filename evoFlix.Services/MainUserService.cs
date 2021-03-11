using evoFlix.DataAccess;
using evoFlix.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;

namespace evoFlix.Services
{
    class MainUserService
    {
        #region Properties
        private UnitOfWork unitOfWork;
        #endregion

        public MainUserService()
        {
            unitOfWork = new UnitOfWork();
        }

        public void CreateUser(MainUserTableModel mainuser)
        {
            unitOfWork.MainUsers.Add(mainuser);
            unitOfWork.SaveChanges();
        }

        public bool IsUniqueUsername(string username)
        {
            foreach (MainUserTableModel mainuser in unitOfWork.MainUsers)
                if (mainuser.Username == username)
                    return false;
            return true;
        }

        public bool IsExistingPassword(string username, string password)
        {
            foreach (MainUserTableModel mainuser in unitOfWork.MainUsers)
            {
                if (mainuser.Username == username)
                    if (mainuser.Password == password)
                        return false;
            }
            return true;
        }

        public bool IsStrongPassword(string password)
        {
            if (!Regex.IsMatch(password, @"[A-Z]")) // Contains an uppercase letter
                return false;
            if (!Regex.IsMatch(password, @"\d")) // Contains a digit
                return false;
            if (!Regex.IsMatch(password, @".{6}")) // Contains at least 6 characters
                return false;
            return true;
        }

        public void DeleteUser(string givenUser)
        {
            var deleteUser = unitOfWork.MainUsers.FirstOrDefault(x => x.Username == givenUser);
            if (deleteUser == null)
            {
                return;
            }
            unitOfWork.MainUsers.Remove(deleteUser);
            unitOfWork.SaveChanges();

        }

    }
}
