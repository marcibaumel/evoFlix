using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.Models.Users
{
    public class UserView
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
