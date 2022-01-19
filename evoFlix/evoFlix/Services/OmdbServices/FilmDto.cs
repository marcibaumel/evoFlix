using System;

namespace evoFlix.Services.OmdbServices
{
    public class FilmDto
    {
        private Guid Id { get; set; }

        private string Title { get; set; }

        private DateTime ReleaseYear { get; set; }

        private Ratings Rated { get; set; }

        private TimeSpan RunTime { get; set; }

        private string DirectorName { get; set; }

        private string Genre { get; set; }

        private string Actors { get; set; }

        private string Plot { get; set; }

        private String Poster { get; set; }

        private double ImdbRating { get; set; }
    }

    public enum Ratings
    {
        G,
        PG,
        PG13,
        R,
        NC17
    }
}

