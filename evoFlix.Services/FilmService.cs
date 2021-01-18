using evoFlix.DataAccess;
using evoFlix.Models.Content;
using evoFlix.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
