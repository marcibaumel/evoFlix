using evoFlix.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.Models.Content
{
    [Table("ContinuationTable")]
    public class ContinuationTableModel: BaseModel
    {
        [Key]
        public int ContinuationId { get; set; }

        public FilmTableModel FilmId { set; get; }
        public UserTableModel UserId { get; set; }
        public MainUserTableModel MainId { get; set; }

        public string WatchTime { get; set; }

       

    }
}
