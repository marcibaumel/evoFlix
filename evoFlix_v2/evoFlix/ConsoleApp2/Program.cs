using evoFlix.DataAccess;
using evoFlix.Models.Users;
using evoFlix.Services;
using evoFlix.Services.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //IDataService<MainUserTableModel> userService = new GenericDataService<MainUserTableModel>(new UnitOfWork());
            //userService.Create(new MainUserTableModel { Username = "Test" });

            UserService userservice = new UserService();
            userservice.CreateUser(new UserTableModel { Name = "test" });
            

        }
    }
}
