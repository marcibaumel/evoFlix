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
        //private WatchList wl;
        FilmService fS = new FilmService();

        public MyListService()
        {
            unitOfWork = new UnitOfWork();
        }
        
        public void AddToMyList(int FilmName, int User)
        {
            MyList mL = new MyList();
            mL.filmNumber = FilmName;
            mL.userNumber = User;
            unitOfWork.WatchLists.Add(mL);
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

        //public List<int> listOfFilms(int UserID)
        //{
        //    List<int> ListOfFilms = new List<int>();

        //    if
        //    foreach (var film in unitOfWork.Films)
        //    {
        //        ListOfFilms.Add(film.Id);
        //    }

        //    return ListOfFilms;
        //}

      
    }
}
