using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace evoFlix.Models.Users
{
    [Table("UserTable")]
    public class UserTableModel : BaseModel
    {

        [Key]
        public int UserId { get; set; }

        public MainUserTableModel MainUserId{ get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime Birth { get; set; }
        public DateTime Created { get; set; }
        public string ProfilePicturePath { get; set; }
    }
}
