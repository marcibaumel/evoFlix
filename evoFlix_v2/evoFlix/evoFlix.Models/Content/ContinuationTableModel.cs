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
    public class ContinuationTableModel : BaseTableModel
    {
 
        public TimeSpan WatchTime { get; set; }

        public Guid UserID { get; set; }

        public Guid MainId { get; set; }
    }
}
