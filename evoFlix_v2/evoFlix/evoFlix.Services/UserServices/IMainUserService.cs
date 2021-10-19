using evoFlix.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.Services
{
    public interface IMainUserService : IDataService<MainUserTableModel>
    {
        MainUserTableModel GetByUsername(string username);
        MainUserTableModel GetByEmail(string email);
    }
}
