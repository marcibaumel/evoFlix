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
    public class UserTableModel :BaseTableModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime Birth { get; set; }
        public DateTimeOffset Created { get; set; }
        public String ProfilePicturePath { get; set; }

        public MainUserTableModel Main { get; set; }

        [ForeignKey("Main")] 
        public int MainFk { get; set; }
    }
}
