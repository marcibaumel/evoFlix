using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace evoFlix.Models
{
    [Table("SourceTable")]
    public class SourceModel
    {
        [Key]
        public Guid FimSourceId { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string FilmLocation { get; set; }

        [Column(TypeName = "date")]
        public DateTime FileModified { get; set; }

        public Guid FilmId { get; set; }
        public FilmModel Film { get; set; }
    }
}
