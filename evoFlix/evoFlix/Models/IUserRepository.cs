using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evoFlix.Models
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAllUser();

        UserModel GetUserByUsername(string username);

        UserModel GetUserById(string id);

        void CreateUser(UserModel user);
    }
}
