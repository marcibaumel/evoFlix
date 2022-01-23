using evoFlix.Models;
using System;
using System.Globalization;
using System.IO;

namespace evoFlix.Services.OmdbServices
{
    public class FilmDto
    {

        public string Title { get; set; }

        public string Released { get; set; }

        public string Rated { get; set; }

        public string Runtime { get; set; }

        public string Director { get; set; }

        public string Genre { get; set; }

        public string Actors { get; set; }

        public string Plot { get; set; }

        public string Poster { get; set; }

        public string ImdbRating { get; set; }
    }
    
}

