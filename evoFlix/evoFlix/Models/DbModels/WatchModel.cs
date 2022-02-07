using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace evoFlix.Models
{
    [Table("WatchTable")]
    public class WatchModel
    {
        [Key]
        public Guid WatchId { get; set; }

        public TimeSpan WatchedTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime InsertedDate { get; set; }

        public Guid UserId { get; set; }
        public UserModel User { get; set; }

        public Guid FilmId { get; set; }
        public FilmModel Film { get; set; }
    }
}
