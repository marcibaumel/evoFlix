using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.Models.Content
{
    [Table("FilmSourceTable")]
    public class FilmSourceTableModel: BaseModel
    {
        [Key]
        public int SourceId { get; set; }
        public FilmTableModel FilmId { get; set; }

        public string SourceAcces { get; set; }
    }
}
