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
    /*Ebből a servic-ből lesz betöltve a user-adata*/

    public class UserComponentsService
    {        
        private UnitOfWork unitOfWork;

        public UserComponentsService()
        {
            unitOfWork = new UnitOfWork();
        }

        public List<int> listOfUsers()
        {
            List<int> ListOfUsers = new List<int>();
            
            foreach (var user in unitOfWork.Users)
            {
                ListOfUsers.Add(user.Id);
            }

           

            return ListOfUsers;

        }

        

        public string getUserName(int Number)
        {
            string userName = unitOfWork.Users.FirstOrDefault(x => x.Id == Number).Username;
            if (userName == null)
            {
                return "Failed";
            }
           
            return userName.ToString();
        }

        public string getUserProfilPitcure(int Number)
        {
            var userProfilPitcure = unitOfWork.Users.FirstOrDefault(x => x.Id == Number).ProfilePicturePath;
            if (userProfilPitcure == null)
            {
                return "Failed";
            }

            return userProfilPitcure.ToString();
        }


       
    }
}
