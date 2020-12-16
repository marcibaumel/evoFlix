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

        public List<UserDB> listOfUsers()
        {
            List<UserDB> ListOfUsers = new List<UserDB>();
            
            foreach (var user in unitOfWork.Users)
            {
                ListOfUsers.Add(new UserDB { Id = user.Id, Username = user.Username, ProfilePicturePath = user.ProfilePicturePath });
            }

          
            return ListOfUsers;

        }

        public void writeOutListOfUser()
        {
            foreach(UserDB a in listOfUsers())
            {
                Console.WriteLine(a.Username);
            }
        }

        public void getUserName(int Number)
        {

        }

        public void getUserProfilPitcure(int Number)
        {

        }


       
    }
}
