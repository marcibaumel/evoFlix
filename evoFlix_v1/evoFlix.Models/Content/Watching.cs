using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.Models.Content
{
    public class Watching: BaseModel
    {
        public int FilmId { set; get; }
        public int Id { get; set; }

        public int Time { get; set; }
    }
}
