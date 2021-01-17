using evoFlix.DataAccess;
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


    }
}
