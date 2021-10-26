using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace evoFlix.Models
{
    [Table("SubtitleTable")]
    public class SubtitleModel
    {
        [Key] 
        public Guid SubtitleId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string SubtitleLanguage { get; set; }


        [Column(TypeName = "nvarchar(1000)")]
        public string SubtitleLocation { get; set; }

        public Guid FilmId { get; set; }
        public FilmModel Film { get; set; }
    }
}
