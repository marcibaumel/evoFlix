using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.Models.Content
{
    public class Film:BaseModel
    {
        
        public int FilmId { set; get; }

        public string Title { set; get; }

        

        public string DirectorName  { get; set; }

        /*
        //TOP 3
        public string ActorNames { get; set; }
        */

        public int AgeLimit { set; get; }

        public string Category { set; get; }

        public int Length { get; set; }

        public int ReleaseYear { get; set; }

        //public int test { get; set; }

        
    }
}
