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
    [Table("WatchListTable")]
    public class WatchListTableModel : BaseTableModel
    {

        public Guid FilmId { get; set; }

        public Guid UserId { get; set; }
        public Guid MainId { get; set; }

        

    }
}
