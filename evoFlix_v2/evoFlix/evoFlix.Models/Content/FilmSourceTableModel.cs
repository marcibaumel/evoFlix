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
    public class FilmSourceTableModel : BaseTableModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid FilmId { get; set; }

        [ForeignKey("ID")]
        public FilmTableModel Film { get; set; }

        public String SourceAcces { get; set; }
    }
}
