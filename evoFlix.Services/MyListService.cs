using evoFlix.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evoFlix.Models.Content;

namespace evoFlix.Services
{
    public class MyListService
    {
        private UnitOfWork unitOfWork;
        private WatchList wl;
        FilmService fS = new FilmService();

        public MyListService()
        {
            unitOfWork = new UnitOfWork();
        }

        public void AddToMyList(int FilmName, int User)
        {
            wl.FilmId = FilmName;
            wl.Id = User;
            unitOfWork.WatchLists.Add(wl);
            unitOfWork.SaveChanges();
        }

        public string getFilmTitle(int Number)
        {
            string filmTitle = unitOfWork.Films.FirstOrDefault(x => x.Id == Number).Title;
            if (filmTitle == null)
            {
                return "Failed";
            }

            return filmTitle.ToString();
        }


    }
}
