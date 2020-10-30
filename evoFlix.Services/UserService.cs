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
        public void CreateUser(User user)
        {
            unitOfWork.User.Add(user);

        }
    }
}
