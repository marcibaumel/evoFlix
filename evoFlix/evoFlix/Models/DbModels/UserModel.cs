using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace evoFlix.Models
{
    [Table("UserTable")]
    public class UserModel
    {
        [Key]
        public Guid UserId { get; set; }


        [Column(TypeName = "nvarchar(200)")]
        public string Email { get; set; }


        [Column(TypeName = "nvarchar(200)")]
        public string Username { get; set; }


        [Column(TypeName = "nvarchar(200)")]
        public string Password { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string ProfilPitcure { get; set; }

        [Column(TypeName = "BIT")]
        public bool ValidAccount { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }
    }
}
