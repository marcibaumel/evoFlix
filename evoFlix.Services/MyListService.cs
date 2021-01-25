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

            if (checkUserIdAndFilm(FilmName, User) == true)
            {
                mL.userNumber = User;
                mL.filmNumber = FilmName;
                unitOfWork.WatchLists.Add(mL);
                unitOfWork.SaveChanges();
            }
            else
            {
                Console.WriteLine("DB hiba");
            }
           
        }

        public bool checkUserIdAndFilm(int filmId , int userId)
        {
            
            foreach (var user in unitOfWork.WatchLists)
            {
                if (user.userNumber == userId && user.filmNumber == filmId)
                {
                    return false;
                }
                
                    
            }
            return true;
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

        public int getFilmNumber(int Number)
        {
            int filmNumber = unitOfWork.WatchLists.FirstOrDefault(x => x.userNumber == Number).filmNumber;
            
            if (filmNumber == 0)
            {
                return 0;
            }

            return filmNumber;
        }


        //Nem jó még
        public List<int> ListOfUserWatching(int UserID)
        {
            List<int> ListOfUserWatching = new List<int>();


            foreach(var user in unitOfWork.WatchLists)
            {
                //int num = getFilmNumber(UserID);
                if(UserID == user.userNumber )
                {
                    ListOfUserWatching.Add(getFilmNumber(user.userNumber));
                }
            }
            
           
                

            return ListOfUserWatching;
        }


    }
}
