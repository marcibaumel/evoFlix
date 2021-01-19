using evoFlix.DataAccess;
using evoFlix.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using evoFlix.Models.Content;

namespace evoFlix.Services
{
    public class FilmService
    {
        private UnitOfWork unitOfWork;
        

        public FilmService()
        {
            unitOfWork = new UnitOfWork();
        }

        public void AddFilm(Film film)
        {
            unitOfWork.Films.Add(film);
            unitOfWork.SaveChanges();
        }

        public bool IsUniqueFilmTitle(string title)
        {
            foreach (Film film in unitOfWork.Films)
                if (film.Title == title)
                    return false;
            return true;
        }


    }
}
