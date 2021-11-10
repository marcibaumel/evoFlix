using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evoFlix.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public UserRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserModel> GetAllUser()
        {
            return _unitOfWork.Users;
        }

        public UserModel GetUserByUsername(string username)
        {
            return _unitOfWork.Users.Where(user => user.Username == username).FirstOrDefault();
        }

        public void CreateUser(UserModel user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.SaveChanges();
        }

        public UserModel GetUserById(string id)
        {
            return _unitOfWork.Users.Where(user => user.UserId.ToString() == id).FirstOrDefault();
        }
    }
}
