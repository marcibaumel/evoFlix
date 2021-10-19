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
    [Table("MainUserTable")]
    public class MainUserTableModel : BaseTableModel
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string ProfilePicturePath { get; set; }
    }
}
